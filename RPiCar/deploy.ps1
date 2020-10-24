# Load WinSCP .NET assembly
Add-Type -Path "$PSScriptRoot\WinSCPnet.dll"
function FileTransferProgress {
param($e)
Write-Progress `
-Activity "Uploading" -Status ("{0:P0} complete:" -f $e.OverallProgress) `
-PercentComplete ($e.OverallProgress * 100)
Write-Progress `
-Id 1 -Activity $e.FileName -Status ("{0:P0} complete:" -f $e.FileProgress) `
-PercentComplete ($e.FileProgress * 100)
}
# Set up session options
$sessionOptions = New-Object WinSCP.SessionOptions -Property @{
Protocol              = [WinSCP.Protocol]::Sftp
HostName              = "192.168.11.245"
UserName              = "root"
Password              = "Tuvexz78$"
SshHostKeyFingerprint = "ssh-ed25519 255 DZDuGHS69YGQPa8jLyCAM+7Kuiv/MIFex7rUXYtEqkU="
}
$session = New-Object WinSCP.Session
try {
# Will continuously report progress of transfer
$session.add_FileTransferProgress( { FileTransferProgress($_) } )
# Connect
$session.Open($sessionOptions)
try {
$session.ExecuteCommand("killall RPiCar").Check();
}
catch {
Write-Host 'didnt kill RPiCar because it wasnt running '
}
Start-Process dotnet -ArgumentList 'publish -r linux-arm' -Wait -NoNewWindow -WorkingDirectory $PSScriptRoot
$result = $session.PutFiles("$PSScriptRoot\bin\Debug\*", "/home/pi/Desktop/RPiCar/").Check();
Write-Host $result
$session.ExecuteCommand("chown pi /home/pi/Desktop/RPiCar/ -R").Check();
$session.ExecuteCommand("chmod 777 /home/pi/Desktop/RPiCar/ -R").Check();
#$session.ExecuteCommand("Desktop/RPiCar").Check();

}
finally {
$session.Dispose()
}
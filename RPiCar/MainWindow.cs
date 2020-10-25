using RPiCar_Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.RaspberryIO.Peripherals;
using Unosquare.WiringPi;
namespace RPiCar
{
    public partial class MainWindow : Form
    {
        //LEDOUT led = new LEDOUT();
        //IRIN IRReceiver = new IRIN(4);
        Connection con = new Connection("Car", "goy.ddns.net");
        Car car = new Car(5, 6, 13, 19, 0, 26);//Optionel Servo pin = 18 actuellement brisé donc désactiver!
        private bool w = false;
        private bool a = false;
        private bool s = false;
        private bool d = false;
        public MainWindow()
        {
            InitializeComponent();
            while (true)
            {
                try
                {
                    if (con.Connect());
                    {
                        break;
                    }
                }
                catch(Exception ex)
                {
                    var value = MessageBox.Show(ex.Message);
                }
            }
            con.ConnectionSuccessEvent += Con_ConnectionSuccess;
            con.MessageReceivedEvent += Con_MessageReceived;
            con.ConnectionFailedEvent += Con_ConnectionFailed;
            con.ConnectionLostEvent += Con_ConnectionLost;
            trackBarSpeed.Value = car.Speed;
            labelSpeed.Text = car.Speed.ToString();
            trackBarTurnSpeed.Maximum = 100;
            trackBarTurnSpeed.Value = car.TurnSpeed;
            labelTurnSpeed.Text = car.TurnSpeed.ToString();
            trackBarServo.Maximum = car.MaxServoPwm;
            trackBarServo.Minimum = car.MinServoPwm;
            trackBarServo.Value = 12;
            labelServoVal.Text = trackBarServo.Value.ToString();
            trackBarENA1.Value = car.ENA1PWM;
            trackBarENA2.Value = car.ENA2PWM;
            if (car.IsServoSet == false)
            {
                labelServo.Visible = false;
                labelServoVal.Visible = false;
                trackBarServo.Visible = false;
            }
            //this.KeyPreview = true;

        }
        //Events methods
        //Event raised on failed connection
        private void Con_ConnectionFailed(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine("Connection to server failed\n" + e.Message);
        }
        //Event raised when connection is lost
        private void Con_ConnectionLost(object sender, ExceptionEventArgs e)
        {
            //TODO Modifier fonction connectionLost
            var value = MessageBox.Show("Connection lost!\n" + e.Message, "Error", MessageBoxButtons.RetryCancel);
            if (value == DialogResult.Retry)
            {
                if (!con.Connect())
                {
                    var val = MessageBox.Show("Cant reconnect closing program...", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.Close();
            }
        }
        //Event raised on connection success
        private void Con_ConnectionSuccess(object sender, EventArgs e)
        {
            MessageBox.Show("Connection success!", "Success", MessageBoxButtons.OK);
        }
        //Event raise on connection received a message
        private void Con_MessageReceived(object sender, StringEventArgs e)
        {
            
            listBoxKey.Items.Insert(0, e.Message);
            if (e.Message.All(char.IsDigit))
            {
                
                int command = int.Parse(e.Message);
                switch ((_Command)command)
                {
                    case _Command.Stop:
                        {
                            car.Stop();
                            break;
                        }
                    case _Command.Avant:
                        {
                            car.Forward();
                            break;
                        }
                    case _Command.Avant_Gauche:
                        {
                            car.ForwardLeft();
                            break;
                        }
                    case _Command.Avant_Droite:
                        {
                            car.ForwardRight();
                            break;
                        }
                    case _Command.Arriere:
                        {
                            car.Backward();
                            break;
                        }
                    case _Command.Arriere_Gauche:
                        {
                            car.BackwardLeft();
                            break;
                        }
                    case _Command.Arriere_Droite:
                        {
                            car.BackwardRight();
                            break;
                        }
                    case _Command.Servo_Gauche:
                        {
                            car.servoTurnLeft();
                            break;
                        }
                    case _Command.Servo_Droite:
                        {
                            car.servoTurnRight();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            //check if string contains space and continue using the _Command enum for setspeed etc...
            else if(e.Message.Split(' ').Length == 2 || e.Message.Split(' ')[0].All(char.IsDigit))
            {
                string[] fullCommand = e.Message.Split(' ');
                 _Command command = (_Command)int.Parse(fullCommand[0]);
                int param = int.Parse(fullCommand[1]);
                switch (command)
                {
                    case _Command.Set_Speed:
                        car.setSpeed(param);
                        break;
                    case _Command.Set_Left_Speed:
                        break;
                    case _Command.Set_Right_Speed:
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //backgroundWorker1.WorkerReportsProgress = true;
            //backgroundWorker1.RunWorkerAsync();
        }

        private void NController()
        {
            car.changePinState(1, checkBoxN1.Checked);
            car.changePinState(2, checkBoxN2.Checked);
            car.changePinState(3, checkBoxN3.Checked);
            car.changePinState(4, checkBoxN4.Checked);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            car.Forward();
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            car.Backward();
        }

        private void buttonLeftTurn_Click(object sender, EventArgs e)
        {
            car.Left();
        }

        private void buttonRightTurn_Click(object sender, EventArgs e)
        {
            car.Right();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            car.Stop();
        }

        private void checkBoxN_CheckedChanged(object sender, EventArgs e)
        {
            NController();
        }

        private void trackBarTurnSpeed_Scroll(object sender, EventArgs e)
        {
            labelTurnSpeed.Text = trackBarTurnSpeed.Value.ToString();
            car.setTurnSpeed(trackBarTurnSpeed.Value);
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            labelSpeed.Text = trackBarSpeed.Value.ToString();
            trackBarENA1.Value = trackBarSpeed.Value;
            trackBarENA2.Value = trackBarSpeed.Value;
            car.setSpeed(trackBarSpeed.Value);
        }

        private void trackBarServo_Scroll(object sender, EventArgs e)
        {
            labelServoVal.Text = trackBarServo.Value.ToString();
            car.setServoPosition(trackBarServo.Value);
        }

        private void trackBarENA1_ValueChanged(object sender, EventArgs e)
        {
            labelENA1Value.Text = trackBarENA1.Value.ToString();
        }

        private void trackBarENA1_Scroll(object sender, EventArgs e)
        {
            car.setENA1(trackBarENA1.Value);
        }

        private void trackBarENA2_ValueChanged(object sender, EventArgs e)
        {
            labelENA2Value.Text = trackBarENA2.Value.ToString();
        }

        private void trackBarENA2_Scroll(object sender, EventArgs e)
        {
            car.setENA2(trackBarENA2.Value);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                w = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                s = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                a = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = true;
            }
            //Servo gauche
            else if (e.KeyCode == Keys.Left)
            {
                car.servoTurnLeft();
                listBoxKey.Items.Insert(0, "Servo turning left");
            }
            //Servo droite
            else if (e.KeyCode == Keys.Right)
            {
                car.servoTurnRight();
                listBoxKey.Items.Insert(0, "Servo turning right");
            }
            //Avant
            if (w == true && a == false && d == false)
            {
                car.Forward();
                listBoxKey.Items.Insert(0, "Going forward!");
            }
            //Avant gauche
            else if (w == true && a == true)
            {
                car.ForwardLeft();
                listBoxKey.Items.Insert(0, "Going forward-left!");
            }
            //Avant droite
            else if (w == true && d == true)
            {
                car.ForwardRight();
                listBoxKey.Items.Insert(0, "Going forward-right!");
            }
            //Gauche
            else if (w == false && s == false && a == true)
            {
                car.Left();
                listBoxKey.Items.Insert(0, "Turning left!");
            }
            //Droite
            else if (w == false && s == false && d == true)
            {
                car.Right();
                listBoxKey.Items.Insert(0, "Turning right!");
            }
            //Arriere
            else if(s == true && a == false && d == false)
            {
                car.Backward();
                listBoxKey.Items.Insert(0, "Going backward!");
            }
            //Arriere gauche
            else if (s == true && a == true && d == false)
            {
                car.BackwardLeft();
                listBoxKey.Items.Insert(0, "Going backward-left!");
            }
            //Arriere droite
            else if (s == true && a == false && d == true)
            {
                car.BackwardRight();
                listBoxKey.Items.Insert(0, "Going backward-right!");
            }
            e.Handled = true;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) { w = false; }
            else if (e.KeyCode == Keys.A) { a = false; }
            else if (e.KeyCode == Keys.S) { s = false; }
            else if (e.KeyCode == Keys.D) { d = false; }
            if (w == false && s == false && a == false && d == false)
            {
                car.Stop();
            }
            else if (w == true && s == false && a == false && d == false)
            {
                car.Forward();
            }
            else if (w == false && s == true && a == false && d == false)
            {
                car.Backward();
            }
            e.Handled = true;
            //car.Stop();
        }
    }
}

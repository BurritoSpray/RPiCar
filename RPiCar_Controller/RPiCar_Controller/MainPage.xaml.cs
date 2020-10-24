using RPiCar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPiCar_Controller
{
    public partial class MainPage : ContentPage
    {
        Connection con = new Connection("Controller", "goy.ddns.net");
        public MainPage()
        {
            InitializeComponent();
            con.ConnectionSuccessEvent += Con_ConnectionSuccess;
            con.ConnectionFailedEvent += Con_ConnectionFailed;
            con.ConnectionLostEvent += Con_ConnectionLost;
            con.Connect();
        }

        private void Con_ConnectionLost(object sender, StringEventArgs e)
        {
            DisplayAlert("Erreur", "Connection perdu!", "OK");
        }

        private void Con_ConnectionFailed(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Cant reach server....", "OK");
        }

        private void Con_ConnectionSuccess(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Connection Success!", "OK");
        }

        private void buttonMessageToServer_Clicked(object sender, EventArgs e)
        {
            con.Send(EntryTest.Text);
        }

        private void buttonForward_Released(object sender, EventArgs e)
        {

        }

        private void ButtonForward_Clicked(object sender, EventArgs e)
        {
            con.Send(_Command.Avant.ToString());
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            con.Send(_Command.Stop.ToString());
        }

        private void ButtonLeft_Clicked(object sender, EventArgs e)
        {
            con.Send(_Command.Gauche.ToString());
        }

    }
}

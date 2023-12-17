using AplicacionEscritorioCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AplicacionEscritorioCore.Modelo;
using AplicacionEscritorioCore.Cotrolador;

namespace AplicacionEscritorioCore.Vista.Login
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {

        private LoginCtrllr login;  
        public LoginView()
        {
            InitializeComponent();

        }

        private void disableview(bool band)
        {
            this.txtpassword.Dispatcher.Invoke(() =>
            {
                this.txtpassword.IsEnabled = !band;
            });


            this.txtusuario.Dispatcher.Invoke(() =>
            {
                this.txtusuario.IsEnabled = !band;

            });


                this.buttonlogin.Dispatcher.Invoke(() =>
            {
                this.buttonlogin.IsEnabled = !band;
            });

         
           

        }

        private void buttonlogin_Click(object sender, RoutedEventArgs e)
        {
            
            AppSesion.isInWait(true);
            this.disableview(true);
            string user = txtusuario.Text;
            string password = txtpassword.Password.ToString();
            login = new LoginCtrllr();

            Task t = Task.Run(() =>
            {
                AppSesion.initApp();
                bool rpta = login.verificarUs(user, password);
                return rpta;

            }).ContinueWith(antecedent =>
            {
                AppSesion.isInWait(false);
                this.disableview(false);
                if (!antecedent.Result)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                  
                }
                else
                {
                    AppSesion.miFrame.Dispatcher.Invoke(() =>
                        AppSesion.miFrame.Navigate(new Presentacion())
                    );
                }




            });


            








        }


    }
}

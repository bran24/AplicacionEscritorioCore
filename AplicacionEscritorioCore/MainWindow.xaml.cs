using AplicacionEscritorioCore.Core;
using AplicacionEscritorioCore.Vista.Login;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AplicacionEscritorioCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void onNavigatedEvent(object sender, NavigationEventArgs e)
        {
            Trace.WriteLine("Navegacion concluida");
            AppSesion.miFrame.NavigationService.RemoveBackEntry();
            //this.Resources["logo"];
            //SgtSession.initMainMenuLogoImage();
        }

        private void onLoadCompleted(object sender, NavigationEventArgs e)
        {
            //Trace.WriteLine("Navegacion concluida");
            //AppSesion.initMainMenuLogoImage();
        }





        private void onNavigatedModal(object sender, NavigationEventArgs e)
        {
            //Trace.WriteLine("Navegacion concluida");
            AppSesion.miModalFrame.NavigationService.RemoveBackEntry();

        }


        private void Window_Initialized(object sender, EventArgs e)
        {

            AppSesion.isInWait(true);

            //SgtSession.initApp();
            AppSesion.miWindow = this;
            AppSesion.miFrame = this.frmMainPanel;
            AppSesion.miModalFrame = this.frmModalPanel;
            AppSesion.miLoadingPanel = this.pnlLoading;
            AppSesion.miModalPanel = this.pnlModal;


            AppSesion.miFrame.Dispatcher.Invoke(() =>
            AppSesion.miFrame.Navigate(new LoginView())
        );


            AppSesion.isInWait(false);

            AppSesion.actionOnModalPanel(false, "");

        }

        private void closeModal_Click(object sender, RoutedEventArgs e)
        {
            AppSesion.actionOnModalPanel(false,"");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ORM;
using AplicacionEscritorioCore.Helpers;


namespace AplicacionEscritorioCore.Core
{
    internal class AppSesion
    {



        public static Frame miFrame { get; set; }
        public static Frame miModalFrame { get; set; }
        public static Grid miLoadingPanel { get; set; }
        public static Grid miModalPanel { get; set; }
        public static Window miWindow { get; set; } = null;


        public static bool initApp()
        {

            try
            {
                OrmContext.connection = Cammon.GetConexionDB();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }



        }


        public static void isInWait(bool estado, string mensajeCarga = "")
        {

            if (miLoadingPanel != null)
            {
                miLoadingPanel.Dispatcher.Invoke(() => {

                    var elemento = (TextBlock)miLoadingPanel.FindName("txtMsjCarga0001");
                    miLoadingPanel.Visibility = estado ? Visibility.Visible : Visibility.Collapsed;
                    elemento.Text = String.IsNullOrEmpty(mensajeCarga) ? "Cargando..." : mensajeCarga;




                });
            }



        }


        public static void initMainMenuLogoImage()
        {
            Page currentPage = (Page)AppSesion.miFrame.Content;
            Image imagen = (Image)currentPage.FindName("mainMenuImageLogo");
            imagen.Dispatcher.Invoke(() => { imagen.Source = Application.Current.TryFindResource("logoprueba") as BitmapImage; });


        }

        public static void actionOnModalPanel(bool estado, string titulo, Page nuevoPanel = null)
        {
            if (miModalPanel != null)
            {
                miModalPanel.Dispatcher.Invoke(() =>
                {
                    var txtTitulo = (TextBlock)miModalPanel.FindName("txtModalTitulo");
                    var frmContenido = (Frame)miModalPanel.FindName("frmModalPanel");
                    miModalPanel.Visibility = estado ? Visibility.Visible : Visibility.Collapsed;
                    //txtTitulo.Text = (String.IsNullOrEmpty(titulo)) ? titulo : "";
                    if (txtTitulo != null)
                    {
                        txtTitulo.Text = titulo;
                    }
                    else
                    {
                        txtTitulo.Text = "";
                    }
                    if (frmContenido != null)
                    {
                        if (nuevoPanel != null)
                        {
                            frmContenido.NavigationService.Navigate(nuevoPanel);
                        }
                        else
                        {
                            frmContenido.Content = null;
                        }
                    }
                });
            }
        }





    }
}

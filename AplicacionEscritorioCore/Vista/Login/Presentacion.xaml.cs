using AplicacionEscritorioCore.Core;
using AplicacionEscritorioCore.Vista.Archivos;
using AplicacionEscritorioCore.Vista.Productos;
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

namespace AplicacionEscritorioCore.Vista.Login
{
    /// <summary>
    /// Lógica de interacción para Presentacion.xaml
    /// </summary>
    public partial class Presentacion : Page
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        private void ItemNuevo_Click(object sender, RoutedEventArgs e)
        {

            AppSesion.miFrame.NavigationService.Navigate(new RegistrarProducto());
        }

        private void Rproducto_Click(object sender, RoutedEventArgs e)
        {
         
            Page repor = new GenerarExcelProductos();

            AppSesion.actionOnModalPanel(true, "Descargar lista productos", repor);

        }
    }
}   

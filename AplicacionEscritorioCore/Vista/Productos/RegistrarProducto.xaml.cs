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
using AplicacionEscritorioCore.Core;
using AplicacionEscritorioCore.Cotrolador;
using AplicacionEscritorioCore.Vista.Login;
using ORM.Entities;

namespace AplicacionEscritorioCore.Vista.Productos
{
    /// <summary>
    /// Lógica de interacción para RegistrarProducto.xaml
    /// </summary>
    public partial class RegistrarProducto : Page
    {

       private ProductoCtrllr prodct;
       private List<Producto> prodctList;
        public RegistrarProducto()
        {

           
            InitializeComponent();

            try
            {
                prodct = new ProductoCtrllr();

                prodctList = new List<Producto>();
                prodctList = prodct.getProductos();
                DataProductos.ItemsSource = prodctList;
                DataProductos.SelectedValuePath = "id";
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
            }

            }

       

        private void goToManin_Click(object sender, RoutedEventArgs e)
        {
            AppSesion.miFrame.NavigationService.Navigate(new Presentacion());
        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(txtnombrep.Text) && !String.IsNullOrEmpty(txtCantidadp.Text) && !String.IsNullOrEmpty(txtpreciop.Text))
                {

                    string nombre = txtnombrep.Text.ToString();
                    decimal precio = Convert.ToDecimal(txtpreciop.Text);
                    int cantidad = Convert.ToInt32(txtCantidadp.Text);



                    if (btnregistrar.Content.ToString() == "Registrar")
                    {
                        AppSesion.isInWait(true);

                        Task t = Task.Run(() =>
                        {
                            var resp = prodct.RegistrarProductos(nombre, precio, cantidad);
                            return resp;
                        }).ContinueWith((resp) =>
                        {
                            AppSesion.isInWait(false);
                            MessageBox.Show($"Registrado Exitoso");
                            prodctList = prodct.getProductos();
                            DataProductos.Dispatcher.Invoke(() => DataProductos.ItemsSource = prodctList);
                            txtnombrep.Dispatcher.Invoke(() => txtnombrep.Text = "");

                            txtCantidadp.Dispatcher.Invoke(() => txtCantidadp.Text = "");

                            txtpreciop.Dispatcher.Invoke(() => txtpreciop.Text = "");



                        });




                    }
                    if (btnregistrar.Content.ToString() == "Actualizar")
                    {
                        int id = (int)DataProductos.SelectedValue;

                        AppSesion.isInWait(true);

                        Task t = Task.Run(() =>
                        {
                            var resp = prodct.ModificarProductos(id, nombre, precio, cantidad);
                            return resp;
                        }).ContinueWith((resp) =>
                        {
                            AppSesion.isInWait(false);
                            MessageBox.Show($"Actualizacion Exitosa");
                            prodctList = prodct.getProductos();
                            DataProductos.Dispatcher.Invoke(() => DataProductos.ItemsSource = prodctList);
                            txtnombrep.Dispatcher.Invoke(() => txtnombrep.Text = "");

                            txtCantidadp.Dispatcher.Invoke(() => txtCantidadp.Text = "");

                            txtpreciop.Dispatcher.Invoke(() => txtpreciop.Text = "");
                            btnregistrar.Dispatcher.Invoke(() => btnregistrar.Content = "Registrar");
                            labelprod.Dispatcher.Invoke(() => labelprod.Text = "Registrar Producto");



                        });




                    }

                }

                else
                {
                    MessageBox.Show("Llenar Campos", "Datos Faltantes", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
            catch(Exception er)
            {
                Console.WriteLine("erorrrr"+er.Message);
            }


        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = DataProductos.SelectedValue == null ? 0 : (int)DataProductos.SelectedValue;


                /*      MessageBoxResult result =  MessageBox.Show("Hello, world?", "My App", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No)*/
                ;


                if (id != 0)
                {
                    obtenerProducto(id);
                }


            }
            catch(Exception er)
            { Console.WriteLine(er.Message);
            
            
            }



        }

        private void obtenerProducto(int id)
        {

            try
            {
                IEnumerable<Producto> pr = from producto in prodctList where producto.id == id select producto;

                var producto1 = pr.FirstOrDefault();

                txtnombrep.Text = producto1.nombre ?? "";
                txtCantidadp.Text = producto1.cantidad.ToString();
                txtpreciop.Text = producto1.precio.ToString();
                btnregistrar.Content = "Actualizar";
                labelprod.Text = "Actualizar Producto";
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
            }

        }



        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resp = MessageBox.Show("Eliminar Producto", "Datos", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                switch (resp)
                {
                    case MessageBoxResult.Yes:
                        int id = (int)DataProductos.SelectedValue;
                        prodct.eliminarProducto(id);
                        prodctList = prodct.getProductos();
                        DataProductos.ItemsSource = prodctList;
                        break;



                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }






        }

        private void btncancelar_Click(object sender, RoutedEventArgs e)
        {
            btnregistrar.Content = "Registrar";
            labelprod.Text = "Registrar Producto";
            txtnombrep.Text = "";
            txtCantidadp.Text = "";
            txtpreciop.Text = "";
        }

   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using ORM.Entities;

namespace AplicacionEscritorioCore.Cotrolador
{
    public class ProductoCtrllr
    {


       public List<Producto> getProductos()
        {
            using (var context = new OrmContext())
            {
                var pro =  context.productos.Where(p =>p.eliminado != 1).ToList();

                return pro;
            }




        }

        public int RegistrarProductos(string nombre,decimal precio,int cantidad)
        {
            using(var context = new OrmContext())
            {
                var pro = new Producto { nombre = nombre, precio = precio, cantidad = cantidad };
                context.productos.Add(pro);
               var a =  context.SaveChanges();
                return a;
            }
        }

        public int ModificarProductos(int id, string nombre, decimal precio, int cantidad)
        {
            using(var context = new OrmContext())
            {
             Producto prop =   context.productos.Single((p) => p.id == id);

                prop.precio = precio;
                prop.nombre = nombre;   
                prop.cantidad = cantidad;

              return  context.SaveChanges();


            }

        }

        public Producto ObtenerProducto(int id)
        {

            using(var context = new OrmContext())
            {
              var prop =  context.productos.Single(p => p.id == id);

                return prop;


            }
        }

        public int eliminarProducto(int id)
        {
            using (var context = new OrmContext())

            {

                Producto prop = context.productos.Single((p) => p.id == id);

                prop.eliminado = 1;
                return context.SaveChanges();
            }


        }





    }
}

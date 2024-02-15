using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entregable2.database;
using Entregable2.models;
using Microsoft.EntityFrameworkCore;

namespace Entregable2.service
{
    public static class ProductoData
    {
        public static List<Producto> ListarProducto()
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                List<Producto> productos = context.Productos.ToList();

                return productos;

            }
        }

        public static Producto ObtenerProducto(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                return productoBuscado;
            }
        }

        public static bool CrearProducto(Producto producto)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarProducto(Producto producto, int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                Producto? usuarioProducto = ObtenerProducto(id);
                
                usuarioProducto.Description = producto.Description;
                usuarioProducto.Cost = producto.Cost;
                usuarioProducto.SalePrice = producto.SalePrice;
                usuarioProducto.Stock = producto.Stock;

                context.Productos.Update(usuarioProducto);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarProducto(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                Producto productoAEliminar = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                if (productoAEliminar is not null)
                {
                    context.Productos.Remove(productoAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}

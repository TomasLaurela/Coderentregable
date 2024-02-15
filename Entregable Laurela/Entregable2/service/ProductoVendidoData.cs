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
    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ListarProductoVendido()
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                List<ProductoVendido> productosVendidos = context.ProductoVendidos.ToList();

                return productosVendidos;

            }
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                ProductoVendido? productoVendidoBuscado = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();
                return productoVendidoBuscado;
            }
        }

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                context.ProductoVendidos.Add(productoVendido);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarProducto(ProductoVendido productoVendido, int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                ProductoVendido? usuarioProductoVend = ObtenerProductoVendido(id);

                usuarioProductoVend.Stock = productoVendido.Stock;
                
                context.ProductoVendidos.Update(usuarioProductoVend);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarProductoVendido(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                ProductoVendido productoVendAEliminar = context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();

                if (productoVendAEliminar is not null)
                {
                    context.ProductoVendidos.Remove(productoVendAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}

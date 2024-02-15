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
    public static class UsuarioData
    {
        public static List<Usuario> ListarUsuarios()
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;

            }
        }

        public static Usuario ObtenerUsuario(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {

                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarUsuario(Usuario usuario, int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                Usuario? usuarioBuscado = ObtenerUsuario(id);


                usuarioBuscado.Name = usuario.Name;
                usuarioBuscado.LastName = usuario.LastName;
                usuarioBuscado.UserName = usuario.UserName;
                usuarioBuscado.Password = usuario.Password;
                usuarioBuscado.Mail = usuario.Mail;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarUsuario(int id)
        {
            using (Entregable2Context context = new Entregable2Context())
            {
                Usuario usuarioAEliminar = context.Usuarios.Where(us => us.Id == id).FirstOrDefault();

                if (usuarioAEliminar is not null)
                {
                    context.Usuarios.Remove(usuarioAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    }
}

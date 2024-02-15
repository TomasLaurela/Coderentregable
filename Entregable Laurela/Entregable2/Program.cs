// See https://aka.ms/new-console-template for more information
using Entregable2.models;
using Entregable2.service;

int id;
Usuario user;
List<Usuario> usuarios;
ProductoVendido productoVendido;

usuarios = UsuarioData.ListarUsuarios();

//foreach (Usuario usuario  in usuarios)
//{
//    Console.WriteLine($"{usuario.Name}");
//}

//Console.WriteLine("Ingrese un id de usuario: ");
//id = Convert.ToInt32(Console.ReadLine());

//user=UsuarioData.ObtenerUsuario(id);
//Console.WriteLine($"{user.Name} {user.LastName}");

//user = new Usuario();

//Console.WriteLine("Ingrese el nombre de un usuario nuevo: ");
//user.Name = Console.ReadLine();
//Console.WriteLine("Ingrese el apellido de un usuario nuevo: ");
//user.LastName = Console.ReadLine();
//Console.WriteLine("Ingrese el nombre de usuario de un usuario nuevo: ");
//user.UserName = Console.ReadLine();
//Console.WriteLine("Ingrese la contraseña de un usuario nuevo: ");
//user.Password = Console.ReadLine();
//Console.WriteLine("Ingrese el mail de un usuario nuevo: ");
//user.Mail = Console.ReadLine();

//UsuarioData.CrearUsuario(user);

//UsuarioData.ModificarUsuario(user, 1);

//usuarios = UsuarioData.ListarUsuarios();

//foreach (Usuario usuario in usuarios)
//{
//    Console.WriteLine($"{usuario.Name} {usuario.LastName}");
//}

//productoVendido = new ProductoVendido();

//if (!(ProductoVendidoData.EliminarProductoVendido(1)))
//    Console.WriteLine("No se pudo encontrar el Id.");


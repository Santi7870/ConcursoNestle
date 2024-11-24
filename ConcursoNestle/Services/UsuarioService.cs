using SQLite;
using ConcursoNestle.Models;

namespace ConcursoNestle.Services
{
    public class UsuarioService
    {
        private SQLiteConnection _connection;

        public UsuarioService(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<User>();
        }

        // Registrar un nuevo usuario
        public void RegistrarUsuario(User usuario)
        {
            _connection.Insert(usuario);
        }

        // Obtener un usuario por correo
        public User ObtenerUsuarioPorCorreo(string correo)
        {
            return _connection.Table<User>().FirstOrDefault(u => u.Email == correo);
        }

        // Validar login
        public bool ValidarLogin(string correo, string clave)
        {
            var usuario = _connection.Table<User>().FirstOrDefault(u => u.Email == correo && u.Password == clave);
            return usuario != null;
        }
    }
}


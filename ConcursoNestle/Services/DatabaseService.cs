using SQLite;
using ConcursoNestle.Models;

namespace ConcursoNestle.Services
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService()
        {
            _database = new SQLiteConnection(App.DatabasePath);
            _database.CreateTable<User>();
        }

        public void SaveUser(User user)
        {
            _database.Insert(user);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _database.Table<User>().FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}

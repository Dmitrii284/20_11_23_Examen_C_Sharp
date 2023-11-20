using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace _20_11_23_Examen_C_Sharp
{
    public class UserStorage : IUserStorage
    {
        public List<User> users = new List<User>();
        public void AddUser(User user) 
        { 
            users.Add(user);
            Console.WriteLine($"Пользователь добавлен: {user}");
        }        
        public void RemoveUser(User user) 
        { 
            users.Remove(user);
            Console.WriteLine($"Пользователь удален: {user}");
        } 
        public User GetUser(int userId)
        {
            return users.Find(u => u.Id == userId);
        }
        public void UpdateUser(User user) 
        { 
            var existingUser = users.Find(u => u.Id == user.Id);
            if (existingUser != null)
            {
                users.Remove(existingUser);
                users.Add(user);
            }
        }
        public void DeleteUser(int userId) 
        { 
         var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
                UserDeleted?.Invoke(user);
            }
        }

        public delegate void UserDelegate(User user);        
        public event UserDelegate UserAdded;
        public event UserDelegate UserDeleted;

    }

    и

    public class G<T, Y, Z>
    {
        public T User { get; set; }
        public Y GetY (int id) { return Y; }
        public G() { }
    }
}

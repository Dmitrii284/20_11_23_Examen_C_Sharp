using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_11_23_Examen_C_Sharp
{
    public interface IUserStorage
    {
        public void AddUser(User user);
        User GetUser(int userId);
        public void RemoveUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);

    }
}

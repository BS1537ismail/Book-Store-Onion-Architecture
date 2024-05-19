using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public interface IUserService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> AddUser(T user);
        Task<T> EditUser(int id);
        Task<T> DeleteUser(int id);
        Task<T> Details(int id);    
        void UpdateUser(T user);
        void RemoveUser(T user);
    }
}

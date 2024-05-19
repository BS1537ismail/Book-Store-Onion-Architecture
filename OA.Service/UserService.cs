using Microsoft.EntityFrameworkCore;
using OA.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public class UserService<T> : IUserService<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public DbSet<T> dbSet { get; set; }
        public UserService(ApplicationDbContext context)
        {
            this.context = context;
            dbSet =  context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> AddUser(T user)
        {
            await dbSet.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<T> EditUser(int id)
        {
            var data = await dbSet.FindAsync(id);
           
            return data;

        }
        public async Task<T> DeleteUser(int id)
        {
            var data = await dbSet.FindAsync(id);
            return data;
           
        }
        public async Task<T> Details(int id)
        {
            var data = await dbSet.FindAsync(id);
            return data;
        }
        public void UpdateUser(T user)
        {
            dbSet.Update(user); 
            context.SaveChanges();
        }
        public void RemoveUser(T user)
        {
            dbSet.Remove(user);
            context.SaveChanges();
        }
    }
}

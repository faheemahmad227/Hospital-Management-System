using AuthenticationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(params string[] includes);

        public T Add(T item);

        Task<int> SaveAsync();
        Task<int> GetByUserId(string id);
    }
}

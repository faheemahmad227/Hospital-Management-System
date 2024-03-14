using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRecordsService.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T item);
        T Update(T item);
        T Delete(T item);
        Task<IReadOnlyCollection<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<int> SaveAsync();
    

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Repository
{
    public interface IFeedbackService<T> where T : class
    {
        T Add(T item);
        Task<IReadOnlyCollection<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<int> SaveAsync();
    }
}

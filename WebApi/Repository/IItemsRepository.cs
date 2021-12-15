using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IItemsRepository<T> where T : class 
    {
        public IEnumerable<T> GetItems();
        public T GetItem(Guid id);
    }
}

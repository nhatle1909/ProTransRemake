using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interface
{
    public interface IGenericRepository<TEntities> where TEntities : BaseEntity
    {
        public Task<(bool, string)> AddItemAsync(TEntities item);
        public Task<(bool, string)> RemoveItemAsync(Guid Id);
        public Task<(bool, string)> SoftRemoveItemAsync(Guid Id);
        public Task<(TEntities, bool, string)> GetByIdAsync(Guid Id);
        public Task<(bool, string)> UpdateItemAsync(Guid id, TEntities newItem);
        public Task<(IEnumerable<TEntities>, bool, string)> GetPagingAsync(string[] searchParams, string[] searchValues, string? includeProperties = null, string? sortField = null, int? pageSize = 5, int? skip = 1);
        public Task<(IEnumerable<TEntities>, bool, string)> GetByFilterAsync(Expression<Func<TEntities, bool>>? filter = null, string? includeProperties = null);
        public Task<long> CountAsync(Dictionary<string, string> searchParams, int pageSize = 5);
    }
}

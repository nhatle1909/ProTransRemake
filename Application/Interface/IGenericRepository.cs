using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IGenericRepository<TEntities> where TEntities : BaseEntity
    {
        public Task<bool> AddItemAsync(TEntities item);
        public Task<(string, bool)> RemoveItemAsync(Guid Id);
        public Task<(string, bool)> SoftRemoveItemAsync(Guid Id);
        public Task<(string, TEntities)> GetByIdAsync(Guid Id);
        public Task<(string, bool)> UpdateItemAsync(TEntities newItem);
        public Task<(IEnumerable<TEntities>, string)> GetPagingAsync(Dictionary<string, string> searchParams, string? includeProperties = null, string? sortField = null, bool isAsc = false, int pageSize = 5, int skip = 1);
        public Task<(IEnumerable<TEntities>, string)> GetByFilterAsync(Expression<Func<TEntities, bool>>? filter = null, string? includeProperties = null);
        public Task<long> CountAsync(Dictionary<string, string> searchParams, int pageSize = 5);
    }
}

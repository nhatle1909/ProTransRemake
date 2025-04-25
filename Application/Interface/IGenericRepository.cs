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
        public Task<(bool,string)> AddItemAsync(TEntities item);
        public Task<(bool,string)> RemoveItemAsync(Guid Id);
        public Task<(bool,string)> SoftRemoveItemAsync(Guid Id);
        public Task<(TEntities,bool, string)> GetByIdAsync(Guid Id);
        public Task<(bool,string)> UpdateItemAsync(TEntities newItem);
        public Task<(IEnumerable<TEntities>, bool, string)> GetPagingAsync(Dictionary<string, string> searchParams, string? includeProperties = null, string? sortField = null, int? pageSize = 5, int? skip = 1);
        public Task<(IEnumerable<TEntities>, bool,string)> GetByFilterAsync(Expression<Func<TEntities, bool>>? filter = null, string? includeProperties = null);
        public Task<long> CountAsync(Dictionary<string, string> searchParams, int pageSize = 5);
    }
}

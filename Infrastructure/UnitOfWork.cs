using Application.Interface;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly IMemoryCache _memoryCache;
        private readonly ProTransDbContext _dbContext;
        public UnitOfWork(ProTransDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
            _repositories = new Dictionary<Type, object>();
        }
        public void Dispose()
        {
            return;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public IGenericRepository<TEntities> GetRepository<TEntities>() where TEntities : BaseEntity
        {

            if (_repositories.ContainsKey(typeof(TEntities)))
            {
                return (IGenericRepository<TEntities>)_repositories[typeof(TEntities)];
            }

            var repository = new GenericRepository<TEntities>(_dbContext, _memoryCache);

            _repositories.Add(typeof(TEntities), repository);

            return repository;
        }
    }
}

using Domain.Entities;

namespace Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<TEntities> GetRepository<TEntities>() where TEntities : BaseEntity;
    }
}

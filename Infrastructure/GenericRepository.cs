using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class GenericRepository<TEntities> : IGenericRepository<TEntities> where TEntities : BaseEntity
    {
        public DbSet<TEntities> _dbSet;
        private IMemoryCache _memoryCache;
        public GenericRepository(DbContext _context, IMemoryCache memoryCache)
        {
            _dbSet = _context.Set<TEntities>();
            _memoryCache = memoryCache;
        }
        public async Task<(bool, string)> AddItemAsync(TEntities item)
        {
            try
            {
                await _dbSet.AddAsync(item);
                return (true, "Add new item successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool, string)> RemoveItemAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null) return (false, "Item not found");
                _dbSet.Remove(query);
                return (true, "Deleted Item successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool, string)> SoftRemoveItemAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null || query.IsDeleted == true) return (false, "Item not found");
                query.IsDeleted = true;
                _dbSet.Update(query);
                return (true, "Deleted Item successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(TEntities, bool, string)> GetByIdAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null) return (null, false, "Item not found");
                return (query, true, "Retrieved data successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool, string)> UpdateItemAsync(Guid id, TEntities newItem)
        {
            try
            {
                var query = await _dbSet.FindAsync(id);
                if (query == null || query.IsDeleted == true) return (false, "Item not found");
                query = newItem;
                query.Id = id; // Ensure the ID remains the same
                query.ModifiedDate = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));
                _dbSet.Update(query);
                return (true, "Updated item successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(IEnumerable<TEntities>, bool, string)> GetPagingAsync(string[] searchFields, string[] searchValue, string? includeProperties = null, string? sortField = null, int? pageSize = 5, int? skip = 1)
        {
            try
            {
                var query = _dbSet.AsQueryable();
                if (!string.IsNullOrWhiteSpace(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.TrimEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }
                if (searchFields.Length == searchValue.Length && searchFields.Length > 0)
                {
                    for (int i = 0; i < searchFields.Length; i++)
                    {
                        if (searchValue[i] != null)
                        {
                            query = query.Where($"{searchFields[i]}.Contains(@0)", searchValue[i]);
                        }
                    }
                }

                if (query == null) return (null, false, "No item found");

                if (sortField != null)
                {
                    if (sortField.StartsWith("!")) query = query.OrderBy($"{sortField.Substring(1)} descending");
                    else query = query.OrderBy($"{sortField} ascending");
                }
                //int? to int 
                var intPageSize = pageSize == null ? 5 : (int)pageSize;
                var intSkip = skip == null ? 1 : (int)skip;
                query = query.Take(intPageSize)
                                 .Skip((intSkip - 1) * intPageSize);


                var result = await query.ToListAsync();
                return (result, true, "Retrieve data successfully");

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(IEnumerable<TEntities>, bool, string)> GetByFilterAsync(Expression<Func<TEntities, bool>>? filter = null, string? includeProperties = null)
        {
            try
            {
                var query = _dbSet.AsQueryable();
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                                 StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }

                if (query == null) return (null, false, "No item found");

                var result = await query.ToListAsync();
                return (result, false, "Retrieve data successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<long> CountAsync(string[]? searchFields, string[]? searchValue, int? pageSize = 5)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                if (searchFields.Length == searchValue.Length && searchFields.Length > 0)
                {
                    for (int i = 0; i < searchFields.Length; i++)
                    {
                        if (searchValue[i] != null)
                        {
                            query = query.Where($"{searchFields[i]}.Contains(@0)", searchValue[i]);
                        }
                    }
                }
                
                var intPageSize = pageSize == null ? 5 : (int)pageSize;
                float count = await query.CountAsync();
                return (long)MathF.Ceiling(count / intPageSize);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

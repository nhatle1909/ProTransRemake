using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<TEntities> : IGenericRepository<TEntities> where TEntities : BaseEntity
    {
        public DbSet<TEntities> _dbSet;
        private IMemoryCache _memoryCache;
        public GenericRepository(ProTransDbContext _context,IMemoryCache memoryCache)
        {
            _dbSet = _context.Set<TEntities>();
            _memoryCache = memoryCache;
        }
        public async Task<bool> AddItemAsync(TEntities item)
        {
            try
            {
                await _dbSet.AddAsync(item);
                return true;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(string,bool)> RemoveItemAsync(Guid Id)
        {
            try
            {
               var query =  await _dbSet.FindAsync(Id);
               if (query == null) return ("Item not found",false);
               _dbSet.Remove(query);
               return ("Deleted Item successfully",true);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(string, bool)> SoftRemoveItemAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null || query.IsDeleted == true) return ("Item not found", false);
                query.IsDeleted = true;
                _dbSet.Update(query);
                return ("Deleted Item successfully", true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(string, TEntities)> GetByIdAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null) return ("Item not found", null);
                return ("Retrieved data successfully",query);
            }
            catch ( Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(string,bool)> UpdateItemAsync( TEntities newItem)
        {
            try
            {
                var query = await _dbSet.FindAsync(newItem.Id);
                if (query == null) return ("Item not found", false);

                newItem.ModifiedDate = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));

                _dbSet.Update(newItem);
                
                return ("Updated item successfully", true);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(IEnumerable<TEntities>,string)> GetPagingAsync(Dictionary<string, string> searchParams, string? includeProperties = null,string? sortField = null,bool isAsc = false,int pageSize = 5, int skip=1)
        {
            try
            {
                var query = _dbSet.AsQueryable();
               
                if (searchParams != null)
                {
                    foreach (KeyValuePair<string, string> keyValuePair in searchParams) {

                        query = query.Where(string.Format("{0} = {1}", keyValuePair.Key, keyValuePair.Value));
                    }
                }
              
                if (query == null) return (null, "No item found");

                if (sortField != null)
                {
                    if (isAsc) query = query.OrderBy($"{sortField} ascending");
                    else query = query.OrderBy($"{sortField} descending");
                }
                query = query.Take(pageSize)
                             .Skip((skip - 1) * pageSize);

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                                 StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                var result = await query.ToListAsync();
                return (result, "Retrieve data successfully");
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        } 
        public async Task<(IEnumerable<TEntities>,string)> GetByFilterAsync(Expression<Func<TEntities,bool>>? filter = null, string? includeProperties = null)
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

                if (query == null) return (null, "No item found");

                var result = await query.ToListAsync();
                return (result, "Retrieve data successfully");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<long> CountAsync(Dictionary<string, string> searchParams, int pageSize = 5)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                if (searchParams != null)
                {
                    foreach (KeyValuePair<string, string> keyValuePair in searchParams)
                    {

                        query = query.Where(string.Format("{0} = {1}", keyValuePair.Key, keyValuePair.Value));
                    }
                }
                float count = await query.CountAsync();
                return (long)MathF.Ceiling(count / pageSize);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

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
        public async Task<(bool,string)> AddItemAsync(TEntities item)
        {
            try
            {
                await _dbSet.AddAsync(item);
                return (true, "Add new item successfully");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool,string)> RemoveItemAsync(Guid Id)
        {
            try
            {
               var query =  await _dbSet.FindAsync(Id);
               if (query == null) return (false, "Item not found");
               _dbSet.Remove(query);
               return (true, "Deleted Item successfully");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool,string)> SoftRemoveItemAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null || query.IsDeleted == true) return ( false, "Item not found");
                query.IsDeleted = true;
                _dbSet.Update(query);
                return (true, "Deleted Item successfully");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(TEntities, bool,string)> GetByIdAsync(Guid Id)
        {
            try
            {
                var query = await _dbSet.FindAsync(Id);
                if (query == null) return ( null, false,"Item not found");
                return (query, true,"Retrieved data successfully");
            }
            catch ( Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(bool,string)> UpdateItemAsync( TEntities newItem)
        {
            try
            {
                var query = await _dbSet.FindAsync(newItem.Id);
                if (query == null) return ( false, "Item not found");

                newItem.ModifiedDate = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));

                _dbSet.Update(newItem);
                
                return (true,"Updated item successfully");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(IEnumerable<TEntities>,bool,string)> GetPagingAsync(Dictionary<string, string> searchParams, string? includeProperties = null,string? sortField = null,int? pageSize = 5, int? skip=1)
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
              
                if (query == null) return (null,false, "No item found");

                if (sortField != null )
                {
                    if (sortField.StartsWith("!")) query = query.OrderBy($"{sortField} descending");
                    else query = query.OrderBy($"{sortField} ascending");
                }
                //int? to int 
                var intPageSize = pageSize == null ? 5 : (int)pageSize;
                var intSkip = skip == null ? 1 : (int)skip;
                query = query.Take(intPageSize)
                                 .Skip((intSkip - 1) * intPageSize);

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                                 StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                var result = await query.ToListAsync();
                return (result,true ,"Retrieve data successfully");
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        } 
        public async Task<(IEnumerable<TEntities>,bool,string)> GetByFilterAsync(Expression<Func<TEntities,bool>>? filter = null, string? includeProperties = null)
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

                if (query == null) return (null,false ,"No item found");

                var result = await query.ToListAsync();
                return (result,false ,"Retrieve data successfully");
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

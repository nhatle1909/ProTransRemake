using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<TEntities> where TEntities : BaseEntity
    {
        public DbSet<TEntities> _dbSet;
        public GenericRepository(ProTransDbContext _context)
        {
            _dbSet = _context.Set<TEntities>();
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
                _dbSet.Update(newItem);
                
                return ("Updated item successfully", true);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<(IEnumerable<TEntities>,string)> GetByFilterAsync(Expression<Func<TEntities, bool>>? filter = null, string? includeProperties = null)
        {
            try
            {
                var query = _dbSet.AsQueryable();
                if (filter != null)
                {
                    query = query.Where(filter);
                }
              
                if (query == null) return (null, "No item found");

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
        
    }
}

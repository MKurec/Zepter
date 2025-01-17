﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ZepterTask.Infrastructure.Repositories
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
   {
      private readonly AppDbContext _context;
      private readonly DbSet<T> _dbSet;

      public GenericRepository(AppDbContext context)
      {
         _context = context;
         _dbSet = context.Set<T>();
      }

      public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
      {
         return await _dbSet.FirstOrDefaultAsync(predicate);
      }


      public async Task<IEnumerable<T>> GetAllAsync()
      {
         return await _dbSet.ToListAsync();
      }


      public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
      {
         return await _dbSet.Where(predicate).ToListAsync();
      }

      public async Task AddAsync(T item)
      {
         await _dbSet.AddAsync(item);
         await _context.SaveChangesAsync();
      }

      public async Task UpdateAsync(T item)
      {
         _dbSet.Update(item);
         await _context.SaveChangesAsync();
      }

      public async Task RemoveAsync(T item)
      {
         _dbSet.Remove(item);
         await _context.SaveChangesAsync();
      }
   }
}

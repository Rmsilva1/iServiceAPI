﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iServiceApi.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Models.IServiceContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(Models.IServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet
                .Where(where)
                .ToList();
        }

        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<bool> Insert(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();

                return true;

            }catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<bool> Update(TEntity updated)
        {
            try
            {
                _context.Update(updated);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool Remove(TEntity remove)
        {
            throw new NotImplementedException();
        }

        public async void SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                {
                    throw;
                }
            }
        }

        public bool Exists(object id)
        {
            return Get(id) != null;
        }


        public async Task<bool> UpdateAsync(TEntity updated)
        {
            try
            {
                _context.Update(updated);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        bool IRepository<TEntity>.Update(TEntity updated)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(m => m.Id == Id);
                             
                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

    }
}

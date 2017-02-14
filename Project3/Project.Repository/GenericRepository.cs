using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common;
using Project.Model.Common;
using Project.DAL;
using System.Data.Entity;
using System.Collections;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Migrations;
using System.Data.Entity.Core;

namespace Project.Repository
{
    public class GenericRepository:IGenericRepository
    {
        private IVehicleContext _context;
        
        public GenericRepository(IVehicleContext context)
        {
            _context = context;
           
        }

        public async Task<int> AddAsync<T>(T entity) where T:class
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(Guid id)where T:class
        {
            T entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int>DeleteAllAsync<T>(IEnumerable<T> entity)where T:class
        {
            foreach(var en in entity)
            {
                _context.Set<T>().Remove(en);
                //return await _context.SaveChangesAsync();
            }
            return await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<T>> GetAllAsync<T>() where T:class
        {
           return await _context.Set<T>().ToListAsync();
        }
        public IQueryable<T> GetQueryable<T>() where T:class 
        {
            return _context.Set<T>();
        }
        public async Task<int>UpdateAsync<T>(T entity)where T:class
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();

        }
       

        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            var entity = _context.Set<T>().FindAsync(id);
            //return await _context.SaveChangesAsync();
            return await entity;
        }
    }
}

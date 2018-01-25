﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace Project.DAL
{
    public interface IVehicleContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}

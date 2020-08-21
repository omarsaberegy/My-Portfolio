using Core.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    public class GenericUnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private IGenericRepository<T> entity;

        public GenericUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<T> Entity
        {
            get
            {
                return entity ?? (entity = new GenericRepository<T>(_dbContext));
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

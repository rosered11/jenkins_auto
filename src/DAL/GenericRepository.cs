using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DemoApp.DAL
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly DbContext context;
        private readonly DbSet<Entity> dbSet;

        public GenericRepository(DbContext context){
            this.context = context;
            this.dbSet = context.Set<Entity>();
        }

        public IEnumerable<Entity> getData(Expression<Func<Entity, bool>> filter)
        {
            try{
                return queryData(filter);
            }
            catch(Exception exception){
                Log.Error(exception,"The generic repository is exception.");
            }
            return new List<Entity>();
        }
        private IEnumerable<Entity> queryData(Expression<Func<Entity, bool>> filter){
            IQueryable<Entity> query = dbSet;
            if(filter != null){
                query = query.Where(filter);
            }
            return query.ToList();
        }
        public void insertEntity(Entity data){
            dbSet.Add(data);
        }
    }
}
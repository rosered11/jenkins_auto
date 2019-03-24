using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoApp.DAL
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> getData(Expression<Func<Entity, bool>> filter = null);
        void insertEntity(Entity data);
    }
}
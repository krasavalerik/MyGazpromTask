using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ModelsClassLibrary.Data;

namespace ModelsClassLibrary.Repositorys
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext Context;

        public Repository(ApplicationContext context){
            Context = context;
        }
        public void Add(TEntity entity){
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities){
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity){
            Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entitys){
            Context.Set<TEntity>().RemoveRange(entitys);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate){
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(long id){
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(){
            return Context.Set<TEntity>().ToList();
        }
    }
}

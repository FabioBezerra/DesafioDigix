using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Desafio.Infra.MockedData.Context
{
    public class BaseRepository<TId, TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Adicionar(TEntity obj) => _dbSet.Add(obj);

        public void Atualizar(TEntity obj) => _dbSet.Update(obj);

        public void Remover(TEntity obj) => _dbSet.Remove(obj);

        public IEnumerable<TEntity> BuscarComExpression(Expression<Func<TEntity, bool>> predicate) =>
            _dbSet.Where(predicate);

        public IEnumerable<TEntity> Buscar() => _dbSet;

        public TEntity BuscarPorId(TId id) => _dbSet.Find(id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Desafio.Domain.FamiliaDomain.Interfaces.Repository
{
    public interface IFamiliaRepository
    {
        public void Adicionar(Familia obj);

        public void Atualizar(Familia obj);

        public void Remover(Familia obj);

        public IEnumerable<Familia> BuscarComExpression(Expression<Func<Familia, bool>> predicate);

        public IEnumerable<Familia> Buscar();

        public Familia BuscarPorId(string id);
    }
}

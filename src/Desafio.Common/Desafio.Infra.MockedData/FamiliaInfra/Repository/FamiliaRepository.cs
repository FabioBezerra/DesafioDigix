using Desafio.Domain.FamiliaDomain;
using Desafio.Domain.FamiliaDomain.Interfaces.Repository;
using Desafio.Infra.MockedData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Desafio.Infra.MockedData.FamiliaInfra.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly DesafioDbContext _context;

        public FamiliaRepository(DesafioDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Familia obj) => _context.Set<Familia>().Add(obj);

        public void Atualizar(Familia obj) => _context.Set<Familia>().Update(obj);

        public void Remover(Familia obj) => _context.Set<Familia>().Remove(obj);

        public IEnumerable<Familia> BuscarComExpression(Expression<Func<Familia, bool>> predicate) =>
            _context.Set<Familia>().Where(predicate);

        public IEnumerable<Familia> Buscar() => _context.Set<Familia>();

        public Familia BuscarPorId(string id) => _context.Set<Familia>().Find(id);
    }
}

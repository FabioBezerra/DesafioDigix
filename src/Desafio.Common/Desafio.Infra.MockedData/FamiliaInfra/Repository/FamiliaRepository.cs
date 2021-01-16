using Desafio.Domain.FamiliaDomain;
using Desafio.Infra.MockedData.Context;

namespace Desafio.Infra.MockedData.FamiliaInfra.Repository
{
    public class FamiliaRepository : BaseRepository<string, Familia>
    {

        public FamiliaRepository(DesafioDbContext context) : base(context)
        {
        }
    }
}

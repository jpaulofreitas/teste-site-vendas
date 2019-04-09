using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;

namespace Aula.Store.Data.EF.Respositories
{
    public class TipoDeProdutoRepositoryEF : RepositoryEF<TipoDeProduto>, ITipoDeProdutoRepository
    {
        public TipoDeProdutoRepositoryEF(Aula2StoreDataContextEF ctx) : base(ctx) { }
    }
}

using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Aula.Store.Data.EF.Respositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(Aula2StoreDataContextEF ctx) : base(ctx) { }

        //metodo para buscar um nome espefico de algum produto
        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            //where porque eu quero um conjunto de produtos com o nome especifico
            return _ctx.Produtos.Where(prod => prod.Nome.Contains(contains));

            //o mesmo que...
            //from p in _ctx.Produtos
            //where p.Nome.Contains(contains)
            //select p;
        }
    }
}
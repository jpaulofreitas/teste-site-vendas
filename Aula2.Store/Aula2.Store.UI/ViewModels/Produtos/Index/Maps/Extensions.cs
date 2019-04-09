using Aula2.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Aula2.Store.UI.ViewModels.Produtos.Index.Maps
{
    public static class Extensions
    {
        //static por ser extensão, IEnumerable por ser uma lista do ProdutoIndexVM, nome para index esta extensão, this por ser extensão, vai receber uma lista de produto para fazer o casting 
        public static IEnumerable<ProdutoIndexVM> ToProdutoIndexVM(this IEnumerable<Produto> data)
        {
            return data.Select(p => new ProdutoIndexVM()
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Quantidade = p.Quantidade,
                Tipo = p.TipoDeProduto.Nome,
                DataCadastro = p.DataCadastro
            }); //buscar lista de produtos         
        }
         
    }
}

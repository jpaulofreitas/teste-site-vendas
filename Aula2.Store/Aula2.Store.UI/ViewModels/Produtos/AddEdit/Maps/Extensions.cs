using Aula2.Store.Domain.Entities;

namespace Aula2.Store.UI.ViewModels.Produtos.AddEdit.Maps
{
    public static class Extensions
    {        
        public static ProdutoAddEditVM ToProdutoAddEditVM (this Produto model)
        {
            return new ProdutoAddEditVM()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                Quantidade = model.Quantidade,
                TipoDeProdutoId = model.TipoDeProdutoId,
                DataCadastro = model.DataCadastro
            };
        }
        public static Produto ToProduto(this ProdutoAddEditVM model)
        {
            return new Produto()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                Quantidade = model.Quantidade,
                TipoDeProdutoId = model.TipoDeProdutoId,
                DataCadastro = model.DataCadastro
            };
        }
    }
}

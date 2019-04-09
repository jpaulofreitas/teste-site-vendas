using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;
using Aula2.Store.UI.Controllers;
using Aula2.Store.UI.ViewModels.Produtos.Index;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aula2.Store.Tests.UI.Controllers
{
    public class ProdutosControllerTest
    {
        [TestMethod]
        public void IndexDeveRetornarViewComModeloCorreto()
        {
            //arrange
            var produtosController = new ProdutosController(new ProdutoRepositoryFake(), new TipoDeProdutoRepositoryFake());

            //act
            var result = produtosController.Index();
            var model = result.Model as IEnumerable < ProdutoIndexVM >;

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            //teste para verificar se possui mesmo 3 registros
            Assert.AreEqual(3, model.Count());
            //teste para verificar se a lista do model nao esta vazia 
            Assert.IsNotNull(model);
        }
    }

    public class ProdutoRepositoryFake : IProdutoRepository
    {
        public void Add(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            var tipo1 = new TipoDeProduto() { Id = 1, Nome = "tipo 1" };
            var tipo2 = new TipoDeProduto() { Id = 2, Nome = "tipo 2" };
            return new List<Produto>()
            {
                new Produto(){  Id = 1 ,
                                Nome = "Produto teste 1" ,
                                TipoDeProdutoId = tipo1.Id,
                                TipoDeProduto = tipo1,
                                Preco = 5 ,
                                Quantidade = 65 },

                new Produto(){  Id = 2 ,
                                Nome = "Produto teste 2" ,
                                TipoDeProdutoId = tipo2.Id,
                                TipoDeProduto = tipo2,
                                Preco = 98 ,
                                Quantidade = 34 },

                new Produto(){  Id = 3 ,
                                Nome = "Produto teste 3" ,
                                TipoDeProdutoId = tipo1.Id,
                                TipoDeProduto = tipo1,
                                Preco = 33 ,
                                Quantidade = 66 },
            };
        }

        public Produto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            throw new System.NotImplementedException();
        }
    }
    public class TipoDeProdutoRepositoryFake : ITipoDeProdutoRepository
    {
        public void Add(TipoDeProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TipoDeProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Edit(TipoDeProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TipoDeProduto> Get()
        {
            throw new System.NotImplementedException();
        }

        public TipoDeProduto Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

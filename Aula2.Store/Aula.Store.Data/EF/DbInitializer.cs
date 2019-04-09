using Aula2.Store.Domain.Entities;
using Aula2.Store.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Store.Data.EF
{
    internal class DbInitializer : CreateDatabaseIfNotExists<Aula2StoreDataContextEF>
    {
        //método protect pq só quem herda CreateDatabaseIfNotExists, virtual pq pode sobrescrever, Seed pq sera acessado sempre que a DB for criada
        protected override void Seed(Aula2StoreDataContextEF context)
        {
            var alimento = new TipoDeProduto() { Nome = "Alimento" };
            var higiene = new TipoDeProduto() { Nome = "Higiene" };
            var tecnologia = new TipoDeProduto() { Nome = "Tecnologia" };
            var bebidas = new TipoDeProduto() { Nome = "Bebidas" };
            var limpeza = new TipoDeProduto() { Nome = "Limpeza" };

            var produtos = new List<Produto>() {
                new Produto() {Nome = "Detergente", Preco = 2.34M , TipoDeProduto = limpeza , Quantidade = 12 },
                new Produto() {Nome = "Lasanha", Preco = 8.34M , TipoDeProduto = alimento , Quantidade = 37 },
                new Produto() {Nome = "Skol", Preco = 9.85M , TipoDeProduto = bebidas , Quantidade = 69 },
                new Produto() {Nome = "Chocolate", Preco = 1.85M , TipoDeProduto = alimento , Quantidade = 56 },
                new Produto() {Nome = "Sabão", Preco = 8.92M , TipoDeProduto = higiene , Quantidade = 25 },
                new Produto() {Nome = "Sabonete", Preco = 8.17M , TipoDeProduto = higiene , Quantidade = 78 },
                new Produto() {Nome = "Celular", Preco = 2365.48M , TipoDeProduto = tecnologia , Quantidade = 85 },
                new Produto() {Nome = "Mouse", Preco = 3.5M , TipoDeProduto = tecnologia , Quantidade = 76 },
            };
            //passar para o contexto que sera criado uma lista (AddRange) do metodo Produto 
            context.Produtos.AddRange(produtos);

            context.Usuarios.Add(new Usuario()
            {
                Nome = "Paulo Freitas",
                Email = "teste@teste.com",
                Senha = "123".Encrypt()
            });

            context.SaveChanges();
        }
    }
}

using Aula2.Store.Domain.Entities;
using System.Data.Entity;

namespace Aula.Store.Data.EF
{
    public class Aula2StoreDataContextEF : DbContext
    {
        //abrir o SQL Server Object Explorer, sobre o System Databases/master clicar em Propriedades e selecionar a opção Connection String, copiar a mesma e colar na base()
        //não é recomendavel manter a string de conexao aqui, mas sim em Web.Config
        //StoreConn é o mesmo nome da string de conexao que esta no Web.Config
        public Aula2StoreDataContextEF() : base("StoreConn")
        {
            //o proprio Entity cria uma database quando nao tem , o metodo abaixo é para controlar essa criação de uma nova Database
            //DbInitializer é um nome padrao mas pode ser qq um / clicar sobre  gerar class
            Database.SetInitializer(new DbInitializer());
        }
        //mapeamento do DB /dbset é um generico onde um objeto recebe outro e adapta seus metodos para manipular as caracteristicas
        //Produto é uma coleção da classe e Produtos é um objeto que vai manipular a coleção Produto 
        public DbSet<Produto> Produtos { get; set; }

        //esse dbset para poder criar o contexto de produtos 
        public DbSet<TipoDeProduto> TipoDeProdutos { get; set; }

        //para criar a tabela de usuarios 
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Maps.ProdutoMap());
            modelBuilder.Configurations.Add(new Maps.TipoDeProdutoMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
        }
    }
}

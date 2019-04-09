using Aula2.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aula.Store.Data.EF.Maps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
         public ProdutoMap()
        {
            //nome da tabela
            ToTable(nameof(Produto));//insere o nome da tabela

            //criando o PK. Os dados enviados a esse PK refere-se a tabela Produto
            HasKey(pk=>pk.Id);

            //configurando colunas... hasdata: fornece informação quando o registro é criado:identity (automatico)
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasColumnType("varchar")
                                 .HasMaxLength(100)
                                 .IsRequired();
            Property(c => c.Preco).HasColumnType("money");
            Property(c => c.Quantidade).HasColumnName("Quantidade");
            Property(c => c.TipoDeProdutoId);
            Property(c => c.DataCadastro);

            //relacionamento das tablemas de produto e tipo de produto
            //para importar o campo de relacionamento Wihti many é 1->n - IColletions para chegar ate essa relação
            HasRequired(prod => prod.TipoDeProduto).WithMany(tipo => tipo.Produtos)
                                    .HasForeignKey(fk => fk.TipoDeProdutoId); //selecionando qual chave estrangeira sera usada
        }
    }
}

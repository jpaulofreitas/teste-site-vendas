using Aula2.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Aula.Store.Data.EF.Maps
{
    public class UsuarioMap:EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Nome da tabela
            ToTable(nameof(Usuario));

            //Chave Primaria
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome).HasColumnType("varchar")
                                 .HasMaxLength(100)
                                 .IsRequired();
            
            Property(c => c.Email).HasColumnType("varchar")
                                 .HasMaxLength(80)
                                 .IsRequired()
                                 .HasColumnAnnotation(
                                    IndexAnnotation.AnnotationName,
                                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Usuario.Email") { IsUnique=true}))
                                 ;

            //a senha gerada pelo frame utilizado, utilizada a criptografia fixa de 88 caracteres, para economizar memoria, utilozou-se char 88
            Property(c => c.Senha).HasColumnType("char")
                                 .HasMaxLength(88)
                                 .IsRequired();

            Property(c => c.DataCadastro);
        }
    }
}

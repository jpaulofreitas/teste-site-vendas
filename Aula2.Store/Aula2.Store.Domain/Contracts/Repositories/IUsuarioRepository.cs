using Aula2.Store.Domain.Entities;

namespace Aula2.Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        //Como não tem um metodo que possa fazer a validação do usuario de forma generica no IRepository, necessario criar um novo
        Usuario Get(string email);
    }
}

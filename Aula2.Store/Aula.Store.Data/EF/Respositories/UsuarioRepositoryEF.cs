using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;
using System.Linq;

namespace Aula.Store.Data.EF.Respositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(Aula2StoreDataContextEF ctx) : base(ctx) { }

        public Usuario Get(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(user => user.Email.ToLower() == email.ToLower());
        }
    }
}

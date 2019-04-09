using Aula2.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //Get... é uma nome generico para determinar o que queremos que o metodo faça
        IEnumerable<Produto> GetByNameContains(string contains);
    }
}

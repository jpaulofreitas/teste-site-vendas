using System.Collections.Generic;

namespace Aula2.Store.Domain.Entities
{
    public class TipoDeProduto : Entity
    {
        public string Nome { get; set; }

        //virtual tempo de execução para substituir a lista da outra tabela IColetion é uma lista (List<>) para utilizar a lista da outra tabela Produto e efetuar a navegação entre as tabelas
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}

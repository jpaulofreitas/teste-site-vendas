using System;

namespace Aula2.Store.Domain.Entities
{
    public class Entity
    {        
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}

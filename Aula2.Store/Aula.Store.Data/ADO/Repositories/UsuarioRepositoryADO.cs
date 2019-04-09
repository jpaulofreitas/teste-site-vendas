using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula.Store.Data.ADO.Repositories
{
    public class UsuarioRepositoryADO : IUsuarioRepository
    {
        //metado gerado somente leitura de _ctx
        private readonly Aula2StoreDataContextADO _ctx;

        //receber o datareader, criando a instancia dele pela injeção de dependencia
        public UsuarioRepositoryADO(Aula2StoreDataContextADO ctx)
        {
            _ctx = ctx;
        }

        public Usuario Get(string email)
        {
            //$ iterpolação de string
            var query = $@"SELECT u.Id, u.Nome, u.Email, u.Senha, u.DataCadastro
                          FROM Usuario u
                          WHERE Email = '{email}'";

            var dR = _ctx.ExecuteCommandData( query);

            //se possou alguma linha
            if (dR.HasRows)
            {
                var usuarios = new List<Usuario>(); 

                //enquanto o data reader puder ser lido
                while (dR.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        Id = (int)dR["Id"],
                        Nome = dR["Nome"].ToString(),
                        Email = dR["Email"].ToString(),
                        Senha = dR["Senha"].ToString(),
                        DataCadastro = (DateTime)dR["DataCadastro"]
                    });
                }
                dR.Close();

                return usuarios.First();
            }

            return null;
        }

        public void Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose() {}

        public void Edit(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Get()
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

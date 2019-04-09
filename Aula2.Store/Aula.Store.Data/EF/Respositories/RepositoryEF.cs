using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula.Store.Data.EF.Respositories
{
    //adequar a classe para receber o nome de acordo com o tipo de tecnologia
    public class RepositoryEF<T> : IDisposable, IRepository<T> where T : Entity
    {
        //criando uma instancia do DataContext
        //private pois so interessa a essa classe
        //protected os metodos desta função podem ser utilizados nesta classe e nas que a herdarem
        //readonly para ser instanciado somente uma vez ou so no contrutor
        //o nome com underline pois e uma variavel privada
        //instanciando a injeção de dependencia no Context
        protected readonly Aula2StoreDataContextEF _ctx;
        public RepositoryEF(Aula2StoreDataContextEF ctx)
        {
            _ctx = ctx;
        }

        //criando o Crud

        //lista de todos os Ts
        //IEnumerable cria uma interface de lista de dados
        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().ToList();
        }

        //metodo para lista um unico produto, buscando pela PK do T(id), find que faz a busca pelo PK na lista
        public T Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        //nao retorna nada, pois apenas add, esperar o produto e inserir o na tabela. Nome do atributo de entity
        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        //entry pega a entidade informada na base, estado dele foi modificado
        public void Edit(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        //metodo deletar
        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            Save();
        }

        //para criar os try/cath ou log direto em apenas um local. 
        private void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose() { }
    }
}

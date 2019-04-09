using Aula.Store.Data.ADO.Repositories;
using Aula.Store.Data.EF;
using Aula.Store.Data.EF.Respositories;
using Aula2.Store.Domain.Contracts.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Aula2.Store.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<Aula2StoreDataContextEF>();
            container.RegisterType<IProdutoRepository, ProdutoRepositoryEF>();
            container.RegisterType<ITipoDeProdutoRepository, TipoDeProdutoRepositoryEF>();
            container.RegisterType<IUsuarioRepository, UsuarioRepositoryEF>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
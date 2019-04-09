using Aula2.Store.Domain.Contracts.Repositories;
using Aula2.Store.Domain.Helpers;
using Aula2.Store.UI.ViewModels.Conta.Login;
using System.Web.Mvc;
using System.Web.Security;

namespace Aula2.Store.UI.Controllers
{
    public class ContaController:Controller
    {
        private readonly IUsuarioRepository _usuarioRepository ;

        public ContaController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Login(string returnURL)//returnURL vai armazenar a URL do meu login
        {
            //model recebe da View LoginVm o ReturnUrl que que recebe do returnURL informada no URL da View
            var model = new LoginVM() { ReturnUrl = returnURL };
            return View(model);
        }

        //metodo para realizar a autentica com os dados recebidos
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var usuario = _usuarioRepository.Get(model.Email); 

            if (usuario==null)
            {
                //informando que este erroesta selecionando qual a chave que esta errado, o helper vai mostrar no email. Sem a chave mostra no Sumary
                ModelState.AddModelError("Email", "Usuario nao localizado!");
            }
            else
            {
                if (usuario.Senha != model.Senha.Encrypt())
                {
                    ModelState.AddModelError("Senha", "Senha invalida!");
                }
            }
            if (ModelState.IsValid)
            {
                //informa que o usuario esta autenticado. Cookie informa ao servidor que o usuario esta autenticado
                //neste metodo, primeiro informo o key que sera usado para autenticação, segundo um metodo bool para verificar a persistencia do cookie
                FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                //é necessario redirecionar o para o model Url
                //se nao veio nulo ou vazio no ReturnUrl (ou seja contem algum ReturnUrl
                //e ele o islcoalurl verifica se o ReturnUrl recebido é realmente da URL local do meu site
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                //se não, o redirect envia para a index
                return RedirectToAction("Index", "Home");
            }
            //retorna para a propria View
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing) { }
    }
}

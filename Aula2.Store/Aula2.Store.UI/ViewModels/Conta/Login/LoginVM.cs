using System.ComponentModel.DataAnnotations;

namespace Aula2.Store.UI.ViewModels.Conta.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [StringLength(80, ErrorMessage = "O limite de caracteres do {0} foi excedido, limite de {1} caracteres.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A {0} é obrigátória!")]
        [StringLength(20, ErrorMessage = "O limite excedido de {1} caracteres")]
        public string Senha { get; set; }

        //é possivel alterar o tempo logado dentro do WebConfig dentro do Forms
        public bool PermanecerLogado { get; set; }

        //retorno da pagina caso nao autenticado. o mesmo do URL do erro
        public string ReturnUrl { get; set; }
    }
}

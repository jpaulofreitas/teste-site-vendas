namespace Aula2.Store.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        //Colunas do tipo numeral sao automaticamente not null
        public short Quantidade { get; set; }

        //chave estrageira
        public int TipoDeProdutoId { get; set; }

        //campo de navegação para ligar a outra tabela
        public virtual TipoDeProduto TipoDeProduto { get; set; }
    }
}

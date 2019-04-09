using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Aula.Store.Data.ADO
{
    //Disposable, quando necessitar deste metodo, inicia a conexao com o banco, quando não precisar, a conexao é fechada
    public class Aula2StoreDataContextADO : IDisposable 
    {
        //gerado o para que nao seja instaciado novamente nesta classe e ser gerado como field para nao ser uma propriedade
        private readonly SqlConnection _conn;
        public Aula2StoreDataContextADO()
        {
            //criar a variavel para receber a String de conexao. Chamo o Nuget que fara a configuração da String.Chamo o seu metodo [informo o nome da string de conexao que esta em Web.Config].Insro a propriedade da mesma
            var connString = ConfigurationManager.ConnectionStrings["StoreConn"].ConnectionString;
            //propriedade de conexao = instaciar o metodo ADO para fazer a conexao (inserir a variavel de conexao)
            _conn = new SqlConnection(connString);
            //abrir a conexao
            _conn.Open();
        }

        //metodo que insere um insert. uMA INSTRUÇÃO SQL
        public void ExecuteCommmand(string sql)
        {
            //INSERIR ALGUMAS COMANDOS DE CONFIGURAÇÃO
            var command = new SqlCommand()
            {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text,
                Connection = _conn
            };
            command.ExecuteNonQuery();
        }

        //Executar query no banco. Retornar a consulta para quem solicita
        //utilizado para pegar informar e manipular aqui dentro
        public SqlDataReader ExecuteCommandData(string query)
        {
            var command = new SqlCommand(query, _conn);
            return command.ExecuteReader();
        }
        
        public void Dispose()
        {
            //verifica se o status da conexao encontra-se aberto
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Repositories.Connection
{
    public class Conexao
    {
        public static SqlConnection SQLServerConexao()
        {
            return new SqlConnection(Configuracao.Configuration["ConnectionStrings:ConexaoSQLServer"]);
        }
    }
}

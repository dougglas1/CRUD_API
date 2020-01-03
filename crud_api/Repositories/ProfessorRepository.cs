using crud_api.Model;
using crud_api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace crud_api.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly SqlConnection conexao;
        private readonly SqlTransaction transacao;

        public ProfessorRepository(SqlConnection conexao, SqlTransaction transacao)
        {
            this.conexao = conexao;
            this.transacao = transacao;
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            string sql = @"SELECT * FROM PROFESSOR";

            return conexao.Query<ProfessorModel>(sql, transaction: transacao).ToList();
        }

        public ProfessorModel BuscarProfessorPorID(int ID)
        {
            string sql = @"SELECT * FROM PROFESSOR WHERE ID = @ID";

            return conexao.Query<ProfessorModel>(sql, param: new { ID = ID }, transaction: transacao).FirstOrDefault();
        }

        public void AdicionarProfessor(ProfessorModel professor)
        {
            string sql = @"INSERT INTO PROFESSOR (NOME) VALUES (@Nome)";

            conexao.Query<ProfessorModel>(sql, param: professor, transaction: transacao);
        }

        public void AtualizarProfessor(ProfessorModel professor)
        {
            string sql = @"UPDATE PROFESSOR SET NOME = @Nome WHERE ID = @ID";

            conexao.Query<ProfessorModel>(sql, param: professor, transaction: transacao);
        }

        public void RemoverProfessor(int ID)
        {
            string sql = @"DELETE FROM PROFESSOR WHERE ID = @ID";

            conexao.Query<ProfessorModel>(sql, param: new { ID = ID }, transaction: transacao);
        }
    }
}

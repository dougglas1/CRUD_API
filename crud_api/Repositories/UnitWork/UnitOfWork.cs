using crud_api.Enumerador;
using crud_api.Repositories.Connection;
using crud_api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Repositories.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _conexaoSQLServer;
        private SqlTransaction _transacaoSQLServer;

        private IProfessorRepository _professorrepository;

        /// <summary>
        /// Construtor
        /// </summary>
        public UnitOfWork()
        {
            _conexaoSQLServer = Conexao.SQLServerConexao();
        }

        #region Connection

        public void Open(EBancoDados bd)
        {
            switch (bd)
            {
                case EBancoDados.SQL_SERVER:
                    if (_conexaoSQLServer.State.Equals(ConnectionState.Closed))
                        _conexaoSQLServer.Open();
                    break;
                default:
                    break;
            }
        }

        public void Close(EBancoDados bd)
        {
            switch (bd)
            {
                case EBancoDados.SQL_SERVER:
                    if (!_conexaoSQLServer.State.Equals(ConnectionState.Closed))
                        _conexaoSQLServer.Close();
                    if (_transacaoSQLServer != null)
                        _transacaoSQLServer = null;
                    break;
                default:
                    break;
            }
        }

        public void Begin(EBancoDados bd)
        {
            switch (bd)
            {
                case EBancoDados.SQL_SERVER:
                    if (_transacaoSQLServer == null)
                        _transacaoSQLServer = _conexaoSQLServer.BeginTransaction();
                    break;
                default:
                    break;
            }
        }

        public void Commit(EBancoDados bd)
        {
            switch (bd)
            {
                case EBancoDados.SQL_SERVER:
                    try
                    {
                        _transacaoSQLServer.Commit();
                    }
                    catch
                    {
                        _transacaoSQLServer.Rollback();
                        throw;
                    }
                    finally
                    {
                        _transacaoSQLServer.Dispose();
                        _transacaoSQLServer = null;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Rollback(EBancoDados bd)
        {
            switch (bd)
            {
                case EBancoDados.SQL_SERVER:
                    if (_transacaoSQLServer != null)
                    {
                        _transacaoSQLServer.Rollback();
                        _transacaoSQLServer = null;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        public IProfessorRepository ProfessorRepository
        {
            get
            {
                _professorrepository = new ProfessorRepository(_conexaoSQLServer, _transacaoSQLServer);
                return _professorrepository;
            }
        }
    }
}

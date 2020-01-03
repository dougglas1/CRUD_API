using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_api.Enumerador;
using crud_api.Model;
using crud_api.Repositories.UnitWork;

namespace crud_api.Service
{
    public class ProfessorService
    {
        private IUnitOfWork _unitOfWork;

        public ProfessorService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            try
            {
                _unitOfWork.Open(EBancoDados.SQL_SERVER);
                _unitOfWork.Begin(EBancoDados.SQL_SERVER);

                List<ProfessorModel> professores = _unitOfWork.ProfessorRepository.BuscarProfessores();

                _unitOfWork.Commit(EBancoDados.SQL_SERVER);

                return professores;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(EBancoDados.SQL_SERVER);
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
                throw new Exception(ex.Message);
            }
            finally
            {
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
            }
        }

        public ProfessorModel BuscarProfessorPorID(int ID)
        {
            try
            {
                _unitOfWork.Open(EBancoDados.SQL_SERVER);
                _unitOfWork.Begin(EBancoDados.SQL_SERVER);

                ProfessorModel professor = _unitOfWork.ProfessorRepository.BuscarProfessorPorID(ID);

                _unitOfWork.Commit(EBancoDados.SQL_SERVER);

                return professor;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(EBancoDados.SQL_SERVER);
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
                throw new Exception(ex.Message);
            }
            finally
            {
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
            }
        }

        public void AdicionarProfessor(ProfessorModel professor)
        {
            try
            {
                _unitOfWork.Open(EBancoDados.SQL_SERVER);
                _unitOfWork.Begin(EBancoDados.SQL_SERVER);

                _unitOfWork.ProfessorRepository.AdicionarProfessor(professor);

                _unitOfWork.Commit(EBancoDados.SQL_SERVER);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(EBancoDados.SQL_SERVER);
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
                throw new Exception(ex.Message);
            }
            finally
            {
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
            }
        }

        public void AtualizarProfessor(ProfessorModel professor)
        {
            try
            {
                _unitOfWork.Open(EBancoDados.SQL_SERVER);
                _unitOfWork.Begin(EBancoDados.SQL_SERVER);

                _unitOfWork.ProfessorRepository.AtualizarProfessor(professor);

                _unitOfWork.Commit(EBancoDados.SQL_SERVER);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(EBancoDados.SQL_SERVER);
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
                throw new Exception(ex.Message);
            }
            finally
            {
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
            }
        }

        public void RemoverProfessor(int ID)
        {
            try
            {
                _unitOfWork.Open(EBancoDados.SQL_SERVER);
                _unitOfWork.Begin(EBancoDados.SQL_SERVER);

                _unitOfWork.ProfessorRepository.RemoverProfessor(ID);

                _unitOfWork.Commit(EBancoDados.SQL_SERVER);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(EBancoDados.SQL_SERVER);
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
                throw new Exception(ex.Message);
            }
            finally
            {
                _unitOfWork.Close(EBancoDados.SQL_SERVER);
            }
        }
    }
}

using crud_api.Enumerador;
using crud_api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Repositories.UnitWork
{
    public interface IUnitOfWork
    {
        void Open(EBancoDados bd);
        void Close(EBancoDados bd);
        void Begin(EBancoDados bd);
        void Commit(EBancoDados bd);
        void Rollback(EBancoDados bd);

        IProfessorRepository ProfessorRepository { get; }
    }
}

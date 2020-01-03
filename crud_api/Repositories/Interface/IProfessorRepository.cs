using crud_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Repositories.Interface
{
    public interface IProfessorRepository
    {
        List<ProfessorModel> BuscarProfessores();
        ProfessorModel BuscarProfessorPorID(int iD);
        void AdicionarProfessor(ProfessorModel professor);
        void AtualizarProfessor(ProfessorModel professor);
        void RemoverProfessor(int iD);
    }
}

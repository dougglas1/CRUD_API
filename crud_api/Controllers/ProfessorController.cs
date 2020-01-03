using crud_api.Model;
using crud_api.Repositories.UnitWork;
using crud_api.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        /// <summary>
        /// Buscar Professores
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> BuscarProfessores([FromServices]IUnitOfWork _unitOfWork)
        {
            try
            {
                List<ProfessorModel> professores = new ProfessorService(_unitOfWork).BuscarProfessores();
                if (professores == null || professores.Count.Equals(0))
                    return NotFound("Nenhum Registro Encontrado");

                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Buscar Professor por ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> BuscarProfessorPorID([FromServices]IUnitOfWork _unitOfWork, int ID)
        {
            try
            {
                ProfessorModel professor = new ProfessorService(_unitOfWork).BuscarProfessorPorID(ID);
                if (professor == null)
                    return NotFound("Nenhum Registro Encontrado");

                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adicionar Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> AdicionarProfessor([FromServices]IUnitOfWork _unitOfWork, [FromQuery] ProfessorModel professor)
        {
            try
            {
                if (professor == null)
                    return NotFound("Parâmetros inválidos");

                new ProfessorService(_unitOfWork).AdicionarProfessor(professor);

                return Ok("Adicionado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        /// <summary>
        /// Atualizar Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> AtualizarProfessor([FromServices]IUnitOfWork _unitOfWork, [FromQuery] ProfessorModel professor)
        {
            try
            {
                if (professor == null)
                    return NotFound("Parâmetros inválidos");

                new ProfessorService(_unitOfWork).AtualizarProfessor(professor);

                return Ok("Atualizado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Remover Professor
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoverProfessor([FromServices]IUnitOfWork _unitOfWork, int ID)
        {
            try
            {
                new ProfessorService(_unitOfWork).RemoverProfessor(ID);

                return Ok("Removido com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}

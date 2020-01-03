using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_api.Model
{
    public class ProfessorModel
    {
        /// <summary>
        /// Chave Tabela
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome Professor
        /// </summary>
        /// 
        [Required]
        public string Nome { get; set; }
    }
}

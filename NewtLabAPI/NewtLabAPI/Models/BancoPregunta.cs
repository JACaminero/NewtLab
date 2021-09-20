using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class BancoPregunta
    {
        public int BancoPreguntaId { get; set; }
        public string Tema { get; set; }
        public string FechaCreacion{ get; set; }
        public int ExperimentoId { get; set; }
        public Experimento Experimento { get; set; }
    }
}

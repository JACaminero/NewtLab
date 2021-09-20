using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class Respuesta
    {
        public int RespuestaId { get; set; }
        public Pregunta Pregunta { get; set; }
        public string Descripcion { get; set; }
        public int Puntuacion { get; set; }
    }
}

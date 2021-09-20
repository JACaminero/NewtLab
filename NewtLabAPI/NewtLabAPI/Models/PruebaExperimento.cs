﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class PruebaExperimento
    {
        public int PruebaExperimentoId { get; set; }
        public User User { get; set; }
        public BancoPregunta BancoPregunta { get; set; }
        public DateTime FechaTomado { get; set; }
        public int CalificacionObtenida { get; set; }
    }
}

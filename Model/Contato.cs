﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remeberme.Model
{
    public class Contato
    {

        public Contato()
        {
            this.Nome = "Eduardo";
        }
        public  Guid Id{ get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public DateTime DataDeNascimento { get; set; }
    }
}
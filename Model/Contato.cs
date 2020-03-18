using System;
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
            this.Endereco = "Rua Manoel Teodoro n 90 apto 501";
            this.DataDeNascimento = new DateTime(1983, 01, 10);
        }
        public  Guid Id{ get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public DateTime DataDeNascimento { get; set; }
    }
}

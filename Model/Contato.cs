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
            this.Localizacao = new Localizacao();
            this.DataDeNascimento = new DateTime(1950, 01, 01);
        }

        public  Guid Id{ get; set; }

        public string Nome { get; set; }

        public Localizacao Localizacao { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string DataDeCadastro { get; set; }
    }
}

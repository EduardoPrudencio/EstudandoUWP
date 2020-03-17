using Remeberme.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remeberme.ViewModel
{
    public class NewContatoViewModel : ViewModelBase
    {
        Contato contato;

        private string _nome = "Eduardo";
        public NewContatoViewModel()
        {
            if (contato == null) contato = new Contato();
        }

        public string ContatoNome
        {
            get { return contato.Nome; }
            set { ContatoNome = value; OnPropertyChanged("ContatoNome"); }
        }

    }
}

using Remeberme.DataAccess;
using Remeberme.Model;
using Remeberme.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remeberme.ViewModel
{
    public class ContatosViewModel : ViewModelBase
    {
        ObservableCollection<NewContatoViewModel> ListaDeContatos = new ObservableCollection<NewContatoViewModel>();

        public ContatosViewModel()
        {
            ConverterToViewModel();
        }

        public ObservableCollection<NewContatoViewModel> Contatos
        {
            get {  return ListaDeContatos; }
            set {OnPropertyChanged("Contatos"); }
        }

        private void ConverterToViewModel() 
        {
            foreach (var cont in DataManager.Instance.Contatos)
            {
                NewContatoViewModel c = new NewContatoViewModel
                {
                    Nome = cont.Nome,
                    DataDeNascimento = cont.DataDeNascimento,
                    Bairro = cont.Localizacao.Bairro,
                };

                ListaDeContatos.Add(c);
            }
            
        }
    }
}

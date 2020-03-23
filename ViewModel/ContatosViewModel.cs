using Remeberme.Commands;
using Remeberme.DataAccess;
using Remeberme.Model;
using Remeberme.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remeberme.ViewModel
{
    public class ContatosViewModel : ViewModelBase
    {

        ObservableCollection<NewContatoViewModel> ListaDeContatos;
        public ContatosViewModel()
        {
            var list = DataManager.Instance.Contatos.Select(x => ConverterToViewModel(x)).ToList();
            ListaDeContatos = new ObservableCollection<NewContatoViewModel>(list);
        }

        public ObservableCollection<NewContatoViewModel> Contatos
        {
            get {  return ListaDeContatos; }
            set {OnPropertyChanged("Contatos"); }
        }

        private NewContatoViewModel _itemListViewSelected;
        public NewContatoViewModel ItemListViewSelected
        {
            get => _itemListViewSelected;
            set
            {
                _itemListViewSelected = value;
                OnPropertyChanged("ItemListViewSelected");
            }
        }

        private NewContatoViewModel ConverterToViewModel(Contato cont) 
        {
            return new NewContatoViewModel
            {
                Nome = cont.Nome,
                DataDeNascimento = cont.DataDeNascimento,
                Bairro = cont.Localizacao.Bairro,
            };
        }
    }
}

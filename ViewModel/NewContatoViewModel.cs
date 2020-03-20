using Remeberme.Commands;
using Remeberme.DataAccess;
using Remeberme.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Remeberme.ViewModel
{
    public class NewContatoViewModel : ViewModelBase
    {
        private Contato contato = null;

        public NewContatoViewModel()
        {
            if (contato == null) contato = new Contato();
        }

        public string Nome
        {
            get { return contato.Nome; }
            set { if (value != contato.Nome) contato.Nome = value; OnPropertyChanged("Nome"); }
        }

        public string Endereco
        {
            get { return contato.Endereco; }
            set { if (value != contato.Endereco) contato.Endereco = value; OnPropertyChanged("Endereco"); }
        }

        public DateTime DataDeNascimento
        {
            get { return contato.DataDeNascimento; }
            set { if (value != contato.DataDeNascimento) contato.DataDeNascimento = value; OnPropertyChanged("DataDeNascimento"); }
        }

        public ICommand SaveButtonClicked
        {
            get { return new DelegateCommand(FindResult); }
        }

        public async void FindResult()
        {
            DataManager.Instance.AddContato(contato);
            DataManager.Instance.SaveList();

            var dialog = new MessageDialog($"Salvando od dados de {contato.Nome}");
            await dialog.ShowAsync();

        }
    }
}

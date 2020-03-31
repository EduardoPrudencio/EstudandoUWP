using Remeberme.Commands;
using Remeberme.DataAccess;
using Remeberme.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Remeberme.ViewModel
{
    public class NewContatoViewModel : ViewModelBase
    {
        private Contato contato = null;
        private bool _salvandoDados = false;

        public NewContatoViewModel()
        {
            if (contato == null) contato = new Contato();
        }

        public bool IsActiveToSave
        {
            get { return (!string.IsNullOrWhiteSpace(contato.Nome) && (!string.IsNullOrWhiteSpace(contato.Localizacao.Endereco))); }
            set { if (value != IsActiveToSave) IsActiveToSave = value;  }
        }

        public string Id { get { return contato.Id.ToString(); }}

        public string Nome
        {
            get { return contato.Nome; }
            set { if (value != contato.Nome) contato.Nome = value; OnPropertyChanged("Nome"); OnPropertyChanged("IsActiveToSave"); }
        }

        public string Endereco
        {
            get { return contato.Localizacao.Endereco; }
            set { if (value != contato.Localizacao.Endereco) contato.Localizacao.Endereco = value; OnPropertyChanged("Endereco"); OnPropertyChanged("IsActiveToSave"); }
        }

        public string Cep
        {
            get { return contato.Localizacao.Cep; }
            set { if (value != contato.Localizacao.Cep) contato.Localizacao.Cep = value; OnPropertyChanged("Cep"); }
        }

        public int Numero
        {
            get { return contato.Localizacao.Numero; }
            set { if (value != contato.Localizacao.Numero) contato.Localizacao.Numero = value; OnPropertyChanged("Numero"); }
        }

        public string Complemento
        {
            get { return contato.Localizacao.Complemento; }
            set { if (value != contato.Localizacao.Complemento) contato.Localizacao.Complemento = value; OnPropertyChanged("Complemento"); }
        }

        public string Bairro
        {
            get { return contato.Localizacao.Bairro; }
            set { if (value != contato.Localizacao.Bairro) contato.Localizacao.Bairro = value; OnPropertyChanged("Bairro"); }
        }

        public string Cidade
        {
            get { return contato.Localizacao.Cidade; }
            set { if (value != contato.Localizacao.Cidade) contato.Localizacao.Cidade = value; OnPropertyChanged("Cidade"); }
        }

        public string Uf
        {
            get { return contato.Localizacao.Uf; }
            set { if (value != contato.Localizacao.Uf) contato.Localizacao.Uf = value; OnPropertyChanged("Uf"); }
        }

        public string Email { get { return contato.Email; } set { if (contato.Email != value) contato.Email = value; OnPropertyChanged("Email"); } }

        public bool SalvandoDados { get { return _salvandoDados; } set { if (value != _salvandoDados) _salvandoDados = value; OnPropertyChanged("SalvandoDados"); } }

        public DateTime DataDeNascimento
        {
            get { return contato.DataDeNascimento; }
            set { if (value != contato.DataDeNascimento) contato.DataDeNascimento = value; OnPropertyChanged("DataDeNascimento"); }
        }

        public ICommand SaveButtonClicked
        {
            get { return new DelegateNewContactCommand(FindResult); }
        }

        public ICommand CancelButtonClicked
        {
            get { return new DelegateNewContactCommand(ResetForm); }
        }

        public async void FindResult()
        {
            MessageDialog dialog = null;

            this.SalvandoDados = true;

            try
            {
               // Task salvandoDadosTasks = Task.Run(async () => 
              //  {
                    bool listaSalvaComSucesso = false;

                    if (DataManager.Instance.AddContato(contato))
                        listaSalvaComSucesso = DataManager.Instance.SaveList();

                    string nameToShow = contato.Nome;

                    if (listaSalvaComSucesso)
                        dialog = new MessageDialog($"Os dados de {nameToShow} foram salvos com sucesso!");
                    else
                        dialog = new MessageDialog($"Ocorreu um erro ao tentar salvar os dados de {nameToShow}.");

                    await dialog.ShowAsync();

               /// });

                //salvandoDadosTasks.Wait();

                ResetForm();
            }
            catch (Exception)
            {
                //throw;
            }

        }

        public void Convert(Contato contato)
        {
            this.contato = contato;
        }


        private void ResetForm()
        {
            this.Nome = "";
            this.Cep = "";
            this.Numero=0;
            this.Complemento= "";
            this.Endereco = "";
            this.Cidade = "";
            this.Bairro = "";
            this.Uf = "";
            this.DataDeNascimento = new DateTime(1950, 1, 1);
            this.SalvandoDados = false;

        }
    }
}

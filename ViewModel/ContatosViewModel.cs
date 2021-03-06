﻿using Remeberme.Commands;
using Remeberme.DataAccess;
using Remeberme.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Remeberme.ViewModel
{
    public class ContatosViewModel : ViewModelBase
    {
        public ObservableCollection<Contato> Contatos
        {
            get { return DataManager.Instance.Contatos; }
            set { OnPropertyChanged("Contatos"); }
        }

        private Contato _itemListViewSelected;

        public Contato ItemListViewSelected
        {
            get => _itemListViewSelected;
            set
            {
                _itemListViewSelected = value;
                OnPropertyChanged("ItemListViewSelected");
            }
        }

        public ICommand EditSelectedContactClicked
        {
            get { return new DelegateContactsCommand(EditContact); }
        }

        public ICommand DeleteSelectedContactClicked
        {
            get { return new DelegateContactsCommand(DeleteContact); }
        }

        private void EditContact()
        {
            Contato contatoEdit = DataManager.Instance.Contatos.FirstOrDefault(c => c.Id.ToString().Equals(this.ItemListViewSelected.Id.ToString()));
            Helpers.NavigationPage.Instance.GoToPage(new Helpers.NavigationEventArgs { PageToGo = "novo contato", ItemEdit = contatoEdit });
        }

        private async void DeleteContact()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Atenção",
                Content = $"Deseja mesmo excluir o contato {this.ItemListViewSelected.Nome}?",
                PrimaryButtonText = "Sim",
                SecondaryButtonText = "Não",
                CloseButtonText = "Cancelar",
            };

            var result = await dialog.ShowAsync();

            string idSelecionado = string.Empty;

            if (result == ContentDialogResult.Primary)
            {
                idSelecionado = ItemListViewSelected.Id.ToString();

                Contato contato = DataManager.Instance.Contatos.FirstOrDefault(x => x.Id.ToString().Equals(idSelecionado));

                DataManager.Instance.RemoveContato(contato);

                if (DataManager.Instance.SaveList())
                    this.Contatos = DataManager.Instance.Contatos;
            }
        }
    }
}

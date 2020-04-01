using Remeberme.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Remeberme
{
    
    public sealed partial class MainPage : Page
    {

        List<NavigationViewItem> listaTempDeItens;

        public MainPage()
        {
            this.InitializeComponent();

            NavigationPage.Instance.OnVavigateToPage += Instance_OnVavigateToPage;

            ResetMenu();
        }

        private void Instance_OnVavigateToPage(object sender, Helpers.NavigationEventArgs e)
        {
            ChangePage(e.PageToGo, e.ItemEdit);
        }

        NavigationViewItem page;

        private List<NavigationViewItem> GetItemsMenu()
        {
            NavigationViewItem naviViewItemInicio = new NavigationViewItem
            {
                Content = "Início",
                Icon = new SymbolIcon { Symbol = Symbol.GoToStart }
            };

            NavigationViewItem naviViewItemContatos = new NavigationViewItem
            {
                Content = "Contatos",
                Icon = new SymbolIcon { Symbol = Symbol.People },
            };

            NavigationViewItem naviViewItemNovoContato = new NavigationViewItem
            {
                Content = "Novo Contato",
                Icon = new SymbolIcon { Symbol = Symbol.AddFriend }
            };

            listaTempDeItens = new List<NavigationViewItem>
            {
                naviViewItemInicio, naviViewItemContatos, naviViewItemNovoContato
            };

            return listaTempDeItens;
        }

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            ResetUI();
            page = args.SelectedItem as NavigationViewItem;

            if (page.Icon != null) page.Icon.Foreground = ConvertColorFromHexString("#ffffff");

            if (page != null)
                ChangePage(page.Content.ToString());
        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            page = sender.SelectedItem as NavigationViewItem;

            if (page != null)
                ChangePage(page.Content.ToString());
        }

        private void ChangePage(string pageName, object itemToedit = null)
        {
            nvTopLevelNav.Header = pageName;
            pageName = pageName.ToLower();

            switch (pageName)
            {
                case "início":
                    contentFrame.Navigate(typeof(Views.Home));
                    break;
                case "contatos":
                    contentFrame.Navigate(typeof(Views.Contatos));
                    break;
                case "novo contato":
                  if(itemToedit != null) contentFrame.Navigate(typeof(Views.NovoContato), itemToedit);
                  else contentFrame.Navigate(typeof(Views.NovoContato), itemToedit);
                break;
            }
        }

        private void ResetMenu()
        {
            listaTempDeItens = GetItemsMenu();

            for (int i=0; i < listaTempDeItens.Count;i++)
            {
              if(nvTopLevelNav.MenuItems.Count > 0)
                nvTopLevelNav.MenuItems.RemoveAt(0);
            }

            foreach (var item in listaTempDeItens)
                nvTopLevelNav.MenuItems.Add(item);
        }

        private void ResetUI()
        {
            string colorDefault = "#ff8106";

            foreach (NavigationViewItem nvi in nvTopLevelNav.MenuItems.OfType<NavigationViewItem>())
            { 
                nvi.Foreground = ConvertColorFromHexString(colorDefault);
                if (nvi.Icon != null) nvi.Icon.Foreground = ConvertColorFromHexString(colorDefault);
            }
        }

        private SolidColorBrush ConvertColorFromHexString(string colorHexa)
        {
            colorHexa = colorHexa.Replace("#", string.Empty);
            var r = (byte)Convert.ToUInt32(colorHexa.Substring(0, 2), 16);
            var g = (byte)Convert.ToUInt32(colorHexa.Substring(2, 2), 16);
            var b = (byte)Convert.ToUInt32(colorHexa.Substring(4, 2), 16);
            Windows.UI.Color color = Windows.UI.Color.FromArgb(255, r, g, b);
            return new SolidColorBrush(color);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Remeberme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        NavigationViewItem page;

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            page = args.SelectedItem as NavigationViewItem;
            page.Icon.Foreground = ConvertColorFromHexString("#ffffff");

            if (page != null)
                ChangePage(page.Content.ToString());
        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

        }

        private void ChangePage(string pageName)
        {
            
            nvTopLevelNav.Header = pageName;
            pageName = pageName.ToLower();

            switch (pageName)
            {
                case "início" :
                        contentFrame.Navigate(typeof(Views.Home)); 
                    break;
                case "contatos":
                    contentFrame.Navigate(typeof(Views.Contatos));
                    break;
                case "novo contato":
                    contentFrame.Navigate(typeof(Views.NovoContato));
                    break;

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

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Remeberme.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();

            //double width = ((Frame)Window.Current.Content).ActualHeight;

            float width = Window.Current.Content.ActualSize.X;

            this.Width = width * 0.87;
        }
    }
}

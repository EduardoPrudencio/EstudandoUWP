using Remeberme.Model;
using Remeberme.ViewModel;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Remeberme.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NovoContato : Page
    {
        public NovoContato()
        {
            this.InitializeComponent();
            this.DataContext = new NewContatoViewModel();
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Contato c  = e.Parameter as Contato;

                if(c != null)
                    ((NewContatoViewModel)this.DataContext).Convert(c);
            }

            base.OnNavigatedTo(e);
        }

    }
}

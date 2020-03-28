using System;

namespace Remeberme.Helpers
{
    public class NavigationPage
    {
        private NavigationPage(){}

        private static volatile NavigationPage _instance;

        public static NavigationPage Instance { get { return _instance ?? (_instance = new NavigationPage()); } }

        public event EventHandler<NavigationEventArgs> OnVavigateToPage;

        private void NotifyNavigation(NavigationEventArgs args)
        {
            if (OnVavigateToPage != null)
                OnVavigateToPage(this, args);
        }

        public void GoToPage(NavigationEventArgs args)
        {
            NotifyNavigation(args);
        }
    }

    public class NavigationEventArgs : EventArgs
    {
        public string PageToGo { get; set; }

        public object ItemEdit { get; set; }
    }
}

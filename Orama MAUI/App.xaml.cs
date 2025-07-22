using Orama.Pages;
using Orama.Utility;

namespace Orama
{
    public partial class App : Application
    {
        private readonly AppStatus appStatus;

        public App()
        {
            InitializeComponent();
            appStatus = new AppStatus();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Page rootPage;
            if (!appStatus.IsLoggedIn)
            {
                // Always wrap in NavigationPage for consistent navigation
                rootPage = new NavigationPage(new Login());
            }
            else
            {
                rootPage = new AppShell();
            }

            return new Window(rootPage);
        }
    }
}
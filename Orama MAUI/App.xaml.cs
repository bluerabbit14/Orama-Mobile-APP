using Orama.Pages;
using Orama.Utility;

namespace Orama
{
    public partial class App : Application
    {
        private AppStatus appStatus;

        public App()
        {
            InitializeComponent();
            appStatus = new AppStatus();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            try
            {
                Page rootPage;
                if (appStatus.IsLoggedIn == true)
                    rootPage = new NavigationPage(new Login());
                else
                    rootPage = new AppShell();

                return new Window(rootPage);
            }
            catch (NullReferenceException ex)
            {
                // Handle null value exception specifically
                Console.WriteLine($"NullReferenceException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
    }
}
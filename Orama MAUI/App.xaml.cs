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
            if (appStatus.IsLoggedIn)
            {
                rootPage = new AppShell(); 
            }
            else
            {
                rootPage = new NavigationPage(new Login());
            }

            return new Window(rootPage);
        }
    }
    class AppStatus
    {
        public bool IsLoggedIn { get; set; } = false;
        public bool IsFirstRun { get; set; }
        public bool IsOnboardingComplete { get; set; }
        public bool IsNotificationsEnabled { get; set; }
        public bool IsLocationEnabled { get; set; }
        public bool IsNetworkAvailable { get; set; }
        public Theme Theme { get; set; }
    }
    enum Theme
    {
        Light,
        Dark,
        SystemDefault
    }
}
using Orama.Pages;

namespace Orama
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(Profile), typeof(Profile));
            Routing.RegisterRoute(nameof(Notification), typeof(Notification));
            Routing.RegisterRoute(nameof(Support), typeof(Support));
            Routing.RegisterRoute(nameof(Search), typeof(Search));
        }

        private void Image_Tapped(object sender, TappedEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Profile image tapped!");
                Shell.Current.FlyoutIsPresented =false;
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error opening flyout: {ex.Message}");
            }
        }

        private void About_Tapped(object sender, TappedEventArgs e)
        {
            
        }
    }
}

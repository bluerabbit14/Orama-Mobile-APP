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
    }
}

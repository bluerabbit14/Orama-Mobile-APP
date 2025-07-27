
using Orama.Pages;
using Microsoft.Maui.Storage;

namespace Orama
{
    public partial class AppShell : Shell
    {

        const string ThemePrefKey = "LastAppTheme";

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(SignUp), typeof(SignUp));
            Routing.RegisterRoute(nameof(ForgotPassword), typeof(ForgotPassword));
            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(Notification), typeof(Notification));
            Routing.RegisterRoute(nameof(Support), typeof(Support));
            Routing.RegisterRoute(nameof(NotificationDetail), typeof(NotificationDetail));
            Routing.RegisterRoute(nameof(Analyse), typeof(Analyse));
            Routing.RegisterRoute(nameof(Setting), typeof(Setting));

            if (Application.Current != null)
            {
                var savedTheme = Preferences.Get(ThemePrefKey, "");
                if (savedTheme == nameof(AppTheme.Dark))
                    Application.Current.UserAppTheme = AppTheme.Dark;
                else if (savedTheme == nameof(AppTheme.Light))
                    Application.Current.UserAppTheme = AppTheme.Light;
            }
        }

        private void OnThemeToggleTapped(object sender, TappedEventArgs e)
        {
            if (Application.Current != null)
            {
                var currentTheme = Application.Current.UserAppTheme;
                if (currentTheme == AppTheme.Dark)
                {
                    Application.Current.UserAppTheme = AppTheme.Light;
                    Preferences.Set(ThemePrefKey, nameof(AppTheme.Light));
                }
                else
                {
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    Preferences.Set(ThemePrefKey, nameof(AppTheme.Dark));
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Message", "Do you want to log out?", "Yes", "No");
            if (answer)
            {
                Preferences.Remove("UserEmail");
                if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                {
                    Application.Current.Windows[0].Page = new Login();
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (Shell.Current != null)
            {
                Shell.Current.FlyoutIsPresented = false;
            }
           // Navigation.PushAsync(new Profile());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_5(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_6(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_7(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_8(object sender, TappedEventArgs e)
        {

        }
    }
}

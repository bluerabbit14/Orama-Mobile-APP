namespace Orama.Pages;

using Orama.Models.ViewModels;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        BindingContext = new HomeCarouselViewModel();
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        // Show the flyout menu when the user icon is tapped
        if (Shell.Current != null)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }

    private void Support_tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Support());
    }

    private void Notification_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Notification());
    }
}
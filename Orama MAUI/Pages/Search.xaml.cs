namespace Orama.Pages;

public partial class Search : ContentPage
{
    public Search()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        // Show the flyout menu when the user icon is tapped
        if (Shell.Current != null)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }

    private void Setting_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Setting());
    }
}
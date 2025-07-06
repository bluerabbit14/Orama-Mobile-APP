namespace Orama.Pages;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private void Notification_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Notification());
    }

    private void Support_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Support());
    }
}
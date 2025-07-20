using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;

namespace Orama.Pages;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
		OTPEntry.IsVisible = true;
        OTPEntry.IsEnabled = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ChangePasswordEntry.IsVisible = true;
        ChangePasswordEntry.IsEnabled = true;
        ConfirmPasswordEntry.IsVisible = true;
        ConfirmPasswordEntry.IsEnabled = true;
        SaveButton.IsVisible = true;
        SaveButton.IsEnabled = true;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await Toast.Make("Succesfully Password Updated").Show();
        Application.Current.MainPage = new NavigationPage(new Login());
    }
}
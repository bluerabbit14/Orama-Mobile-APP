using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Orama.Models;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Json;
#if WINDOWS
using Orama.Platforms.Windows;
#endif

namespace Orama.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }
    private async void Login_Button_Clicked(object sender, EventArgs e)
    {
        var email = EmailTextBox.Text?.Trim();
        var password = PasswordTextBox.Text?.Trim();
        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            var errorMessage = string.IsNullOrEmpty(email) ? "Email cannot be null" : string.IsNullOrEmpty(password) ? "Password cannot be null": string.IsNullOrWhiteSpace(email)?"Email cannot be white space":"Password cannot be white space";
            await DisplayAlert("Login Failed", $"{errorMessage}", "ok");
            return;
        }

        //to check is email registered or not
        if(false)
        {
            var errorMessage = "Email not registered";
            await DisplayAlert("Login Failed", $"{errorMessage}", "ok");
            return;
        }

#if WINDOWS
        // Use WindowAuthService for Windows
        var windowAuthService = new WindowAuthorizeService();
        var loginResponse = await windowAuthService.LoginAsync(email, password);
        if (loginResponse != null)
        {
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPassword", password);
            if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                Application.Current.Windows[0].Page = new AppShell();
        }
        else
        {
            var errorMessage = loginResponse is LoginResponse errorResponse ? errorResponse.Message : "Invalid credentials.";
            await DisplayAlert("Login Failed", errorMessage, "OK");
        }
#else
        // Default hardcoded login for other platforms (testing only)
        if (email.Equals("14asifcr7@gmail.com") && password.Equals("admin@123"))
        {
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPassword", password);
            if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                Application.Current.Windows[0].Page = new AppShell();
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid credentials.", "OK");
        }
#endif
    }

    private void Signup_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SignUp());
    }
    private void forgotPassword_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ForgotPassword());
    }
}
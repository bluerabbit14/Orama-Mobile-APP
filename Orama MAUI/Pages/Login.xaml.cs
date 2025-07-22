using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Orama.Models;
using System.Text.RegularExpressions;
using Orama.Services;
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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SignUp());
    }
    
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var email = EmailTextBox.Text?.Trim();
        var password = PasswordTextBox.Text?.Trim();
        if (string.IsNullOrEmpty(email))
        {
            MsgIfEmailIsEmpty.IsVisible = true;
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            MsgIfPasswordIsEmpty.IsVisible = true;
            return;
        }

#if WINDOWS
        // Use WindowLoginService for Windows
        var loginService = new WindowsLoginService();
        var loginResponse = await loginService.LoginAsync(email, password);
        if (loginResponse != null && loginResponse.UserId != null)
        {
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPassword", password);
            if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                Application.Current.Windows[0].Page = new AppShell();
        }
        else
        {
            await DisplayAlert("Login Failed", loginResponse?.Message ?? "Invalid credentials.", "OK");
        }
#else
        // Default hardcoded login for other platforms
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

    private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        MsgIfPasswordIsEmpty.IsVisible = false;
    }

    private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        MsgIfEmailIsEmpty.IsVisible = false;
        MsgIfEmailNotRegistered.IsVisible = false;
        MsgIfEmailRegistered.IsVisible = false;
        MsgIfEmailIsInvalid.IsVisible = false;
    }
    
    private bool IsEmailRegistered(string email)
    {
        return false;
    }
    
    private bool IsEmailNotRegistered(string email)
    {
        return false;
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ForgotPassword());
    }
}
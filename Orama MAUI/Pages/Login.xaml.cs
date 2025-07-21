
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Orama.Models;
using System.Text.RegularExpressions;

namespace Orama.Pages;

public partial class Login :ContentPage
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
          if (IsEmailRegistered(email))
          {
              MsgIfEmailRegistered.IsVisible = true;
              return;
          }
          if (IsEmailNotRegistered(email))
          {
              MsgIfEmailNotRegistered.IsVisible = true;
              return;
          }
          if (string.IsNullOrEmpty(password))
          {
              MsgIfPasswordIsEmpty.IsVisible = true;
              return;
          }
          
          LoginRequest request = new LoginRequest { Email = email, Password = password, LastLogin = DateTime.UtcNow };
          if (request.Email.Equals("14asifcr7@gmail.com") && request.Password.Equals("admin@123"))
          {              
               
                   Preferences.Set("UserEmail", email);
                   Preferences.Set("UserPassword", password);
               await Toast.Make("Succesfully Logged In").Show();
               if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                      Application.Current.Windows[0].Page = new AppShell();
          }
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
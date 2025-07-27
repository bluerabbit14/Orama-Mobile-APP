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

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();
    }

    private async void signup_Button_Clicked(object sender, EventArgs e)
    {
        var name = NameTextBox.Text?.Trim();
        var email = EmailTextBox.Text?.Trim();
        var password = PasswordTextBox.Text?.Trim();
        var confirmpassword = PasswordConfirmTextBox.Text?.Trim();
        bool checkbox = checkBoxOfTerms.IsChecked;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
                await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
                return;
        }
        if(CheckNameIsValid(name))
        {
            await DisplayAlert("Validation Error", "Name is not valid.", "OK");
            return;
        }
        // to check is email already registered
        if (false)
        {

        }
        if (!CheckIsEmailValid(email))
        {
            await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
            return;
        }
        if (password != confirmpassword)
        {
            await DisplayAlert("Validation Error", "Passwords do not match.", "OK");
            return;
        }
        if (CheckIsPasswordWeak(password))
        {
            await DisplayAlert("Validation Error", "Password is too weak. Please include uppercase, lowercase, numbers, and symbols.", "OK");
            return;
        }

        if (CheckIsPasswordTooCommon(password))
        {
            await DisplayAlert("Validation Error", "Password is too common. Please choose a stronger password.", "OK");
            return;
        }

        if (CheckIsPasswordTooShort(password))
        {
            await DisplayAlert("Validation Error", "Password must be at least 8 characters long.", "OK");
            return;
        }

        if (CheckIsPasswordTooLong(password))
        {
            await DisplayAlert("Validation Error", "Password must not exceed 16 characters.", "OK");
            return;
        }
        if (!checkbox)
        {
            bool answer = await DisplayAlert("Message", "Agree to Orama Terms & Condition ?", "Yes", "No");
            checkBoxOfTerms.IsChecked = answer;
            return;
        }

#if WINDOWS
        // Use WindowAuthService for Windows
        var windowAuthService = new WindowAuthService();
        var signupResponse = await windowAuthService.SignupAsync(name, email, password);
        if (signupResponse != null && signupResponse is SignupResponse response && response.UserId != null)
        {
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPassword", password);
            if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                Application.Current.Windows[0].Page = new AppShell();
        }
        else
        {
            var errorMessage = signupResponse is SignupResponse errorResponse ? errorResponse.Message : "Signup failed.";
            await DisplayAlert("SignUp Failed", errorMessage, "OK");
        }
#else 
        // Default hardcoded signup for other platforms (testing only)
        if (email.Equals("test@example.com") && password.Equals("Test@123"))
        {
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPassword", password);
            if (Application.Current?.Windows.Count > 0 && Application.Current.Windows[0] != null)
                Application.Current.Windows[0].Page = new AppShell();
        }
        else
        {
            await DisplayAlert("SignUp Failed", "No other Platform is enabled yet", "OK");
        }            
#endif
    }

    private bool CheckNameIsValid(string name)
    {
        foreach (char c in name)
        {
            if (Char.IsWhiteSpace(c))
                continue;
            if (!char.IsLetter(c))
                return true;  //if not valid 
        }
        return false;
    }
    
    private bool CheckIsEmailValid(string email)
    {
        const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        if (!Regex.IsMatch(email, pattern))
            return false;

        // Additional check: no consecutive dots
        if (email.Contains(".."))
            return false;

        // Additional check: must not start or end with dot
        var parts = email.Split('@');
        if (parts.Length != 2)
            return false;
        if (parts[0].StartsWith(".") || parts[0].EndsWith("."))
            return false;
        if (parts[1].StartsWith(".") || parts[1].EndsWith("."))
            return false;

        return true;
    }
    
    private bool CheckIsPasswordWeak(string password)
    {
        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSymbol = password.Any(ch => !char.IsLetterOrDigit(ch));

        int varietyCount = new[] { hasUpper, hasLower, hasDigit, hasSymbol }.Count(b => b);

        if (varietyCount < 3)
            return true;
        return false;
    }
    
    private bool CheckIsPasswordTooCommon(string password)
    {
        var weakList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
         {
             "123456", "password", "123456789", "qwerty", "12345678",
             "12345", "111111", "1234567", "dragon", "baseball",
         };
        if (weakList.Contains(password))
            return true;
        return false;
    }
    
    private bool CheckIsPasswordTooLong(string password)
    {
        if (password.Length > 16)
            return true;
        return false;
    }
    
    private bool CheckIsPasswordTooShort(string password)
    {
        if (password.Length < 8)
            return true;
        return false;
    }
}
using CommunityToolkit.Maui.Alerts;
using Orama.Models;
using System.Text.RegularExpressions;
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var name = NameTextBox.Text?.Trim();
        var email = EmailTextBox.Text?.Trim();
        var password = PasswordTextBox.Text?.Trim();
        var confirmpassword = PasswordConfirmTextBox.Text?.Trim();
        bool checkbox = checkBoxOfTerms.IsChecked;

        if (string.IsNullOrEmpty(name))
        {
            msgWhenNameIsEmpty.IsVisible = true;
            return;
        }
        if (CheckNameIsValid(name))
        {
            msgWhenNameIsNotValid.IsVisible= true;
            return;
        }
        if (string.IsNullOrEmpty(email))
        {
            msgWhenEmailIsEmpty.IsVisible = true;
            return;
        }
        if (!CheckIsEmailValid(email))
        {
            msgWhenEmailIsInvalid.IsVisible = true;
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            msgWhenPasswordIsEmpty.IsVisible = true;
            return;
        }
        if (CheckIsPasswordTooShort(password))
        {
            msgWhenPasswordIsTooshort.IsVisible = true;
            return;
        }
        if (CheckIsPasswordWeak(password))
        {
            msgWhenPasswordIsWeak.IsVisible = true;
            return;
        }
        if (CheckIsPasswordTooLong(password))
        {
            msgWhenPasswordIsTooLong.IsVisible = true;
            return;
        }
        if (CheckIsPasswordTooCommon(password))
        {
            msgWhenPasswordIsTooCommon.IsVisible = true;
            return;
        }
        if (string.IsNullOrEmpty(confirmpassword))
        {
            msgWhenConfirmPasswordIsEmpty.IsVisible = true;
            return;
        }
        if(!password.Equals(confirmpassword))
        {
            msgWhenConfirmPasswordDoesNotMatch.IsVisible = true;
            return;
        }
        if(!checkbox)
        {
            bool answer= await DisplayAlert("Message", "Agree to Orama Terms & Condition ?", "Yes", "No");
            checkBoxOfTerms.IsChecked = answer;
            return;
        }

#if WINDOWS
        var signupService = new WindowSignUpService();
        var signupResponse = await signupService.SignupAsync(name, email, password);
        if (signupResponse != null)
        {
            await DisplayAlert("Success", "Successfully Signed up", "OK");
            Application.Current.MainPage = new Login();
        }
        else
        {
            await DisplayAlert("Signup Failed", signupResponse?.Message ?? "Signup failed.", "OK");
        }
#else
        // Default hardcoded signup for other platforms

            await Toast.Make("Successfully Signed up").Show();
            Application.Current.MainPage = new Login();
#endif
    }

    private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        msgWhenNameIsEmpty.IsVisible = false;
        msgWhenNameIsNotValid.IsVisible = false;
    }

    private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        msgWhenEmailIsEmpty.IsVisible = false;
        msgWhenEmailIsInvalid.IsVisible = false;
        msgWhenEmailIsRegistered.IsVisible = false;
    }

    private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        msgWhenPasswordIsEmpty.IsVisible = false;
        msgWhenPasswordIsWeak.IsVisible = false;
        msgWhenPasswordIsTooCommon.IsVisible = false;
        msgWhenPasswordIsTooshort.IsVisible = false;
        msgWhenPasswordIsTooLong.IsVisible = false;
    }

    private void PasswordConfirmTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        msgWhenConfirmPasswordIsEmpty.IsVisible = false;
        msgWhenConfirmPasswordDoesNotMatch.IsVisible = false;
    }
    
    private bool CheckNameIsValid(string name)
    {
        foreach (char c in name)
        {
            if (Char.IsWhiteSpace(c))
                continue;
            if (!char.IsLetter(c))
                return true;
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
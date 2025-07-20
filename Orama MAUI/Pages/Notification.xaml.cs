using System.ComponentModel;
using System.Linq;
using Microsoft.Maui.ApplicationModel;
using Orama.Models;
using Orama.Models.ViewModels;

namespace Orama.Pages;

public partial class Notification : ContentPage
{
	public Notification()
	{
		InitializeComponent();
        BindingContext = new NotificationViewModel();
	}

    private void ButtonServices_Clicked(object sender, EventArgs e)
    {
        ButtonServices.Background = Colors.Red;
        ButtonServices.TextColor = Colors.White;
        ButtonAll.Background = Colors.White;
        ButtonAll.TextColor = Colors.SkyBlue;
        ButtonImportant.Background = Colors.White;
        ButtonImportant.TextColor = Colors.Orange;
    }

    private void ButtonImportant_Clicked(object sender, EventArgs e)
    {
        ButtonImportant.Background = Colors.Orange;
        ButtonImportant.TextColor = Colors.White;
        ButtonServices.Background = Colors.White;
        ButtonServices.TextColor = Colors.Red;
        ButtonAll.Background = Colors.White;
        ButtonAll.TextColor = Colors.SkyBlue;
    }

    private void ButtonAll_Clicked(object sender, EventArgs e)
    {
        ButtonAll.Background = Colors.SkyBlue;
        ButtonAll.TextColor = Colors.White;
        ButtonImportant.Background = Colors.White;
        ButtonImportant.TextColor = Colors.Orange;
        ButtonServices.Background = Colors.White;
        ButtonServices.TextColor = Colors.Red;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is NotificationModel selectedNotification)
        {
            // Mark the notification as read
            selectedNotification.IsRead = true;
            
            // Clear the selection immediately to prevent issues
            ((CollectionView)sender).SelectedItem = null;
            
            // Use MainThread to ensure UI thread execution
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PushAsync(new NotificationDetail(selectedNotification));
            });
        }
    }
}
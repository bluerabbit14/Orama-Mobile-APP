namespace Orama.Pages;

public partial class Home : ContentPage
{
public Home()
{
    InitializeComponent();
    AddSwipeGesture();
}
    private void AddSwipeGesture()
    {
        var swipeLeft = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
        var swipeRight = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };

        swipeLeft.Swiped += (s, e) =>
        {
            Shell.Current.FlyoutIsPresented = false;
        };
        swipeRight.Swiped += (s, e) =>
        {
            Shell.Current.FlyoutIsPresented = true;
        };
        SwipeArea.GestureRecognizers.Add(swipeLeft);
        SwipeArea.GestureRecognizers.Add(swipeRight);
    }
    private void Notification_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Notification());
    }
}
namespace Orama.Pages;

public partial class Search : ContentPage
{
    public Search()
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
}
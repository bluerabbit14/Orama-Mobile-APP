using Orama.Models;

namespace Orama.Pages;

public partial class NotificationDetail : ContentPage
{
	public NotificationDetail(NotificationModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
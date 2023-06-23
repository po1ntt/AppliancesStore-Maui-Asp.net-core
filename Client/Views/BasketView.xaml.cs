using Client.Views.OrdersViews;

namespace Client.Views;

public partial class BasketView : ContentPage
{
	public BasketView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PushAsync(new OrderCreateView());
    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }
}
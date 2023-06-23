using Client.DataService.DboModels;
using Client.ViewsModels;


namespace Client.Views.OrdersViews;

public partial class OrderAboutView : ContentPage
{
	public Order order1 { get; set; }	
	public OrderAboutView(Order order)
	{
		InitializeComponent();
		BindingContext = new OrdersAboutViewModel(order);
		order1 = order;
	}

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
		if(order1.StatusId == 4)
		{
            CancelOrder.IsVisible = false;
        }
		else
		{
            CancelOrder.IsVisible = true;
        }
    }
}
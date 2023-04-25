using Client.ViewsModels;

namespace Client.Views;

public partial class ProductsView : ContentPage
{
    public ProductsView()
    {
        InitializeComponent();
    }
    public ProductsView(Models.Subcategory subcategory)
	{
		InitializeComponent();
        BindingContext = new ProductsVM(subcategory);
	}

    private async void PopThisPage_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}
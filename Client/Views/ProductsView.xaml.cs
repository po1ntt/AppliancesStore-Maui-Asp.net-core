using Client.DataService.DboModels;
using Client.ViewsModels;

namespace Client.Views;
public partial class ProductsView : ContentPage
{
	public ProductsView(Category category)
	{
		InitializeComponent();
		this.BindingContext = new ProductsViewModel(category);
	}
    public ProductsView(Brand brand)
    {
        InitializeComponent();
        this.BindingContext = new ProductsViewModel(brand);
    }
   
}
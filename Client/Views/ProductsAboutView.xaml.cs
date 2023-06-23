using Client.DataService.DboModels;
using Client.ViewsModels;

namespace Client.Views;

public partial class ProductsAboutView : ContentPage
{
	public Product product1 { get; set; }
	public ProductsAboutView(Product product)
	{
		InitializeComponent();
		BindingContext = new ProductsAboutViewModel(product);
	
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		
    }
}
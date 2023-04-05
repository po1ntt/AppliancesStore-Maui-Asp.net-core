using Client.Models;
using System.Collections.ObjectModel;

namespace Client.Views.Templates.ProductsTemplate.ProductTemplametesMain;
public partial class ProductsVerticalTwoRows : ContentView
{
    public static readonly BindableProperty ProductsListProperty = BindableProperty.Create(nameof(ProductsList), typeof(ObservableCollection<Products>), typeof(ProductsVerticalTwoRows), null);

    public ObservableCollection<Products> ProductsList
    {
        get => (ObservableCollection<Products>)GetValue(ProductsListProperty);
        set => SetValue(ProductsListProperty, value);
    }
    public ProductsVerticalTwoRows()
	{
		InitializeComponent();
	}
}
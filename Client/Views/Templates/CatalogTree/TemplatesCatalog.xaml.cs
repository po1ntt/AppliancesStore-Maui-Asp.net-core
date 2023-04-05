namespace Client.Views.Templates.CatalogTree;
using CommunityToolkit.Mvvm;
public partial class TemplatesCatalog : ResourceDictionary
{
	public TemplatesCatalog()
	{
		InitializeComponent();
        // Command = "{Binding Source={RelativeSource AncestorType={x:Type VM:ChooseObjectsVM}}, Path=OpenCommand}"


    }
}
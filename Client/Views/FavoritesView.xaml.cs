namespace Client.Views;

public partial class FavoritesView : ContentPage
{
	public FavoritesView()
	{
		InitializeComponent();
		Preferences.Clear();
	}
}
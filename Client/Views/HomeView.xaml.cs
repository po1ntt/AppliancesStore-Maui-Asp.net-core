namespace Client.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private async void Auth_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PushModalAsync(new SignInView());
    }
}
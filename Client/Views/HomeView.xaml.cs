namespace Client.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PushAsync(new SignInView());
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
        {
            UserAuthFrame.IsVisible = true;
            UserNotAuthFrame.IsVisible = false;

        }
        else
        {
            UserNotAuthFrame.IsVisible = true;
            UserAuthFrame.IsVisible = false;

        }
    }
}
using Client.Views.Popups;

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

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {

        if (!string.IsNullOrWhiteSpace(Preferences.Default.Get("Login", "")))
        {
            UserAuthFrame.IsVisible = true;
            UserNotAuthFrame.IsVisible = false;
            exitBtn.IsEnabled = true;
            txbPriverLogin.Text = $"Привет, {Preferences.Default.Get("Login", "")}";
        }
        else
        {
            UserNotAuthFrame.IsVisible = true;
            UserAuthFrame.IsVisible = false;
            exitBtn.IsEnabled = false;
            txbPriverLogin.Text = $"";


        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        UserNotAuthFrame.IsVisible = true;
        UserAuthFrame.IsVisible = false;
        exitBtn.IsEnabled = false;

    }
}
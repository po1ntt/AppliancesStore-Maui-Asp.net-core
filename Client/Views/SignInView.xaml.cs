namespace Client.Views;

public partial class SignInView : ContentPage
{
	public SignInView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PushAsync(new RegistrationView());
    }
}
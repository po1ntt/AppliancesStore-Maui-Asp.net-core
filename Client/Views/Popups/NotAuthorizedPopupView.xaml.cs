using CommunityToolkit.Maui.Views;
using Mopups.Services;

namespace Client.Views.Popups;

public partial class NotAuthorizedPopupView : Mopups.Pages.PopupPage
{
	public NotAuthorizedPopupView()
	{
		InitializeComponent();
	}

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAsync();
        await Shell.Current.Navigation.PushAsync(new SignInView());
    }
}
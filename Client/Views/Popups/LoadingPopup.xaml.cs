using Client.ViewsModels;

namespace Client.Views.Popups;

public partial class LoadingPopup : Mopups.Pages.PopupPage
{
	public LoadingPopup()
	{
		InitializeComponent();
		BindingContext = new BaseVM();
	}
}
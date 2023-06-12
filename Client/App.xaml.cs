using Client.Handlers;
using Client.Views;
using Microsoft.Maui.Platform;

namespace Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
using Client.Views;

namespace Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignInView), typeof(SignInView));
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(CatalogView), typeof(CatalogView));

        }
    }
}
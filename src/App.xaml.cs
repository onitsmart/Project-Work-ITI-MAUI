using PizzaProject_MAUI.Views;

namespace PizzaProject_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListPage());
        }
    }
}

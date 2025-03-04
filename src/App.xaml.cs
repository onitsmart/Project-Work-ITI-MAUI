using PizzaProject_MAUI.Views;

namespace PizzaProject_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            // INITIALIZE COMPONENT è il metodo che inizializza la pagina come descritta nel file XAML
            // e la rende accessibile ai file scritti in codice C#.
            // Best practice: lasciare sempre questo metodo per primo.

            InitializeComponent();

            // NAVIGAZIONE: in questo punto viene impostata la schermata iniziale dell'app,
            // ovvero la 'root page' alla base dello stack di navigazione.  

            MainPage = new NavigationPage(new ListPage());
        }
    }
}

using CommunityToolkit.Mvvm.Input;

namespace PizzaProject_MAUI.Views;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        // INITIALIZE COMPONENT � il metodo che inizializza la pagina come descritta nel file XAML
        // e la rende accessibile ai file scritti in codice C#.

        // BINDING CONTEXT � la propriet� nella quale viene definito quale viewmodel associare a questa view.

        InitializeComponent();
        BindingContext = new ListViewModel();
    }

    // RELAY COMMAND crea un metodo che � possibile richiamare nel codice xaml.
    // Questo attributo � utilizzabile in tutti i file scritti in codice C# (quindi sia nel file .xaml.cs della view che nel viewmodel).
    // Il nome del metodo esposto viene generato secondo queste regole:
    //    - viene eliminato un eventuale "On" all'inizio;
    //    - viene eliminato un eventuale "Async" alla fine;
    //    - viene aggiunto "Command" alla fine del nome.
    // Esempi di trasformazione del nome: OnAppearing -> AppearingCommand, OpenPageAsync -> OpenPageCommand, NewOrder -> NewOrderCommand)

    // Lo stack di NAVIGAZIONE � accessibile solo nella view.
    // Di conseguenza, i comandi che lo modificano (eg: Push e Pop) devono essere gestiti nei file .xaml.cs.

    [RelayCommand]  
    public async Task NewOrder()
    {
        await Navigation.PushAsync(new OrderPage());
    }

    [RelayCommand]
    public async Task OpenOrder(int orderId)
    {
        await Navigation.PushAsync(new OrderPage(orderId));
    }
}
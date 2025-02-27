using CommunityToolkit.Mvvm.Input;

namespace PizzaProject_MAUI.Views;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
        BindingContext = new ListViewModel();
    }

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
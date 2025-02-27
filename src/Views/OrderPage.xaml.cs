using CommunityToolkit.Mvvm.Input;

namespace PizzaProject_MAUI.Views;

public partial class OrderPage : ContentPage
{
    private OrderViewModel _viewModel;

    public OrderPage(int? orderId = null)
    {
        InitializeComponent();
        _viewModel = new OrderViewModel(orderId);
        BindingContext = _viewModel;
    }

    public void OnNotesEntryCompleted(object sender, EventArgs e)
    {
        //ricorda: viene chiamata solo premendo invio
        var item = ((Entry)sender).Text;
        _viewModel.SetOrderNotes(item);
    }

    public void OnQuantityIndicated(object sender, EventArgs e)
    {
        //ricorda: viene chiamata solo premendo invio
        var text = ((Entry)sender).Text;
        var quantity = int.Parse(text);
        _viewModel.SetOrderQuantity(quantity);
    }

    [RelayCommand]
    public async Task SaveOrder()
    {
        var hasError = _viewModel.SaveOrderInPreferences();
        if (hasError == false)
        {
            await Navigation.PopAsync();
        }
    }
}
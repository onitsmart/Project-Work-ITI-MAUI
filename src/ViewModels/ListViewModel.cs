using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using PizzaProject_MAUI.Models;
using PizzaProject_MAUI.Infrastructure;

namespace PizzaProject_MAUI
{
    public partial class ListViewModel : ObservableObject
    {
        public ObservableCollection<PizzaOrderModel> OrdersList { get; set; } = [];
                
        public ListViewModel()
        {
        }

        [RelayCommand]
        public void OnAppearing()
        {
            OrdersList.Clear();

            var orders = PreferencesUtilities.GetOrders();
            foreach (var order in orders)
            {
                OrdersList.Add(order);
            }

            ////imposta valori temporanei di PizzaOrders per facilitare il debugging nella fase iniziale
            ////(non sarà più necessario una volta che Orderpage sarà funzionante)
            //if (OrdersList.Count == 0)
            //{
            //    OrdersList.Add(new PizzaOrderModel
            //    {
            //        Base = "mozzarella",
            //        Toppings = ["patatine", "wurstel"],
            //        Notes = "poco pomodoro",
            //        Quantity = 1,
            //    });
            //    OrdersList.Add(new PizzaOrderModel
            //    {
            //        Base = "rossa",
            //        Toppings = ["salsiccia"],
            //        Quantity = 3,
            //        Id = 2,
            //    });
            //    OrdersList.Add(new PizzaOrderModel
            //    {
            //        Base = "bianca",
            //        Toppings = ["funghi"],
            //        Id = 3,
            //    });
            //}
        }

        [RelayCommand]
        public void DeleteOrder(int orderId)
        {
            PreferencesUtilities.DeleteOrder(orderId);

            OrdersList.Clear();

            var updatedOrders = PreferencesUtilities.GetOrders();
            foreach (var order in updatedOrders)
            {
                OrdersList.Add(order);
            }
        }
    }
}

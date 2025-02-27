using CommunityToolkit.Mvvm.ComponentModel;
using PizzaProject_MAUI.Models;
using System.Collections.ObjectModel;
using PizzaProject_MAUI.Infrastructure;

namespace PizzaProject_MAUI
{
    public partial class OrderViewModel : ObservableObject
    {
        public int Quantity { get; set; } = 1;

        public string Notes { get; set; } = string.Empty;

        public ObservableCollection<ItemModel> AvailableBases { get; set; } = [];

        public ObservableCollection<ItemModel> AvailableToppings { get; set; } = [];

        [ObservableProperty]
        private string _pageTitle = "Nuovo ordine";

        [ObservableProperty]
        private bool _hasError = false;

        [ObservableProperty]
        private string? _error = null;

        private int? _currentOrderId = null;

        public OrderViewModel(int? orderId = null)
        {
            AvailableToppings =
            [
                new ItemModel() { Value = "salsiccia" },
                new ItemModel() { Value = "funghi" },
                new ItemModel() { Value = "wurstel" },
                new ItemModel() { Value = "patatine" },
                new ItemModel() { Value = "verdure" },
                new ItemModel() { Value = "prosciutto" }
            ];

            AvailableBases =
            [
                new ItemModel() { Value = "rossa" },
                new ItemModel() { Value = "bianca" },
                new ItemModel() { Value = "margherita" },
            ];

            if (orderId.HasValue)
            {
                _currentOrderId = orderId;
                PageTitle = $"Modifica ordine n.{orderId}";
                
                var data = PreferencesUtilities.GetOrder(orderId.Value);
                Notes = data.Notes;

                foreach (var topping in AvailableToppings)
                {
                    if (data.Toppings.Contains(topping.Value))
                    {
                        topping.IsSelected = true;
                    }
                }

                foreach (var pizzaBase in AvailableBases)
                {
                    pizzaBase.IsSelected = pizzaBase.Value == data.Base;
                }

            }
        }

        public void SetOrderNotes(string value)
        {
            Notes = value;
        }

        public void SetOrderQuantity(int value)
        {
            Quantity = value;
        }

        public bool SaveOrderInPreferences()
        {
            if (AvailableBases.Where(x => x.IsSelected).Any() == false)
            {
                HasError = true;
                Error = "Selezionare la base della pizza";
                return true;
            }

            HasError = false;
            var pizzaBase = AvailableBases.Where(x => x.IsSelected).First().Value;
            var toppings = AvailableToppings.Where(x => x.IsSelected).Select(x => x.Value).ToList();

            PreferencesUtilities.SaveOrUpdateOrder(_currentOrderId, pizzaBase, toppings, Notes, Quantity);
            return false;
        }
    }
}

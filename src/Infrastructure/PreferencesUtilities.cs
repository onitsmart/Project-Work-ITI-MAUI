using PizzaProject_MAUI.Models;
using System.Text.Json;

namespace PizzaProject_MAUI.Infrastructure
{
    public static class PreferencesUtilities
    {
        private static readonly JsonSerializerOptions _defaultJsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public static List<PizzaOrderModel> GetOrders()
        {
            var serializedSavedOrders = Preferences.Default.Get("orders", "");

            if (string.IsNullOrEmpty(serializedSavedOrders)) return [];

            var savedOrders = JsonSerializer.Deserialize<List<PizzaOrderModel>>(serializedSavedOrders, _defaultJsonSerializerOptions);
            return savedOrders ?? [];
        }

        public static PizzaOrderModel GetOrder(int id)
        {
            var savedOrders = GetOrders();
            var order = savedOrders.Where(x => x.Id == id).First();

            return order;
        }

        public static void SaveOrUpdateOrder(int? id, string pizzaBase, IEnumerable<string> toppings, string notes, int quantity)
        {
            var savedOrders = GetOrders();

            if (id.HasValue)
            {
                var orderToEdit = savedOrders.Where(x => x.Id == id.Value).First();

                orderToEdit.Base = pizzaBase;
                orderToEdit.Toppings = toppings.ToList();
                orderToEdit.Notes = notes;
                orderToEdit.Quantity = quantity;
            }
            else
            {
                savedOrders.Add(new PizzaOrderModel
                {
                    Id = savedOrders.Count + 1,
                    Base = pizzaBase,
                    Toppings = toppings.ToList(),
                    Notes = notes,
                    Quantity = quantity
                });
            }

            var serializedOrders = JsonSerializer.Serialize(savedOrders, _defaultJsonSerializerOptions);
            Preferences.Default.Set("orders", serializedOrders);
        }

        public static void DeleteOrder(int id)
        {
            var savedOrders = GetOrders();
            savedOrders.RemoveAt(id - 1);

            foreach (var order in savedOrders)
            {
                order.Id = savedOrders.Count;
            }

            var serializedOrders = JsonSerializer.Serialize(savedOrders, _defaultJsonSerializerOptions);
            Preferences.Default.Set("orders", serializedOrders);
        }
    }
}

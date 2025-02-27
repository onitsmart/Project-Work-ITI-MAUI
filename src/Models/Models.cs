using System.Text.Json.Serialization;

namespace PizzaProject_MAUI.Models
{
    public class ItemModel
    {
        public string Value { get; set; } = string.Empty;

        public bool IsSelected { get; set; }
    }

    public class PizzaOrderModel 
    {        
        public int Id { get; set; }

        public string Base { get; set; } = string.Empty;

        public List<string> Toppings { get; set; } = [];

        public string Notes { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;

        [JsonIgnore]
        public bool ToppingsAreSet => Toppings.Count != 0;

        [JsonIgnore]
        public bool NotesAreSet => string.IsNullOrEmpty(Notes) == false;
    }
}

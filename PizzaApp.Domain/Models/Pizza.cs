using PizzaApp.Domain.Enums;

namespace PizzaApp.Domain.Models

{
    public class Pizza : IEntity
    {
        public Pizza()
        {

        }
        public Pizza(string name, decimal price, PizzaSize size)
        {
            if(name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            Price = price;
            Size = size;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

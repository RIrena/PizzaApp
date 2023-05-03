using PizzaApp.Domain.Enums;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb
{
    public static class PizzaAppDb
    {
        #region Pizza
        public static User Irena = new User("Irena", "Risteska", 100, "077 000 000", "irenaristeska@hotmail.com");

        public static IList<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza("Capricciosa", 200, PizzaSize.Small)
            {
                Id = 1,
            },
            new Pizza("Quattro formaggi", 400, PizzaSize.Medium)
            {
                Id=2,
            },
        };

        public static int SavePizza(Pizza pizza)
        {
            var pizzaId = Pizzas.OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
            pizza.Id = ++pizzaId;
            Pizzas.Add(pizza);
            return pizza.Id;
        }

        public static void UpdatePizza(Pizza model)
        {
            var pizzaIndex = 0;
            foreach(var pizza in Pizzas)
            {
                if(pizza.Id == model.Id)
                {
                    break;
                }
                pizzaIndex++;
            }

            if(Pizzas[pizzaIndex] is not null)
            {
                Pizzas[pizzaIndex] = model;
            }
        }

        public static void DeletePizza(int id)
        {
            //var pizzaIndex = 0;
            //foreach (var pizza in Pizzas)
            //{
            //    if (pizza.Id == id)
            //    {
            //        break;
            //    }
            //    pizzaIndex++;
            //}
            //Pizzas.RemoveAt(pizzaIndex);

            var model = Pizzas.FirstOrDefault(x => x.Id == id);
            if(model is not null)
            {
                DeletePizza(model);
            }
        }

        public static void DeletePizza(Pizza model)
        {
            Pizzas.Remove(model);
        }
        #endregion

        #region Order
        public static IList<Order> Orders { get; set; } = new List<Order>
        {

        };
        #endregion

        #region User
        public static IList<User> Users { get; set; } = new List<User>();
        #endregion
    }
}

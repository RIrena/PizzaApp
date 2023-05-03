using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb.Repository
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Pizza Create(Pizza entity)
        {
            var lastId = PizzaAppDb.Pizzas.LastOrDefault()?.Id ?? 0;
            entity.Id = ++lastId;
            PizzaAppDb.Pizzas.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var pizza = GetById(id);
            PizzaAppDb.Pizzas.Remove(pizza);
        }

        public void DeleteAll()
        {
            PizzaAppDb.Pizzas.Clear();
        }

        public IQueryable<Pizza> GetAll()
        {
            return PizzaAppDb.Pizzas.AsQueryable();
        }

        public Pizza GetById(int id)
        {
            return PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);  
        }

        public void Update(Pizza entity)
        {
            var pizza = GetById(entity.Id);
            pizza = entity;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Models;

namespace PizzaAPI.Services;

public class PizzaService(PizzaContext context)
{
    public IEnumerable<Pizza> GetAll() =>
        context.Pizzas.Include(p => p.Sauce).Include(p => p.Toppings).AsNoTracking();

    public Pizza? Get(int id) =>
        context
            .Pizzas.Include(p => p.Sauce)
            .Include(p => p.Toppings)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);

    public Pizza Add(Pizza pizza)
    {
        context.Pizzas.Add(pizza);
        context.SaveChanges();

        return pizza;
    }

    public void Delete(int Id)
    {
        var pizzaToDelete = context.Pizzas.Find(Id);

        if (pizzaToDelete is null)
            throw new InvalidOperationException("Pizza not found.");

        context.Pizzas.Remove(pizzaToDelete);
        context.SaveChanges();
    }

    public void Update(Pizza pizza)
    {
        var existingPizza = context.Pizzas.Find(pizza.Id);

        if (existingPizza is null)
            throw new InvalidOperationException("Pizza not found.");

        context.Pizzas.Update(pizza);
        context.SaveChanges();
    }

    public void AddTopping(int PizzaId, int ToppingId)
    {
        var pizzaToUpdate = context.Pizzas.Find(PizzaId);
        var toppingToAdd = context.Toppings.Find(ToppingId);

        if (pizzaToUpdate is null || toppingToAdd is null)
            throw new InvalidOperationException("Pizza or Topping not found.");

        if (pizzaToUpdate.Toppings is null)
            pizzaToUpdate.Toppings = new List<Topping>();

        pizzaToUpdate.Toppings.Add(toppingToAdd);
        context.SaveChanges();
    }

    public void UpdateSauce(int PizzaId, int SauceId)
    {
        var pizzaToUpdate = context.Pizzas.Find(PizzaId);
        var sauceToAdd = context.Sauces.Find(SauceId);

        if (pizzaToUpdate is null || sauceToAdd is null)
            throw new InvalidOperationException("Pizza or Sauce not found.");

        pizzaToUpdate.Sauce = sauceToAdd;
        context.SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Models;

namespace PizzaAPI.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pizza> GetAll() => _context.Pizzas.AsNoTracking().ToList();

    public Pizza? Get(int id) =>
        _context
            .Pizzas.Include(p => p.Sauce)
            .Include(p => p.Toppings)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);

    public Pizza Add(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();

        return pizza;
    }

    public void Delete(int Id) => throw new NotImplementedException();

    public void Update(Pizza pizza) => throw new NotImplementedException();

    public void AddTopping(int PizzaId, int ToppingId)
    {
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var toppingToAdd = _context.Toppings.Find(ToppingId);

        if (pizzaToUpdate is null || toppingToAdd is null)
            throw new InvalidOperationException("Pizza or Topping not found.");

        if (pizzaToUpdate.Toppings is null)
            pizzaToUpdate.Toppings = new List<Topping>();

        pizzaToUpdate.Toppings.Add(toppingToAdd);
        _context.SaveChanges();
    }

    public void UpdateSauce(int PizzaId, int SauceId) {
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var sauceToAdd = _context.Sauces.Find(SauceId);

        if (pizzaToUpdate is null || sauceToAdd is null)
            throw new InvalidOperationException("Pizza or Sauce not found.");

        pizzaToUpdate.Sauce = sauceToAdd;
        _context.SaveChanges();
    }
}

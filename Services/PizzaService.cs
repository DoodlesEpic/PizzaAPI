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

    public void Add(Pizza pizza) => throw new NotImplementedException();

    public void Delete(int Id) => throw new NotImplementedException();

    public void Update(Pizza pizza) => throw new NotImplementedException();

    public void AddTopping(int PizzaId, int ToppingId) => throw new NotImplementedException();

    public void UpdateSauce(int PizzaId, int SauceId) => throw new NotImplementedException();
}

using PizzaAPI.Models;

namespace PizzaAPI.Services;

public class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas =
        [
            new()
            {
                Id = 1,
                Name = "Classic Italian",
                IsGlutenFree = false
            },
            new()
            {
                Id = 2,
                Name = "Veggie",
                IsGlutenFree = true
            }
        ];
    }

    public List<Pizza> GetAll() => Pizzas;

    public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public void Delete(int Id)
    {
        var pizza = Get(Id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }

    public void AddTopping(int PizzaId, int ToppingId) => throw new NotImplementedException();

    public void UpdateSauce(int PizzaId, int SauceId) => throw new NotImplementedException();
}

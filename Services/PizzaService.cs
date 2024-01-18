using PizzaAPI.Models;

namespace PizzaAPI.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas =
        [
            new() {
                Id = 1,
                Name = "Classic Italian",
                IsGlutenFree = false
            },
            new() {
                Id = 2,
                Name = "Veggie",
                IsGlutenFree = true
            }
        ];
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int Id)
    {
        var pizza = Get(Id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }

    public static void AddTopping(int PizzaId, int ToppingId) => throw new NotImplementedException();
    public static void UpdateSauce(int PizzaId, int SauceId) => throw new NotImplementedException();
}

using PizzaAPI.Models;

namespace PizzaAPI.Services;

public class PizzaService
{
    PizzaService() { }

    public List<Pizza> GetAll() => throw new NotImplementedException();

    public Pizza? Get(int id) => throw new NotImplementedException();

    public void Add(Pizza pizza) => throw new NotImplementedException();

    public void Delete(int Id) => throw new NotImplementedException();

    public void Update(Pizza pizza) => throw new NotImplementedException();

    public void AddTopping(int PizzaId, int ToppingId) => throw new NotImplementedException();

    public void UpdateSauce(int PizzaId, int SauceId) => throw new NotImplementedException();
}

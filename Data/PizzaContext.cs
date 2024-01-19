using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;

namespace PizzaAPI.Data;

public class PizzaContext(DbContextOptions<PizzaContext> options) : DbContext(options)
{
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}

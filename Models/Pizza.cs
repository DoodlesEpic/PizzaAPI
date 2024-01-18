namespace PizzaAPI.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsGlutenFree { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _service;

    public PizzaController(PizzaService service) => _service = service;

    [HttpGet]
    public IEnumerable<Pizza> GetAll() => _service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _service.Get(id);
        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _service.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _service.Get(id);
        if (existingPizza is null)
            return NotFound();

        _service.Update(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _service.Get(id);
        if (pizza is null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var pizzaToUpdate = _service.Get(id);
        if (pizzaToUpdate is null)
            return NotFound();

        _service.AddTopping(id, toppingId);
        return NoContent();
    }

    [HttpPut("{id}/updatesauce")]
    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var pizzaToUpdate = _service.Get(id);
        if (pizzaToUpdate is null)
            return NotFound();

        _service.UpdateSauce(id, sauceId);
        return NoContent();
    }
}

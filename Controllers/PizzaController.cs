using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController(PizzaService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Pizza> GetAll() => service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = service.Get(id);
        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    [Authorize]
    public ActionResult Create(Pizza pizza)
    {
        service.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = service.Get(id);
        if (existingPizza is null)
            return NotFound();

        service.Update(pizza);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult Delete(int id)
    {
        var pizza = service.Get(id);
        if (pizza is null)
            return NotFound();

        service.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}/addtopping")]
    [Authorize]
    public ActionResult AddTopping(int id, int toppingId)
    {
        service.AddTopping(id, toppingId);
        return NoContent();
    }

    [HttpPut("{id}/updatesauce")]
    [Authorize]
    public ActionResult UpdateSauce(int id, int sauceId)
    {
        service.UpdateSauce(id, sauceId);
        return NoContent();
    }
}

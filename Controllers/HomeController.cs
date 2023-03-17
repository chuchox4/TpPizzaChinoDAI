using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_DAI_Brodsky_Rizzolo.Models;

namespace TP_DAI_Brodsky_Rizzolo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    } 
    [HttpGet]

public IActionResult GetAll() {

IActionResult respuesta;

List<Pizzas> entityList;

entityList = BD.GetAll();

respuesta = Ok(entityList);

return respuesta;

}
[HttpGet("{id}")]

public IActionResult GetById(int id) {

IActionResult respuesta = null;

Pizzas entity;

entity = BD.GetById(id);

if (entity == null) {

respuesta = NotFound();

} else {

respuesta = Ok(entity);

}

return respuesta;

}
[HttpPost]

public IActionResult Create(Pizzas pizza) {

int
intRowsAffected;

intRowsAffected = BD.Insert(pizza);

return CreatedAtAction(nameof(Create), new { id = pizza.IdPizza }, pizza);

}


}

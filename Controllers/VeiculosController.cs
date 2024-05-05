using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using veiculos.Models;

namespace veiculos.Controllers;

public class VeiculosController : Controller
{
    private readonly ILogger<Controller> _logger;

    public VeiculosController(ILogger<VeiculosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Veiculo(int id)
    {
        Repositorio<Veiculo> repo = new Repositorio<Veiculo>();
        Veiculo Veiculo = repo.Buscar(id);
        return View(Veiculo);
    }

    public IActionResult Veiculo()
    {
        return View();
    }

    public IActionResult Listar()
    {
        Repositorio<Veiculo> repo = new Repositorio<Veiculo>();
        List<Veiculo> lista = repo.Listar();
        return View(lista);
    }

    [HttpPost]
    public IActionResult Veiculo(Veiculo model)
    {
        Repositorio<Veiculo> repo = new Repositorio<Veiculo>();
        if(!ModelState.IsValid) {
            return View(model);
        }

        if (model.Id != null && model.Id != 0) {
            repo.Atualizar(model);
        } else {
            repo.Adicionar(model);
        }
        return RedirectToAction("Listar");
    }

    public IActionResult Apagar(int id)
    {
        Repositorio<Veiculo> repo = new Repositorio<Veiculo>();
        Veiculo Veiculo = repo.Buscar(id);
        
        if (Veiculo == null)
        {
            return NotFound();
        }

        return View(Veiculo);
    }

    [HttpPost]
    public IActionResult Apagar(Veiculo Veiculo)
    {
        Repositorio<Veiculo> repo = new Repositorio<Veiculo>();
        repo.Remover(Veiculo.Id);
        return RedirectToAction("Listar");
    }
}

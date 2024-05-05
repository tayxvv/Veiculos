using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using veiculos.Models;
using System.Text.Json;

namespace veiculos.Controllers;

public class ProdutosController : Controller
{
    private readonly ILogger<ProdutosController> _logger;

    public ProdutosController(ILogger<ProdutosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Produto()
    {
        return View();
    }

    public IActionResult Listar(int id = 0)
    {
        Repositorio<Produto> repo = new Repositorio<Produto>();
        Repositorio<Pessoa> repoPessoa = new Repositorio<Pessoa>();
        List<Produto> lista;
        if (id == 0) {
            lista = repo.Listar();
        } else {
            Pessoa pessoa = repoPessoa.Buscar(id);
            if (pessoa != null)
            {
                lista = repo.Listar().Where(produto => pessoa.ProdutosId.Contains(produto.Id)).ToList();
            }
            else
            {
                lista = new List<Produto>();
            }
        }
        return View(lista);
    }

    [HttpPost]
    public IActionResult Produto(Produto model)
    {   
        Repositorio<Produto> repo = new Repositorio<Produto>();
        repo.Adicionar(model);
        return RedirectToAction("Listar");
    }

    public IActionResult Editar(int id)
    {
        Repositorio<Produto> repo = new Repositorio<Produto>();
        Produto produto = repo.Buscar(id);
        
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    [HttpPost]
    public IActionResult Editar(Produto produto)
    {
        Repositorio<Produto> repo = new Repositorio<Produto>();
        repo.Atualizar(produto);

        
        return RedirectToAction("Listar");
    }

    public IActionResult Apagar(int id)
    {
        Repositorio<Produto> repo = new Repositorio<Produto>();
        Produto produto = repo.Buscar(id);
        
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    [HttpPost]
    public IActionResult Apagar(Produto produto)
    {
        Repositorio<Produto> repo = new Repositorio<Produto>();
        repo.Remover(produto.Id);
        return RedirectToAction("Listar");
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using veiculos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using veiculos.Models.ViewModel;

namespace veiculos.Controllers;

public class PessoasController : Controller
{
    private readonly ILogger<Controller> _logger;

    private readonly IWebHostEnvironment _appEnvironment;

    public PessoasController(ILogger<PessoasController> logger, IWebHostEnvironment appEnvironment)
    {
        _logger = logger;
        _appEnvironment = appEnvironment;
    }

    [HttpGet]
    public IActionResult Pessoa(int id = 0)
    {
        Repositorio<Produto> repoProduto = new Repositorio<Produto>();
        Repositorio<Pessoa> repoPessoa = new Repositorio<Pessoa>();
        List<Pessoa> pessoas = repoPessoa.Listar();

        List<Produto> produtos = repoProduto.Listar();
        List<Produto> retProdutos = repoProduto.Listar();

        foreach (Pessoa pessoa in pessoas)
        {
            foreach (Produto produto in produtos)
            {
                if (!pessoa.ProdutosId.Contains(produto.Id)) {
                    retProdutos.Add(produto);
                }
            }
        }

        Pessoa model = repoPessoa.Buscar(id);

        Repositorio<Veiculo> repoVeiculo = new Repositorio<Veiculo>();
        if (model != null)
        {
            ViewBag.Veiculo = new SelectList(repoVeiculo.Listar(), "Id", "Nome", model.VeiculosId);
        }
        else
        {
            ViewBag.Veiculo = new SelectList(repoVeiculo.Listar(), "Id", "Nome");
        }

        PessoaViewModel? viewModel = model != null ? new PessoaViewModel(model) : null;

        return View(viewModel);
    }

    public IActionResult Listar()
    {
        Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
        List<PessoaViewModel> lista = repo.Listar().Select(p => new PessoaViewModel(p)).ToList();
        return View(lista);
    }

    [HttpPost]
    public IActionResult Pessoa(PessoaViewModel model, IFormFile anexo)
    {   
        Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
        if(!ModelState.IsValid) {
            Repositorio<Produto> repoProduto = new Repositorio<Produto>();
            
            ViewBag.Produto = new SelectList(repoProduto.Listar(), "Id", "Descricao", model.ProdutosId);
            return View(model);
        }

        string caminho = _appEnvironment.WebRootPath + "//imagens//" + anexo.FileName;
        using(FileStream stream = new FileStream(caminho, FileMode.Create))
        {
            anexo.CopyTo(stream);
        }

        model.Imagem = "//imagens//" + anexo.FileName;

         if (model.Id != null && model.Id != 0) {
            repo.Atualizar(model.Parse());
        } else {
            repo.Adicionar(model.Parse());
        }
        return RedirectToAction("Listar");
    }

    // public IActionResult Editar(int id)
    // {
    //     Repositorio<Produto> repoProduto = new Repositorio<Produto>();
    //     ViewBag.Produto = new SelectList(repoProduto.Listar(), "Id", "Descricao", model.ProdutosId);
    //     Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
    //     Pessoa pessoa = repo.Buscar(id);
        
    //     if (pessoa == null)
    //     {
    //         return NotFound();
    //     }

    //     return View(pessoa);
    // }

    // [HttpPost]
    // public IActionResult Editar(Pessoa pessoa)
    // {
    //     Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
    //     repo.Atualizar(pessoa);

        
    //     return RedirectToAction("Listar");
    // }

    public IActionResult Apagar(int id)
    {
        Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
        Pessoa pessoa = repo.Buscar(id);
        
        if (pessoa == null)
        {
            return NotFound();
        }

        return View(pessoa);
    }

    [HttpPost]
    public IActionResult Apagar(Pessoa pessoa)
    {
        Repositorio<Pessoa> repo = new Repositorio<Pessoa>();
        repo.Remover(pessoa.Id);
        return RedirectToAction("Listar");
    }
}

using System.ComponentModel.DataAnnotations;
namespace veiculos.Models.ViewModel;
using veiculos.Models;

public class PessoaViewModel
{

    public PessoaViewModel(Pessoa model) {

    }

    public PessoaViewModel() 
    {
    }

    public PessoaViewModel(PessoaViewModel model)
    {
        this.Id = model.Id;
        this.Nome = model.Nome;
        this.Idade = model.Idade;
        this.Endereco = model.Endereco;
        this.Cidade = model.Cidade;
        this.CPF = model.CPF;
        this.Telefone = model.Telefone;
        this.ProdutosId = model.ProdutosId;
        this.Imagem = model.Imagem;
        this.QuantidadeProdutosId = model.ProdutosId.Count();
    }

    public Pessoa Parse()
    {
        return new Pessoa{
            Id = this.Id,
            Nome = this.Nome,
            Idade = this.Idade,
            Endereco = this.Endereco,
            Cidade = this.Cidade,
            CPF = this.CPF,
            Telefone = this.Telefone,
            Imagem = this.Imagem,
        };
    }

    public int Id { get; set; }
    [Required(ErrorMessage="O campo nome é obrigatório")]
    [Display(Name = "Nome")]
    public string? Nome { get; set; }
    [Required(ErrorMessage="O campo Idade é obrigatório")]
    [Display(Name = "Idade")]
    [Range(1,200,ErrorMessage="A idade está em um intervalo inválido")]
    public int? Idade { get; set; }
    [Required(ErrorMessage="O campo Sobrenome é obrigatório")]
    [Display(Name = "Sobrenome")]
    public string? Sobrenome { get; set; }
    [Required(ErrorMessage="O campo Endereco é obrigatório")]
    [Display(Name = "Endereco")]
    public string? Endereco { get; set; }
    [Required(ErrorMessage="O campo Cidade é obrigatório")]
    [Display(Name = "Cidade")]
    public string? Cidade { get; set; }
    [Required(ErrorMessage="O campo CPF é obrigatório")]
    [Display(Name = "CPF")]
    public long? CPF { get; set; }
    [Required(ErrorMessage="O campo Telefone é obrigatório")]
    [Display(Name = "Telefone")]
    public long? Telefone { get; set; }

    // [DataType(DataType.Date)]
    // public DateTime? DataNascimento { get; set; }

    public IEnumerable<int> ProdutosId{ get; set; }

    public IEnumerable<int> VeiculosId{ get; set; }

    public int QuantidadeProdutosId{ get; set; }

    public string Imagem { get; set; }
}

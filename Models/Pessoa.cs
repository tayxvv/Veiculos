using System.ComponentModel.DataAnnotations;
namespace veiculos.Models;

public class Pessoa : Entity
{
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

    public string Imagem{ get; set; }
}

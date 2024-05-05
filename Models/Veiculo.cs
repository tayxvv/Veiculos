namespace veiculos.Models;
using System.ComponentModel.DataAnnotations;

public class Veiculo : Entity
{
    [Required(ErrorMessage="O campo placa é obrigatório")]
    public string? Placa { get; set; }
    [Required(ErrorMessage="O campo Chassis é obrigatório")]
    public string? Chassis { get; set; }
    [Required(ErrorMessage="O campo Tipo é obrigatório")]
    public string? Tipo { get; set; }
    [Required(ErrorMessage="O campo ano fabricação é obrigatório")]
    public string? AnoFabricacao { get; set; }
    [Required(ErrorMessage="O campo ano modelo é obrigatório")]
    public string? AnoModelo { get; set; }
    [Required(ErrorMessage="O campo nome é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage="O campo marca é obrigatório")]
    public string? Marca { get; set; }
    [Required(ErrorMessage="O campo potencia é obrigatório")]
    public string? Potencia { get; set; }
    [Required(ErrorMessage="O campo data de compra é obrigatório")]
    public string? DataDeCompra { get; set; }
    [Required(ErrorMessage="O campo estado é obrigatório")]
    public string? Estado { get; set; }
}
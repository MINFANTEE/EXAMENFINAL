namespace FINANZASAPP2022INFANTE.Models;

public class Cuenta
{
    public int Id { get; set; } 
    public string nombre { get; set; }
    public string categoria { get; set; }
    public decimal saldoInicial { get; set; }
    public string moneda { get; set; }
    
    public int TipoCuentaId { get; set; }
    public TipoCuenta? TipoCuenta {get; set; }
}
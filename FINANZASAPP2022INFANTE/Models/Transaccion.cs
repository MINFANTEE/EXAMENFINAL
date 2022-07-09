namespace FINANZASAPP2022INFANTE.Models;

public class Transaccion
{
    public int Id { get; set; } 
    public int idCuenta { get; set; } 
    public DateTime fecha { get; set; }
    public string descripcion { get; set; }
    public decimal monto { get; set; }
    public string tipo { get; set; }
    public int CuentaID { get; set; }
    
    
   

}
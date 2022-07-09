using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;
using Microsoft.EntityFrameworkCore;

namespace FINANZASAPP2022INFANTE.Repositories;

public interface ICuentaRepositorio
{
    Cuenta ObtenerCuentaPorId(int id);
    List<Cuenta> ObtenerCuentasDeUsuario(int UserId);
    void GuardarCuenta(Cuenta cuenta);
    Cuenta EditarCuentaPorId(int id);
    Cuenta DeleteCuenta(int id);
    List<Cuenta> ObtenerTodos();
}

public class CuentaRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public CuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    public Cuenta ObtenerCuentaPorId(int id)
    {
        return _dbEntities.Cuentas.First(o => o.Id == id); 
       
    }

    public List<Cuenta> ObtenerCuentasDeUsuario(int UserId)
    {
        return _dbEntities.Cuentas
            .Include(o => o.TipoCuenta)
            .Where(o => o.TipoCuentaId == UserId).ToList();
    }

    public void GuardarCuenta(Cuenta cuenta)
    {
        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
    }

    public List<Cuenta> ObtenerTodos()
    {
        return _dbEntities.Cuentas
            .Include(o=> o.TipoCuenta)
            .ToList();
        
    }

    public Cuenta DeleteCuenta(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);
        
        return cuentaDb;
    }

    public Cuenta EditarCuentaPorId(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);

        return cuentaDb;

    }
}
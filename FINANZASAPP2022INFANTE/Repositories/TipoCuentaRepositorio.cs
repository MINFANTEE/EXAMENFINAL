using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;

namespace FINANZASAPP2022INFANTE.Repositories;

public interface ITipoCuentaRepositorio
{
    void Guardar(TipoCuenta tipoCuenta);
    List<TipoCuenta> ObtenerTodos();
    List<TipoCuenta> ObtenerPorNombre(string nombre);
}

public class TipoCuentaRepositorio: ITipoCuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public TipoCuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }

    public void Guardar(TipoCuenta tipoCuenta)
    {
        _dbEntities.TipoCuentas.Add(tipoCuenta);
        _dbEntities.SaveChanges(); 
    }
    public List<TipoCuenta> ObtenerTodos()
    {
        return _dbEntities.TipoCuentas.ToList();
    }

    public List<TipoCuenta> ObtenerPorNombre(string nombre)
    {
        return _dbEntities.TipoCuentas.Where(o => o.nombre.Contains(nombre)).ToList();
    }
}
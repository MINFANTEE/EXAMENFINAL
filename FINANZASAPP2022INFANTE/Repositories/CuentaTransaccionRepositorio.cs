using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;

namespace FINANZASAPP2022INFANTE.Repositories;

public interface ICuentaTransaccionRepositorio
{
    List<Transaccion> ListaCuentaTransacciones(int cuentaId);
}

public class CuentaTransaccionRepositorio : ICuentaTransaccionRepositorio
{
    private DbEntities _dbEntities;

    public CuentaTransaccionRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }

    public List<Transaccion> ListaCuentaTransacciones(int cuentaId)
    {
        return DbEntities.Transacciones.Where(o => o.idCuenta == cuentaId).ToList();
    }
}

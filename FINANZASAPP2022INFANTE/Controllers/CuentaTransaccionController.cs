using System.Linq;
using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINANZASAPP2022INFANTE.Controllers;

public class CuentaTransaccionController : Controller
{
    private readonly ICuentaTransaccionRepositorio _cuentaTransaccionRepositorio;
    private DbEntities _dbEntities;
    
    
    public CuentaTransaccionController(ICuentaTransaccionRepositorio cuentaTransaccionRepositorio,
        DbEntities dbEntities)
    {
        _cuentaTransaccionRepositorio = cuentaTransaccionRepositorio;
        _dbEntities = dbEntities;
    
    }
    
    
    [HttpGet]
    public IActionResult Index(int cuentaId)
    {
        
        //var items = DbEntities.Transacciones.Where(o => o.CuentaId == cuentaId).ToList();
        var items = _cuentaTransaccionRepositorio.ListaCuentaTransacciones(cuentaId);
        ViewBag.CuentaId = cuentaId;
        ViewBag.Total = items.Any() ? items.Sum(x => x.monto) : 0;

        return View(items);
        
    }
    
    [HttpGet]
    public IActionResult Create(int cuentaId)
    {
        ViewBag.CuentaId = cuentaId;
        return View(new Transaccion());
    }
    
    [HttpPost]
    public IActionResult Create(int cuentaId, Transaccion transaccion)
    {
        transaccion.Id = GetNextId();
        transaccion.idCuenta = cuentaId;
        if (transaccion.tipo == "GASTO")
            transaccion.monto *= -1;
        
        DbEntities.Transacciones.Add(transaccion);

        return RedirectToAction("Index", new { cuentaId = cuentaId});
    }
    
    public int GetNextId()  {
        if (DbEntities.Transacciones.Count == 0)
            return 1;
        return DbEntities.Transacciones.Max(o => o.Id) + 1;
    }
}
using System.Linq;
using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINANZASAPP2022INFANTE.Controllers;

public class CuentaController : Controller
{
    private readonly ITipoCuentaRepositorio _tipoCuentaRepositorio;
    private readonly ICuentaRepositorio _cuentaRepositorio;
    private DbEntities _dbEntities;

    public CuentaController(ITipoCuentaRepositorio tipoCuentaRepositorio, ICuentaRepositorio cuentaRepositorio,
        DbEntities dbEntities)
    {
        _tipoCuentaRepositorio = tipoCuentaRepositorio;
        _cuentaRepositorio = cuentaRepositorio;
        _dbEntities = dbEntities;


    }

    [HttpGet]
    public IActionResult Index()
    {
        var cuentas = _cuentaRepositorio.ObtenerTodos();
        ViewBag.Total = cuentas.Any() ? cuentas.Sum(o => o.saldoInicial) : 0; 
        return View(cuentas);
        
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.TipoDeCuentas = _tipoCuentaRepositorio.ObtenerTodos();
        return View(new Cuenta());
    }

    [HttpPost]
    public IActionResult Create(Cuenta cuenta)
    {
        
        if (cuenta.TipoCuentaId > 6 || cuenta.TipoCuentaId < 1)
        {
            ModelState.AddModelError("TipoCuentaId", "Tipo de cuenta no exite");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.TipoDeCuentas = _tipoCuentaRepositorio.ObtenerTodos();
            return View("Create", cuenta);
        }

        _cuentaRepositorio.GuardarCuenta(cuenta);
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cuenta = _cuentaRepositorio.ObtenerCuentaPorId(id);
        //ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
        ViewBag.TipoDeCuentas = _tipoCuentaRepositorio.ObtenerTodos();
        return View(cuenta);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Cuenta cuenta)
    {
        if (!ModelState.IsValid) {
            ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
            return View("Edit", cuenta);
        }
        
        var cuentaDb = _cuentaRepositorio.EditarCuentaPorId(id);
        cuentaDb.nombre = cuenta.nombre;
        //_dbEntities.SaveChanges();

        _cuentaRepositorio.EditarCuentaPorId(id);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cuentaDb = _cuentaRepositorio.DeleteCuenta(id);
        cuentaDb.Id = id;
        _cuentaRepositorio.DeleteCuenta(id);
        return RedirectToAction("Index");
    }

    
}
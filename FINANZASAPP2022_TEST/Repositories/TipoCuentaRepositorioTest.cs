using System.Collections.Generic;
using System.Linq;
using FinancialApp.Tests.Helpers;
using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Repositories;

public class TipoCuentaRepositorioTest
{
    private IQueryable<TipoCuenta> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<TipoCuenta>
        {
            new() { Id = 1, nombre = "Credito" },
            new() { Id = 2, nombre = "Debito" }
            
        }.AsQueryable();
        
        var mockDbsetTipoCuenta = new MockDBSet<TipoCuenta>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);

    }
    
    [Test]
    public void ObtenerTodosTest_TEST01()
    {
       
        var mockDbsetTipoCuenta = (new MockDBSet<TipoCuenta>(data));
        
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);
        
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();

        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void ObtenerPorNombreTest_TEST02()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Credito");

        Assert.AreEqual(1, result.Count);
    }
    
    
    [Test]
    public void ObtenerPorNombreTest_TEST03()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Efectivo");

        Assert.AreEqual(0, result.Count);
    }
}
 
using System.Collections.Generic;
using System.Linq;
using FinancialApp.Tests.Helpers;
using FINANZASAPP2022INFANTE.DB;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Repositories;

public class CuentaRepositorioTest
{
    private IQueryable<Cuenta> data;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Cuenta>
        {
            new() { Id = 1, nombre = "Cuenta 01"},
            new() { Id = 2, nombre = "Cuenta 02"},
            new() { Id = 3, nombre = "Cuenta 03"},
        }.AsQueryable();
    }
    
    [Test]
    public void ObtenerTodosTest_TEST02()
    {
       
        var mockDbSetCuenta = new MockDBSet<Cuenta>(data);
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbSetCuenta.Object);
        
        var repo = new CuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();
        
        Assert.AreEqual(3, result.Count);
    }
}
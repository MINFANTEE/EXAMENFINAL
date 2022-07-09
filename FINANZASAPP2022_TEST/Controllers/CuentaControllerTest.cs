using System.Collections.Generic;
using System.Security.Claims;

using FINANZASAPP2022INFANTE.Controllers;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void CreateView_TEST01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new CuentaController(mockTipoRepositorio.Object, null, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }
    
   
    /*
     
      [Test]
    public void EditView_TEST02()
    { 
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerCuentaPorId(2)).Returns(new Cuenta{Id = 1, nombre = "Joel", saldoInicial = 25});
        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        var view = (ViewResult)controller.Edit(2);
        
        Assert.IsNotNull(view.Model);
        Assert.IsNotNull(view);
       
    }
*/
   
    
    [Test]
    public void postCrear_TEST04()
    {
        
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim> {new Claim(ClaimTypes.Name, "admin")});
        
        var mockContex = new Mock<HttpContext>();
        mockContex.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockRepositorio = new Mock<ICuentaRepositorio>();
       
        var controller = new CuentaController(null, mockRepositorio.Object, null);
         
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };
        
        
        var result = controller.Create(new Cuenta(){TipoCuentaId = 2});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }
    
    [Test]
    public void postCrearCharsh_TEST05()
    {
        
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim> {new Claim(ClaimTypes.Name, "admin")});
        
        var mockContex = new Mock<HttpContext>();
        mockContex.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockRepositorio = new Mock<ICuentaRepositorio>();

        var mockTipoCuentaRepo = new Mock<ITipoCuentaRepositorio>();
       
        var controller = new CuentaController(mockTipoCuentaRepo.Object, mockRepositorio.Object, null);
         
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };
        
        
        var result = controller.Create(new Cuenta(){TipoCuentaId = 7});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public void DeleteView_TEST06()
    { 
       
        var mockCuentaRepositorioDelete = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorioDelete.Setup(o => o.DeleteCuenta(2)).Returns(new Cuenta{Id = 1, nombre = "AHORRO", saldoInicial = 25});
        var controller = new CuentaController(null,mockCuentaRepositorioDelete.Object, null);
        var view = controller.Delete(2);
        
        Assert.IsNotNull(view);
       
    }

    [Test]
    public void postEditController_TEST07()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.EditarCuentaPorId(2)).Returns(new Cuenta{Id = 1, nombre = "BCP", saldoInicial = 25});
       // var mockDB = new Mock<DbEntities>();
        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        
        var view = controller.Edit(2);
        
        Assert.IsNotNull(view);
    }
}
using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

using FINANZASAPP2022INFANTE.Controllers;
using FINANZASAPP2022INFANTE.Models;
using FINANZASAPP2022INFANTE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Tests.Controllers
{
    internal class CuentaTransaccionControllerTest
    {
        private readonly ICuentaTransaccionRepositorio _cuentaTransaccionRepositorio;

        [Test]
        public void IndexView_TEST01()
        {
            var mockListaTransaccion = new Mock<ICuentaTransaccionRepositorio>();
            mockListaTransaccion.Setup(o => o.ListaCuentaTransacciones(1)).Returns(new List<Transaccion> { new Transaccion() });

            var controller = new CuentaTransaccionController(mockListaTransaccion.Object, null);
            var view = controller.Index(1);

            Assert.IsNotNull(view);
        }

        [Test]
        public void CreateView_TEST02()
        {
            var controller = new CuentaTransaccionController(null, null);
            var createView = controller.Create(1);

            Assert.IsNotNull(createView);
        }

        [Test]
        public void CreateViewPost_TEST03()
        {
            var controller = new CuentaTransaccionController(null, null);
            var createView = controller.Create(1, new Transaccion() { tipo = "Gasto", monto = 100});

            Assert.IsNotNull(createView);
            Assert.IsInstanceOf<RedirectToActionResult>(createView);
        }
    }
}
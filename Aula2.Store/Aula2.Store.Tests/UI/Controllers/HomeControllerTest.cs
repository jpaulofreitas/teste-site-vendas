using Aula2.Store.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Aula2.Store.Tests.UI.Controllers
{
    [TestClass, TestCategory("Controllers/HomeController")]
    public class HomeControllerTest
    {
        //Dado do HomeController
        [TestMethod]
        public void OMetodoIndexDeveRetornarUmaView()
        {
            //A - arrange
            var homeController = new HomeController();

            //A - act
            //Necessario instalar o pacote o MVC neste projeto
            var result = homeController.Index();

            //A - Assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }
        
    }
}

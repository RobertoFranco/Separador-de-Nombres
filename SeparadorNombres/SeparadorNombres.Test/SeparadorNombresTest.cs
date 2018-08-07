
namespace SeparadorNombres.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SeparadorNombresTest
    {
        [TestMethod]
        public void Test1()
        {
            var nombres = new List<string> { "JOSE LUIS REYNOSO ALVAREZ" };

            var separador = new SeparadorNombres(nombres);
            var persona = separador.Personas.First().Value;

            Assert.AreEqual("JOSE LUIS", persona.Nombres);
        }

        [TestMethod]
        public void Test2()
        {
            var nombres = new List<string> { "JUAN ROMO" };

            var separador = new SeparadorNombres(nombres);
            var persona = separador.Personas.First().Value;

            Assert.AreEqual("JUAN", persona.Nombres);
            Assert.AreEqual("ROMO", persona.Paterno);
        }
    }
}

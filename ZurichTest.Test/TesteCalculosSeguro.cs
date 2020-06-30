using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.Test
{
    [TestClass]
    public class TesteCalculosSeguro
    {
        readonly Seguro seguro = new Seguro()
        {
            Veiculo = new Veiculo()
            {
                Valor = 10000
            }
        };
        [TestMethod]
        public void TesteCalculoDaTaxaDeRisco()
        {
            Assert.IsTrue(seguro.TaxaDeRisco() == 0.025);
        }
        [TestMethod]
        public void TesteCalculoDoPremioDeRisco()
        {
            Assert.IsTrue(seguro.PremioDeRisco() == 250);
        }
        [TestMethod]
        public void TesteCalculoDePremioPuro()
        {
            Assert.IsTrue(seguro.PremioPuro() == 257.50);
        }
        [TestMethod]
        public void TestePremioComercial()
        {
            Assert.IsTrue(seguro.PremioComercial() == 270.375);
        }
    }
}

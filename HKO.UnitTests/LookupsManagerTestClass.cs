using System.Linq;
using HKO.BLL.Managers.Lookups;
using NUnit.Framework;

namespace HKO.UnitTests
{
    [TestFixture]
    public class LookupsManagerTestClass
    {

        [Test]
        public void GetZupanije()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetZupanije();

            // Assert
            Assert.AreEqual(response.Count(), 22);
        }

        [Test]
        public void GetZupanijaByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetZupanijeByID(1);

            // Assert
            Assert.AreEqual(response.Naziv, "Zagrebačka županija");
        }

        [Test]
        public void GetUgovorORadu()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetUgovorORadu();

            // Assert
            Assert.AreEqual(response.Count(), 17);
        }

        [Test]
        public void GetUgovorORaduByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetUgovorORaduByID(10);

            // Assert
            Assert.AreEqual(response.Naziv, "ugovor o radu na neodređeno vrijeme i više se ne koristi");
        }

        [Test]
        public void GetStrucnoObrazovanje()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetStrucnoObrazovanje();

            // Assert
            Assert.AreEqual(response.Count(), 12);
        }

        [Test]
        public void GetStrucnoObrazovanjeByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetStrucnoObrazovanjeByID(10);

            // Assert
            Assert.AreEqual(response.Naziv, "VSS DR.");
        }

        [Test]
        public void GetNkz98()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetNkz98();

            // Assert
            Assert.AreEqual(response.Count(), 3846);
        }

        [Test]
        public void GetNkz98ByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetNkz98ByID("2146.51.8");

            // Assert
            Assert.AreEqual(response.Naziv, "Istraživač/istraživačica kemijske tehnologije");
        }

        [Test]
        public void GetNkz7()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetNkz7();

            // Assert
            Assert.AreEqual(response.Count(), 3869);
        }

        [Test]
        public void GetNkz7ByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetNkz7ByID("2141207");

            // Assert
            Assert.AreEqual(response.Naziv, "diplomirani inženjer arhitekture");
        }

        [Test]
        public void GetHkoSifre()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetHkoSifre();

            // Assert
            Assert.AreEqual(response.Count(), 26);
        }

        [Test]
        public void GetHkoSifreByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetHkoSifreByID("0100");

            // Assert
            Assert.AreEqual(response.Naziv, "POLJOPRIVREDA, PREHRANA I VETERINA");
        }


        [Test]
        public void GetGradoviOpcine()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetGradoviOpcine();

            // Assert
            Assert.AreEqual(response.Count(), 556);
        }

        [Test]
        public void GetGradoviOpcineByID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetGradoviOpcineByID(1);

            // Assert
            Assert.AreEqual(response.Naziv, "Andrijaševci");
        }

        [Test]
        public void GetGradoviOpcineByZupanijaID()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetGradoviOpcineByZupanijaID(1);

            // Assert
            Assert.AreEqual(response.Count(), 34);
        }

        [Test]
        public void GetKljucneDjelatnosti()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetKljucneDjelatnosti();

            // Assert
            Assert.AreEqual(response.Count(), 88);
        }

        [Test]
        public void GetDefaultTimeframe()
        {
            // Arrange
            var manager = new LookupsManager();

            // Act
            var response = manager.GetDefaultTimeframe();

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
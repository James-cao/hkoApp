using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HKO.BLL.Managers.Sektori;
using NUnit.Framework;

namespace HKO.UnitTests
{
    [TestFixture]
    public class SektoriManagerTestClass
    {
        [Test]
        public void GetSektorskaZanimanjaPremaRodovima()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetSektorskaZanimanjaPremaRodovima("0200","-1");

            // Assert
            Assert.AreEqual(response.Count(), 4);
        }

        [Test]
        public void GetSektorURadnojSnazi()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetSektorRadnaSnaga("0100", 8, 2016);

            // Assert
            Assert.Greater(response.Count(),0);
        }

        [Test]
        public void GetPodsektoriUSektoru()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetPodsektoriUSektoru("0100", 8, 2016).FirstOrDefault();

            // Assert
            if (response != null) Assert.AreEqual(response.Broj_U_Podsektoru, 12491);
        }

        [Test]
        public void GetSektorskaZanimanjaDjelatnosti()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetSektorskaZanimanjaDjelatnosti("0100", 8, 2016, "1");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetBrojSektorskihZanimanjaRh()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetBrojSektorskihZanimanjaRH("0100");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetZaposlenostBroj()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetZaposlenostBroj("0100", 8, 2016,"-1", "1");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetZaposlenostStopa()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetZaposlenostStopa("0100", 8, 2016,"-1", "1");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetZaposlenostUdjelRodovi()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetZaposlenostUdjeliRodovi("0100", 8, 2016, null,null);

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetNezaposlenostUdjelRodovi()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetNezaposlenostUdjeliRodovi("0100", 8, 2016, null, null);

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetObuhvatSektora()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetObuhvatSektora("0100", 8, 2016, null);

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetKljucneDjelatnosti()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetKljucneDjelatnosti("0100", 8, 2016, null,"1");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetSektorDob()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetSektorDob("0100", 8, 2016, null, "1","-1");

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void GetZaposljavanjeKljucDjel()
        {
            // Arrange
            var manager = new SektoriManager();

            // Act
            var response = manager.GetZaposljavanjeKljucDjelatnosti("2000", "2014", "6", "20");

            // Assert
            Assert.GreaterOrEqual(response.Count(), 15);
        }
    }
}
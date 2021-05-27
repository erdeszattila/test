using NUnit.Framework;
using Moq;

namespace ConsoleApp2.Test
{
    [TestFixture]
    public class EngineTests
    {
        Mock<IFuelTank> mock_FuelTank;
        IEngine engine;

        [SetUp]
        public void Setup()
        {
            mock_FuelTank = new Mock<IFuelTank>();
            engine = new Engine(mock_FuelTank.Object);
        }

        [Test]
        [Description("If tank has enough fuel, when engine starts it returns 800 as RPM")]
        public void GivenTankHasFuel_WhenEngineStarts_ThenItReturns800AsRPM()
        {
            //Arrange
            mock_FuelTank.Setup(f => f.HasFuel()).Returns(true);
            //Act
            var expectedReturn = engine.Start();
            //Assert
            Assert.That(expectedReturn, Is.EqualTo(800));
        }

        [Test]
        [Description("If engine starts, it calls FuelTank.HasFuel() method")]
        public void WhenEngineStarts_ThenItCallsFuelTankHasFuelMethod()
        {
            //Act
            engine.Start();
            //Assert
            mock_FuelTank.Verify(f => f.HasFuel(), Times.Once());
        }

        [Test]
        [Description("If tank has no fuel, when engine starts it returns 0 as RPM")]
        public void GivenTankHasNoFuel_WhenEngineStarts_ThenItReturns0AsRPM()
        {
            //Arrange
            mock_FuelTank.Setup(f => f.HasFuel()).Returns(false);
            //Act
            var expectedReturn = engine.Start();
            //Assert
            Assert.That(expectedReturn, Is.EqualTo(0));
        }



        [Test]
        [Description("When engine stops, it returns 0 as RPM")]
        public void WhenEngineStops_ThenItReturns0AsRPM()
        {
            //Act
            var expectedReturn = engine.Stop();
            //Assert
            Assert.That(expectedReturn, Is.EqualTo(0));
        }
    }
}

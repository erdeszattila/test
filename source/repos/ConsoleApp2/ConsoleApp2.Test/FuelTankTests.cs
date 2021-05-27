using NUnit.Framework;
using Moq;
using System;

namespace ConsoleApp2.Test
{
    [TestFixture]
    class FuelTankTests
    {
        IFuelTank fuelTank;

        [SetUp]
        public void Setup()
        {
            fuelTank = new FuelTank();
        }

        [Test]
        [Description("Testing Fill method")]
        public void WhenCallFillMethod_ThenItSetsFuelLevelAppropiately()
        {
            //Arrange
            var randomNumber = new Random().Next(100);
            //Act
            fuelTank.Fill(randomNumber);
            //Assert
            Assert.That(fuelTank.FuelLevel, Is.EqualTo(randomNumber));
        }

        [Test]
        [Description("If FuelLevel is 0, HasFuel() returns false")]
        public void GivenFuelLevelIs0_WhenCallHasFuelMethod_ThenItReturnsFalse()
        {
            //Arrange
            fuelTank.FuelLevel = 0;
            //Act
            var expectedReturn = fuelTank.HasFuel();
            //Assert
            Assert.That(expectedReturn, Is.False);
        }

        [Test]
        [Description("If FuelLevel is not 0, HasFuel() returns true")]
        public void GivenFuelLevelIsNot0_WhenCallHasFuelMethod_ThenItReturnsTrue()
        {
            //Arrange
            fuelTank.FuelLevel = new Random().Next(100);
            //Act
            var expectedReturn = fuelTank.HasFuel();
            //Assert
            Assert.That(expectedReturn, Is.True);
        }
    }
}

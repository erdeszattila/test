using System;
using NUnit.Framework;
using Moq;

namespace ConsoleApp2.Test
{
    [TestFixture]
    class FuelLampTests
    {
        ILowFuelWarningLamp fuelLamp;

        [SetUp]
        public void Setup()
        {
            fuelLamp = new LowFuelWarningLamp();
        }

        [Test]
        [Description("Testing setter and getter for LowFuelWarningLamp")]
        public void WhenFuelLampSetterSetsValue_ThenFuelLampGetterReturnsTheSame()
        {
            //Arrange
            var randomBool = new Random().Next(2) == 1;
            fuelLamp.IsItOn = randomBool;
            //Act
            var expectedResult = fuelLamp.IsItOn;
            //Assert
            Assert.IsTrue(expectedResult == randomBool);
        }
    }
}


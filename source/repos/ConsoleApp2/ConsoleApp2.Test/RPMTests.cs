using System;
using NUnit.Framework;

namespace ConsoleApp2.Test
{
    [TestFixture]
    class RPMTests
    {
        IRPM rpm;

        [SetUp]
        public void Setup()
        {
            rpm = new RPM();
        }

        [Test]
        [Description("Testing setter and getter for RPM")]
        public void WhenRPMSetterSetsValue_ThenRPMGetterReturnsTheSame()
        {
            //Arrange
            var randomNumber = new Random().Next(10000);
            rpm.RoundPerMinute = randomNumber;
            //Act
            var expectedResult = rpm.RoundPerMinute;
            //Assert
            Assert.That(expectedResult, Is.EqualTo(randomNumber));
        }
    }
}

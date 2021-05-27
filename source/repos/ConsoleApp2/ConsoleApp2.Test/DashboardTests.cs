using NUnit.Framework;
using Moq;

namespace ConsoleApp2.Test
{
    [TestFixture]
    public class DashboardTests
    {
        Mock<IEngine> mock_Engine;
        Mock<IRPM> mock_RPM;
        Mock<ILowFuelWarningLamp> mock_FuelLamp;
        IDashboard dashboard;

        [SetUp]
        public void Setup()
        {
            mock_Engine = new Mock<IEngine>();
            mock_RPM = new Mock<IRPM>();
            mock_FuelLamp = new Mock<ILowFuelWarningLamp>();
            dashboard = new Dashboard(
                mock_Engine.Object, mock_RPM.Object, mock_FuelLamp.Object);
        }

        [Test]
        [Description("If engine starts, dashboard sets RPM to 800")]
        public void GivenEnginesStarts_WhenDashboardTriesToStartEngine_ThenSetRPMto800() 
        {
            //Arrange
            mock_Engine.Setup(e => e.Start()).Returns(800);
            //Act
            dashboard.EngineStart();
            //Assert
            mock_RPM.VerifySet(r => r.RoundPerMinute = 800);
        }

        [Test]
        [Description("If dashboard starts, it calls Engine.Start() method")]
        public void GivenEnginesStarts_WhenDashboardTriesToStartEngine_ThenEngineStartMethodCalled()
        {
            //Arrange
            mock_Engine.Setup(e => e.Start()).Returns(800);
            //Act
            dashboard.EngineStart();
            //Assert
            mock_Engine.Verify(e => e.Start(), Times.Once());
        }

        [Test]
        [Description("Fuel lamp is on if engine does not start")]
        public void GivenEngineDoesNotStart_WhenDashboardStartsEngine_ThenFuelLampIsOn()
        {
            //Arrange
            mock_Engine.Setup(e => e.Start()).Returns(0);
            //Act
            dashboard.EngineStart();
            //Assert
            mock_FuelLamp.VerifySet(fl => fl.IsItOn = true);
        }

        [Test]
        [Description("If engine stops, dashboard sets RPM to 0")]
        public void GivenEngineStops_WhenDashboardStartEnging_ThenSetRPMto0()
        {
            //Act
            dashboard.EngineStop();
            //Assert
            mock_RPM.VerifySet(r => r.RoundPerMinute = 0);
        }

        [Test]
        [Description("If dashboard stops, it calls Engine.Stop() method")]
        public void GivenEngineStops_WhenDashboardStartEnging_ThenEngineStopMethodCalled()
        {
            //Act
            dashboard.EngineStop();
            //Assert
            mock_Engine.Verify(e => e.Stop(), Times.Once());
        }
    }
}

namespace ConsoleApp2
{

    public class Dashboard: IDashboard
    {
        IEngine engine;
        IRPM rpm;
        ILowFuelWarningLamp lowFuelLamp; 

        public Dashboard(IEngine engine, IRPM rpm, ILowFuelWarningLamp lowFuelLamp)
        {
            this.engine = engine;
            this.rpm = rpm;
            this.lowFuelLamp = lowFuelLamp;
        }
        public void EngineStart()
        {
            if(engine.Start() == 800)
            {
                rpm.RoundPerMinute = 800;
            }
            else
            {
                lowFuelLamp.IsItOn = true;
            }
        }

        public void EngineStop()
        {
            rpm.RoundPerMinute = engine.Stop();
        }
    }
}

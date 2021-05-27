namespace ConsoleApp2
{

    public class Engine: IEngine
    {

        IFuelTank fuelTank;
        public Engine() { }
        public Engine(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }
        public int Start()
        {

            if (fuelTank.HasFuel())
            {
                return 800;
            }
            else
            {
                return 0;
            }
        }

        public int Stop()
        {
            return 0;
        }
    }
}

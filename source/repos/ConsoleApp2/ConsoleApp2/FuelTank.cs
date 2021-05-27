namespace ConsoleApp2
{

    public class FuelTank: IFuelTank
    {
        public int FuelLevel { get; set; }

        public void Fill(int fillAmount)
        {
            FuelLevel += fillAmount;
        }

        public bool HasFuel()
        {
            if (FuelLevel > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

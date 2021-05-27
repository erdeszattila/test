namespace ConsoleApp2
{
    public interface IFuelTank
    {
        int FuelLevel { get; set; }
        void Fill(int fillAmount);
        bool HasFuel();

    }
}

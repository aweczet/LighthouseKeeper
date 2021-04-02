[System.Serializable]
public class FuelData
{
    public float fuelAmount;

    public FuelData(FuelTank fuelTank)
    {
        fuelAmount = fuelTank.fuelAmount;
    }
}

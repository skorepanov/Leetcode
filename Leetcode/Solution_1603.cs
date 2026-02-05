// 1603. Design Parking System
public class ParkingSystem
{
    // 0 - big
    // 1 - medium
    // 2 - small
    private readonly int[] _spaces = new int[3];

    public ParkingSystem(int big, int medium, int small)
    {
        _spaces[0] = big;
        _spaces[1] = medium;
        _spaces[2] = small;
    }

    public bool AddCar(int carType)
    {
        if (_spaces[carType - 1] > 0)
        {
            _spaces[carType - 1]--;
            return true;
        }

        return false;
    }
}
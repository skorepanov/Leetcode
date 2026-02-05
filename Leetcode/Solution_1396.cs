// 1396. Design Underground System

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */

public class UndergroundSystem
{
    private readonly Dictionary<string, List<double>> _travels = new();

    private readonly Dictionary<int, (string StationNameFrom, int Time)>
        _checkedInPassengers = new();

    public UndergroundSystem() { }

    public void CheckIn(int id, string stationName, int t)
    {
        _checkedInPassengers.Add(id, (stationName, t));
    }

    public void CheckOut(int id, string stationName, int t)
    {
        var checkedInPassenger = _checkedInPassengers[id];

        var timeInTravel = t - checkedInPassenger.Time;

        var stationKey = GetStationKey(checkedInPassenger.StationNameFrom, stationName);

        if (!_travels.ContainsKey(stationKey))
        {
            _travels.Add(stationKey, value: []);
        }

        _travels[stationKey].Add(timeInTravel);

        _checkedInPassengers.Remove(id);
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        var stationKey = GetStationKey(startStation, endStation);

        if (_travels.TryGetValue(stationKey, out var times))
        {
            return times.Average();
        }

        return 0;
    }

    private string GetStationKey(string startStation, string endStation)
        => $"{startStation}->{endStation}";
}
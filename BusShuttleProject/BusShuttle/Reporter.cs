namespace BusShuttle;

public class Reporter
{
    public static Stop FindBusiestStop(List<PassengerData> passengerDataList)
    {
        Dictionary<string, int> passengerCountPerStop = new Dictionary<string, int>();

        foreach (var data in passengerDataList)
        {
            if (!passengerCountPerStop.ContainsKey(data.Stop.Name))
            {
                passengerCountPerStop.Add(data.Stop.Name, 0);
            }
            
            passengerCountPerStop[data.Stop.Name] += data.Boarded;
        }

        string highestStopName = "";
        int highestCount = -1;

        foreach (var stopCountPair in passengerCountPerStop)
        {
            if (stopCountPair.Value > highestCount)
            {
                highestCount = stopCountPair.Value;
                highestStopName = stopCountPair.Key;
            }
        }

        return new Stop(highestStopName);
    }
}
namespace BusShuttle;

public class DataManager
{
    FileSaver fileSaver;

    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; set; }

    public DataManager()
    {

        
        fileSaver = new FileSaver("passenger-data.txt");

        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();
        Stops.Add(new Stop("Music"));
        Stops.Add(new Stop("Tower"));
        Stops.Add(new Stop("Oakwood"));
        Stops.Add(new Stop("Anthony"));
        Stops.Add(new Stop("Letterman"));

        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Luke Skywalker"));
        Drivers.Add(new Driver("Han Solo"));

        PassengerData = new List<PassengerData>();
        if (File.Exists("passenger-data.txt")){
            var passengerFileContent = File.ReadAllLines("passenger-data.txt");
            foreach (var line in passengerFileContent){
                var splitted = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length == 4)
                {
                    var driver = new Driver(splitted[0]);
                    var loop = new Loop(splitted[1]);
                    var stop = new Stop(splitted[2]);
                    int boarded = int.Parse(splitted[3]);
                    
                    PassengerData.Add(new PassengerData(boarded, stop, loop, driver));
                }
            }
        }
    }

    public void AddNewPassengerData(PassengerData data)
    {
    this.PassengerData.Add(data);
    this.fileSaver.AppendData(data);
    }
    
    public void AddStop(Stop stop)
    {
    Stops.Add(stop);
    FileSaver.SaveStops(Stops); 
    }

    public void RemoveStop(Stop stop)
    {  
    var stopToRemove = Stops.Find(s => s.Name == stop.Name);
    if (stopToRemove != null)
    {
        Stops.Remove(stopToRemove);
        FileSaver.SaveStops(Stops);
    }
}
}
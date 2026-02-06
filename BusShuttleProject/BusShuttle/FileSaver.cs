namespace BusShuttle;

using System.IO;

public class FileSaver{
    string fileName;

    public FileSaver(string fileName){
        this.fileName = fileName;
        if (!File.Exists(this.fileName)) {
            File.Create(this.fileName).Close();
        }
    }

    public void AppendLine(string line){
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

    public void AppendData(PassengerData data) {
    File.AppendAllText(this.fileName, data.Driver + ":" + data.Loop + ":" + data.Stop + ":" + data.Boarded + Environment.NewLine);
    }
    public static void SaveStops(List<Stop> stops)
    {
    List<string> lines = new List<string>();
    foreach (var stop in stops)
    {
        lines.Add(stop.Name);
    }
    File.WriteAllLines("stops.txt", lines);
    }
    
}
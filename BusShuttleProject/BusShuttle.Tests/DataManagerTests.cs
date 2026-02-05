namespace BusShuttle.Tests;

using BusShuttle;
using Xunit;
using System.IO;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests()
    {
        if (File.Exists("stops.txt")) {
            File.Delete("stops.txt");
        }

        string content = "One" + Environment.NewLine + 
                         "Two" + Environment.NewLine + 
                         "Three" + Environment.NewLine + 
                         "Four" + Environment.NewLine + 
                         "Five";
                         
        File.WriteAllText("stops.txt", content);
        
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop()
    {
        Assert.Equal(5, dataManager.Stops.Count);

        dataManager.AddStop(new Stop("new stop"));
        Assert.Equal(6, dataManager.Stops.Count);
    }
}


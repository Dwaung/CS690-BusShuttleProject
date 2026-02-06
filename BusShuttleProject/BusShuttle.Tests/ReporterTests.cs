using BusShuttle;

namespace BusShuttle.Tests;

public class ReporterTests
{
    [Fact]
    public void Test_FindBusiestStop_JustTwoStops()
    {
        // Setup
        var sampleData = new List<PassengerData>();
        
        Stop sampleStop = new Stop("MyStop");
        Loop sampleLoop = new Loop("MyLoop");
        Driver sampleDriver = new Driver("MyDriver");
        
        PassengerData samplePassengerData = new PassengerData(5, sampleStop, sampleLoop, sampleDriver);
        sampleData.Add(samplePassengerData);

        Stop sampleStop2 = new Stop("MyStop2");
        PassengerData samplePassengerData2 = new PassengerData(6, sampleStop2, sampleLoop, sampleDriver);
        sampleData.Add(samplePassengerData2);

        // Act
        var result = Reporter.FindBusiestStop(sampleData);

        // Assert
        Assert.Equal("MyStop2", result.Name);
    }

    [Fact]
    public void Test_FindBusiestStop_Just2Stops_MoreData()
    {
        // Setup
        var sampleData = new List<PassengerData>();

        sampleData.Add(new PassengerData(4, new Stop("MyStop"), new Loop("MyLoop"), new Driver("MyDriver")));
        sampleData.Add(new PassengerData(5, new Stop("MyStop2"), new Loop("MyLoop"), new Driver("MyDriver")));
        sampleData.Add(new PassengerData(2, new Stop("MyStop"), new Loop("MyLoop"), new Driver("MyDriver")));

        // Act
        var result = Reporter.FindBusiestStop(sampleData);

        // Assert
        Assert.Equal("MyStop", result.Name);
    }
}
namespace BusShuttle.Tests;

using BusShuttle;
using Xunit;

public class DataManagerTests {
    DataManager dataManager;

    public DataManagerTests() {
        // Setup a controlled test environment
        File.WriteAllText("stops.txt", "One" + Environment.NewLine + "Two" + Environment.NewLine + "Three" + Environment.NewLine + "Four" + Environment.NewLine + "Five");
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop() {
        // Initial count based on setup file
        Assert.Equal(5, dataManager.Stops.Count);

        // Verify count increases after adding a stop
        dataManager.AddStop(new Stop("new stop"));
        Assert.Equal(6, dataManager.Stops.Count);
    }
}


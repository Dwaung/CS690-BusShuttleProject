using Spectre.Console;

namespace BusShuttle;

public class ConsoleUI
{
    DataManager dataManager;

    public ConsoleUI()
    {
        dataManager = new DataManager();
    }

    public void Show()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] { "driver", "manager" }));

        if (mode == "driver")
        {
            var selectedDriver = AnsiConsole.Prompt(
                new SelectionPrompt<Driver>()
                    .Title("Select a driver")
                    .AddChoices(dataManager.Drivers));

            Console.WriteLine("Now you are driving as " + selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                    .Title("Select a loop")
                    .AddChoices(dataManager.Loops));

            Console.WriteLine("You selected " + selectedLoop.Name + " loop!");

            string command;
            do
            {
                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                        .Title("Select a stop")
                        .AddChoices(selectedLoop.Stops));

                Console.WriteLine("You selected " + selectedStop.Name + " stop!");

                int boarded = AnsiConsole.Ask<int>("Enter the boarded number: ");

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);
                dataManager.AddNewPassengerData(data);

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] { "continue", "end" }));

            } while (command != "end");
        }
        else if (mode == "manager")
        {
            string command;
            do
            {
                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What do you want to do?")
                        .AddChoices(new[] { "show busiest stop", "add stop", "delete stop", "list stops", "add driver", "remove driver", "end" }));

                if (command == "add stop")
                {
                    var newStopName = AnsiConsole.Ask<string>("Enter a new stop name:");
                    dataManager.AddStop(new Stop(newStopName));
                }
                else if (command == "delete stop")
                {
                    var stopToDelete = AnsiConsole.Prompt(
                        new SelectionPrompt<Stop>()
                            .Title("Select a stop to delete:")
                            .AddChoices(dataManager.Stops));
                    dataManager.RemoveStop(stopToDelete);
                }
                else if (command == "list stops")
                {
                    var table = new Table();
                    table.AddColumn("Stop Name");
                    foreach (var stop in dataManager.Stops)
                    {
                        table.AddRow(stop.Name);
                    }
                    AnsiConsole.Write(table);
                }
                else if (command == "show busiest stop")
                {
                    var result = Reporter.FindBusiestStop(dataManager.PassengerData);
                    Console.WriteLine("The busiest stop is: " + result.Name);
                }
                else if (command == "add driver")
                {
                    var newDriverName = AnsiConsole.Ask<string>("Enter the name of the new driver:");
                    dataManager.AddDriver(newDriverName);
                    Console.WriteLine($"Driver {newDriverName} added!");
                }
                
                else if (command == "remove driver")
                {
                var driverToRemove = AnsiConsole.Prompt(
                        new SelectionPrompt<Driver>()
                        .Title("Select a driver to remove:")
                        .AddChoices(dataManager.Drivers));

                dataManager.RemoveDriver(driverToRemove);
                AnsiConsole.MarkupLine($"Driver {driverToRemove.Name} removed!");
                }


            } while (command != "end");
        }
    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    
}
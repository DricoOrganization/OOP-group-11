using System;
using System;
using System.Collections;
using System.IO;
using System.Text.Json;

namespace AirUFV;

public class Airport {

    private Runway[,] runways;

    private List<Aircraft> aircrafts;

    public Airport(Runway[,] runways, List<Aircraft> aircrafts ) {
        this.runways = runways;
        this.aircrafts = aircrafts;
    }

    /*
    This shows the current status of all runways and aircrafts
    */
    public void ShowStatus() {
        for (int i = 0; i < runways.length; i++) {
            if (!runways[i].IsFree()) {
            Console.WriteLine("Occupied by:");
            Console.WriteLine(runways[i].GetID());
            Console.WriteLine(runways[i].GetTicksAvailability());
            }
            Console.WriteLine("Free");
        }

    }

    public void AdvanceTick() {
        for (int i = 0; i < aircrafts.length; i++) {
            aircrafts[i].AdvanceTick();
        }
    }

    public void LoadAircraftFromFile(string filepath) {
            Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("1. CSV file (,)");
            Console.WriteLine("1. CSV file (;)");
            Console.WriteLine("2. Json file");
            Console.WriteLine("3. Exit");
            Console.WriteLine("----------------------------------");
            int filetype = Int32.Parse(Console.ReadLine());
            if (filetype == 3) {
                throw new Exception("Program Terminated.");
            }

            Console.Clear();
            Console.WriteLine("Type your filename.");
            string filepath = Console.ReadLine();
            switch (filetype) {
                case 1:
                LoadFlightFromCSVfile(filepath, ",");
                break;
                case 2:
                LoadFlightFromCSVfile(filepath, ";");
                break;
                case 3:
                LoadFlightFromJSONfile(filepath);
                break;
            }
    }

    public void AddAircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel)
     {
        aircrafts.AddAircraft(id, status, distance, speed, fuelCapacity, fuelCapacity, currentFuel);
    }
}
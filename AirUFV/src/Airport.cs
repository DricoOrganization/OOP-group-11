using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

public class Airport {

    private Runway[,] runways;

    private List<Aircraft> aircrafts;

    public Airport(List<Runway> runways,  Aircraft[,] aircrafts ) {
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

    }

    public void AddAircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel)
     {
        aircrafts.AddAircraft(id, status, distance, speed, fuelCapacity, fuelCapacity, currentFuel);
    }
}
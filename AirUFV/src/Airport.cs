using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

public class Airport {

    private List<Runway> runways;

    private Aircraft[,] aircrafts;

    public Airport(List<Runway> runways,  Aircraft[,] aircrafts ) {
        this.runways = runways;
        this.aircrafts = aircrafts;
    }

    public void ShowStatus() {

    }

    public void AdvanceTick() {

    }

    public void LoadAircraftFromFile(string filepath) {

    }

    public void AddAircraft() {

    }
}
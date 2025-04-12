using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

public class Airport {

    private List<Runways> runways;

    private List<Aircrafts> aircrafts;

    public Airport(List<Runways> runways, List<Aircrafts> aircrafts ) {
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
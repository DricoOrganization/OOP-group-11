using System;
using System;
using System.Collections;
using System.IO;
using System.Text.Json;
using AirUFV;

namespace AirUFV {
    
}

public class Airport {

    private Runway[,] runways;

    private List<Aircraft> aircrafts;

    public Airport(Runway runway1, Runway runway2, Aircraft aircraft ) {
        this.runways[0, 0] = runway1;
        this.runways[0, 1] = runway2;

        this.aircrafts.Add(aircraft);
    }

    /*
    This shows the current status of all runways and aircrafts
    */
    public void ShowStatus() {
        for (int j = 0; j < runways.Length; j++) {
        for (int i = 0; i < runways.Length; i++) {
            if (!runways[j, i].IsFree()) {
            Console.WriteLine("Occupied by:");
            Console.WriteLine(runways[j, i].GetID());
            Console.WriteLine(runways[j, i].GetTicksAvailability());
            }
            Console.WriteLine("Free");
        }
        }

    }

    public void AdvanceTick() {
        foreach(Aircraft aircraft in aircrafts) {
            aircraft.AdvanceTick(1);
        }
    }

    public void LoadAircraftFromFile() {
            Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("1. CSV file (,)");
            Console.WriteLine("1. CSV file (;)");
            Console.WriteLine("2. Json file (in progress)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("----------------------------------");
            int filetype = Int32.Parse(Console.ReadLine());
            if (filetype == 3) {
                throw new Exception("Program Terminated.");
            }

             Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("1. Commercial plane");
            Console.WriteLine("2. Private Plane");
            Console.WriteLine("3. Cargo plane");
            Console.WriteLine("4. Exit");
            Console.WriteLine("----------------------------------");
            int planeType = Int32.Parse(Console.ReadLine());


            Console.Clear();
            Console.WriteLine("Type your filename.");
            string filePath = Console.ReadLine();
            switch (filetype) {
                case 1:
                LoadAircraftFromCSVfile(filePath, ",", planeType);
                break;
                case 2:
                LoadAircraftFromCSVfile(filePath, ";", planeType);
                break;
                case 3:
                // LoadAircraftFromJSONfile(filePath);
                break;
            }
    }

    public void AddAircraft(string type, string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, double maximumLoad = -1, int numberOfPassengers = -1, string owner = "AirUFV")
     {
        if (type == "Cargo") {
        aircrafts.Add(new CargoAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maximumLoad));
        } else if (type == "Comercial") {
        aircrafts.Add(new CommercialAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, numberOfPassengers));
        } else if (type == "Private") {
        aircrafts.Add(new PrivateAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, owner));
        }
    }

    public void LoadAircraftFromCSVfile(string filepath, string seperator, int planeType) {
            StreamReader sr = File.OpenText(filepath);

            string header = sr.ReadLine();

            Console.WriteLine(header);

            string[] names = header.Split(seperator);

            string line = "";

            while ((line = sr.ReadLine()) != null) {
                //put all the values from the file into an array
                string[] values = line.Split(seperator);

                //assign each parameter value with the corresponding value from the array
                //it was the best way i could think of with the constructor but this is not futureproof
                string id = values[0];
                Enum.TryParse(values[1], out AircraftStatus status);
                int distance = Int32.Parse(values[2]);
                int speed = Int32.Parse(values[3]);
                double fuelCapacity = double.Parse(values[4]);
                double fuelConsumption = double.Parse(values[5]);
                double currentFuel =  double.Parse(values[6]);
                object extraVariableDepedingOnPlaneType;

                //seperate the plane addition by type and make sure that the type of the extra variable(passengers, max load and owner) is correctly passed
                // we have two ways of adding the aircraft to the aircraft list
                //i think the AddAircraft method is better, but for a backup we have the aircrafts.Add
                    if (planeType == 1) {
                    extraVariableDepedingOnPlaneType = Int32.Parse(values[7]);
                    // aircrafts.Add(new CommercialAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (int) extraVariableDepedingOnPlaneType));
                    AddAircraft("Commercial", id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (double)extraVariableDepedingOnPlaneType);
                    } else if (planeType == 2) {
                    extraVariableDepedingOnPlaneType = values[7];
                    // aircrafts.Add(new PrivateAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (string) extraVariableDepedingOnPlaneType));
                    AddAircraft("Private", id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (double)extraVariableDepedingOnPlaneType);
                    } else if (planeType == 3) {
                    extraVariableDepedingOnPlaneType = double.Parse(values[7]);
                    // aircrafts.Add(new CargoAircraft(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (double)extraVariableDepedingOnPlaneType));
                    AddAircraft("Cargo", id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, (double)extraVariableDepedingOnPlaneType);

                    }
            }
            sr.Close();
    }
}
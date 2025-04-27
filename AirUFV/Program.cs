using System;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using AirUFV;

namespace AirUFV;

internal class Program
{

    public static void Main() {
        Runway runwayA = new Runway("A");
        Runway runwayB = new Runway("B");
        Aircraft aircraft = new CommercialAircraft("1", AircraftStatus.OnGround, 0, 0, 10, 2, 10, 200);
        Airport AirUFV = new Airport(2, 1);

    
        //give the inital selections menu
        Console.WriteLine("----------   Air UFV  ------------");
        Console.WriteLine("1. Load flight from file.");
        Console.WriteLine("2. Load a flight manually.");
        Console.WriteLine("3. Start simulation (Manual).");
        Console.WriteLine("4. Start simulation (Automatic).");
        Console.WriteLine("5. Exit.");
        Console.WriteLine("----------------------------------");

        //transform the string that the user types to int in order to use it better
        int input = Int32.Parse(Console.ReadLine());

        //a switch case statement that selects the function based on the user input
        switch (input) {
            case 1:
            AirUFV.LoadAircraftFromFile();
            break;
            case 2:
            var (type, id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maximumLoad, numberOfPassengers, owner) = LoadFlightManual();
            AirUFV.AddAircraft(type, id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maximumLoad, numberOfPassengers, owner);
            break;
            case 3:
            StartSimulationManual();
            break;
            case 4:
            StartSimualtionAutomatic();
            break;
            case 5:
            throw new Exception("Program Terminated.");
        }

    }

        public static (string type, string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, double maximumLoad, int numberOfPassengers, string owner) LoadFlightManual() {
            string[] parameters = ["id", "status", "distance", "speed", "fuelCapacity", "fuelConsumption", "currentFuel",  "maximumLoad/owner/maximumpassangers"];
            List<String> results = [];
            for(int i = 0; i < parameters.Length; i++) {

            Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("Enter your information");
            Console.WriteLine($"{parameters[i]}");
            Console.WriteLine("----------------------------------");
            results.Add(Console.ReadLine());
            }
            string id = results[0];
            Enum.TryParse(results[1], out AircraftStatus status);
            int distance = Int32.Parse(results[2]);
            int speed = Int32.Parse(results[3]);
            double fuelCapacity = double.Parse(results[4]);
            double fuelConsumption = double.Parse(results[5]);
            double currentFuel =  double.Parse(results[6]);
            string type = results[7];

            double maximumLoad = -1;
            int maximumpassangers = -1;
            string owner = "AirUFV";
             if (type == "Cargo") {
              maximumLoad = double.Parse(results[8]);
             } else if (type == "Comercial") {
              maximumpassangers = Int32.Parse(results[8]);
             } else if (type == "Private") {
              owner = results[8];
             }
            return (type, id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel, maximumLoad, maximumpassangers, owner );
        }

        public static void StartSimulationManual() {
        //this should be the same as
        }

        public static void StartSimualtionAutomatic() {
            return;

        }

        public static void LoadFlightFromCSVfile(string filepath, string seperator) {
            StreamReader sr = File.OpenText(filepath);

            string header = sr.ReadLine();

            Console.WriteLine(header);

            string[] names = header.Split(seperator);

            string line = "";

            while ((line = sr.ReadLine()) != null) {
                string[] values = line.Split(seperator);

                for(int i = 0; i < values.Length; i++) {
                    Console.WriteLine(values[i]);
                    Console.WriteLine(",");
                }
            }
            sr.Close();
            
        }

        public static void LoadFlightFromJSONfile(string filepath) {
            //todo
        }

}
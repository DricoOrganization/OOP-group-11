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
        Airport AirUFV = new Airport(1, 2);

        //make the loop for better user experience
        int input = 0;
        while(input != 5) {

        //give the inital selections menu
        Console.Clear();
        Console.WriteLine("----------   Air UFV  ------------");
        Console.WriteLine("1. Load flight from file.");
        Console.WriteLine("2. Load a flight manually.");
        Console.WriteLine("3. Start simulation (Manual).");
        Console.WriteLine("4. Start simulation (Automatic).");
        Console.WriteLine("5. Exit.");
        Console.WriteLine("----------------------------------");

        //transform the string that the user types to int in order to use it better
        input = Int32.Parse(Console.ReadLine());

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
            StartSimulationManual(AirUFV);
            break;
            case 4:
            StartSimulationAutomatic(AirUFV);
            break;
            case 5:
            throw new Exception("Program Terminated.");
        }
        }
    }

        /*
        LoadFlightManuel will return all the information nessacery
        */
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

        public static void StartSimulationManual(Airport airport) {
            Console.Clear();
            Console.WriteLine("Starting manual simulation. Please wait a moment...");

            bool run = true;
            while(run){
                airport.ShowStatus();
                Console.WriteLine("Press any key to advance: ");
                Console.ReadKey();

                airport.AdvanceTick();

                Console.WriteLine("Press 1 if you want to stop the simulation");
                Console.WriteLine("Press 0 if you want to continue");
                ConsoleKeyInfo tmp = Console.ReadKey();
                int progress = int.Parse(tmp.KeyChar.ToString());
                if(progress == 1){
                    run = false;
                }
            }
        }

        public static void StartSimulationAutomatic(Airport airport)
        {
            Console.Clear();
            Console.WriteLine("Starting automatic simulation...");

            // Ask the user for the wait time (in seconds) between each tick
            Console.WriteLine("Enter the number of seconds to wait between each simulation tick: ");
            int waitTimeInSeconds = Int32.Parse(Console.ReadLine());

            bool running = true;
            while (running)
            {
                airport.ShowStatus(); 
                
                airport.AdvanceTick();

                Console.WriteLine($"Simulation running... Waiting for {waitTimeInSeconds} seconds before next tick.");
                
                System.Threading.Thread.Sleep(waitTimeInSeconds * 1000); 


                Console.WriteLine("Press any key to stop the simulation.");
                if (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    running = false;
                }
            }

            Console.WriteLine("Automatic simulation ended.");
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
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
        Airport AirUFV = new Airport(runwayA, runwayB, aircraft);

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
            var flightdata = LoadFlightFromFile();
            AirUFV.AddAircraft();
            break;
            case 2:
            LoadFlightManual();
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

        /*
        this asks the user to specify the filetype and and filepath
        than depending on the type it goes to another functions that handels the loading with that filetype and seperator
        */
        public static (string type, string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel) LoadFlightFromFile() {
            Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("Ensure your file has the following headers:");
            Console.WriteLine("id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel");
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
            Console.WriteLine("Type your filename.");
            string filepath = Console.ReadLine();
            switch (filetype) {
                case 1:
                return LoadFlightFromCSVfile(filepath, ",");
                case 2:
                return LoadFlightFromCSVfile(filepath, ";");
                case 3:
                return LoadFlightFromJSONfile(filepath);
            }

        }

        public static void LoadFlightManual() {
                
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
using System;
using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

internal class Program
{

    public static void Main() {
        Console.WriteLine("----------   Air UFV  ------------");
        Console.WriteLine("1. Load flight from file.");
        Console.WriteLine("2. Load a flight manually.");
        Console.WriteLine("3. Start simulation (Manual).");
        Console.WriteLine("4. Start simulation (Automatic).");
        Console.WriteLine("5. Exit.");
        Console.WriteLine("----------------------------------");
        //give the inital selections menu


        // int input = int32.Parse(Console.ReadLine());
        string input = (Console.ReadLine());

        switch (input) {
            case 1:
            LoadFlightFromFile();
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

    
        public static void LoadFlightFromFile() {
            Console.Clear();
            Console.WriteLine("Choose your file.");
            string path = Console.ReadLine();
        }

        public static void LoadFlightManual() {

        }

        public static void StartSimulationManual() {

        }

        public static void StartSimualtionAutomatic() {
            return;

        }

}
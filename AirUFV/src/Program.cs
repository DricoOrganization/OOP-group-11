using System;
using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

internal class Program
{

    public static void Main() {
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

        /*
        this asks the user to specify the filetype and imports that file from the filesystem
        then it enters the data into the current simulation
        */
        public static void LoadFlightFromFile() {
            Console.Clear();
            Console.WriteLine("----------   Air UFV  ------------");
            Console.WriteLine("1. CSV file");
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

        }

        public static void LoadFlightManual() {

        }

        public static void StartSimulationManual() {

        }

        public static void StartSimualtionAutomatic() {
            return;

        }

}
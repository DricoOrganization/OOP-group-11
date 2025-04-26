using System;
using System;
using System.Collections;
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
        this asks the user to specify the filetype and and filepath
        than depending on the type it goes to another functions that handels the loading with that filetype
        */
        public static void LoadFlightFromFile() {
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

        public static void LoadFlightManual() {

        }

        public static void StartSimulationManual() {

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
                    Console.WriteLine(names[i] + seperator + " " + values[i]);
                }
                Console.ReadLine();
            }
            sr.Close();
            
        }

        public static void LoadFlightFromJSONfile(string filepath) {
            //todo
        }

}
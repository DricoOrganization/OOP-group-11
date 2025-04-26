using System;
using AirUFV;

namespace AirUFV
{
     public class CommercialAircraft : Aircraft
    {
        public int numberOfPassengers { get; set; }

        public CommercialAircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, int numberOfPassengers)
            : base(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.numberOfPassengers = numberOfPassengers;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Type: Commercial | Passengers: {this.numberOfPassengers}";
        }
    }
}

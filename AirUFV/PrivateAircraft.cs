using System;
using AirUFV;

namespace AirUFV
{
    public class PrivateAircraft : Aircraft
    {
        public string owner { get; set; }

        public PrivateAircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, string owner)
            : base(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.owner = owner;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Type: Private | Owner: {this.owner}";
        }
    }
}

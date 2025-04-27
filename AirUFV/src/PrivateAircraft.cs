using System;

namespace AirUFV
{
    public class PrivateAircraft : Aircraft
    {

        private string owner;
        public string Parameters { get; }


        public PrivateAircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel, string owner)
            : base(id, status, distance, speed, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.owner = owner;
        }

        public string GetOwner()
        {
            return this.owner;
        }

        public void SetOwner(string owner)
        {
            this.owner = owner;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Type: Private | Owner: {this.owner}";
        }
    }
}

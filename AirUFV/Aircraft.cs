using System;
using AirUFV;

namespace AirUFV
{

    public enum AircraftStatus
    {
        InFlight,   // Aircraft is flying toward the airport
        Waiting,    // Aircraft is at the airport waiting for runway
        Landing,    // Aircraft is currently landing (occupying runway)
        OnGround    // Aircraft has landed and is no longer active
    }

    public abstract class Aircraft
    {
        // Getters and setters for all aircraft
        public string id { get; set; }
        public AircraftStatus status { get; set; }
        public int distance { get; set; } // Distance to airport in km
        public int speed { get; set; } // Speed in km/h
        public double fuelCapacity { get; set; } // Max fuel in liters
        public double fuelConsumption { get; set; } // Liters consumed per km
        public double currentFuel { get; set; } // Current fuel level

        protected Aircraft(string id, AircraftStatus status, int distance, int speed, double fuelCapacity, double fuelConsumption, double currentFuel)
        {
            this.id = id;
            this.status = status;
            this.distance = distance;
            this.speed = speed;
            this.fuelCapacity = fuelCapacity;
            this.fuelConsumption = fuelConsumption;
            this.currentFuel = currentFuel;
        }

        // Method that advances the simulation by a specified time step (in hours)
        public virtual void AdvanceTick(double hours)
        {
            // Only update if the aircraft is in flight and hasn't reached the airport
            if (this.status == AircraftStatus.InFlight && this.distance > 0)
            {
                // Calculate distance travelled during this tick
                int distanceTravelled = (int)(this.speed * hours);

                // Update the distance to the airport, ensuring it doesn't go below zero
                this.distance -= distanceTravelled;
                if (this.distance < 0)
                {
                    this.distance = 0;
                }

                // Calculate and update the fuel consumption
                double fuelUsed = distanceTravelled * this.fuelConsumption;
                this.currentFuel -= fuelUsed;

                // Ensure fuel doesn't go below zero
                if (this.currentFuel < 0)
                {
                    this.currentFuel = 0;
                }

                // If the aircraft has arrived, change its status to waiting
                if (this.distance == 0)
                {
                    this.status = AircraftStatus.Waiting;
                }
            }
        }

        // Returns a formatted string with aircraft details
        public override string ToString()
        {
            return $"ID: {this.id} | Status: {this.status} | Distance: {this.distance}km | Speed: {this.speed}km/h | Fuel: {this.currentFuel}/{this.fuelCapacity}L";
        }
    }
}

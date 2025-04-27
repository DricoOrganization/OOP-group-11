using System;

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
        protected string id;
        protected AircraftStatus status;
        protected int distance;
        protected int speed;
        protected double fuelCapacity;
        protected double fuelConsumption;
        protected double currentFuel;

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

        public string GetId(){
            return this.id;
        }

        public void SetId(string id){
            this.id = id;
        }
        public AircraftStatus GetStatus()
        {
            return this.status;
        }

        public void SetStatus(AircraftStatus status)
        {
            this.status = status;
        }

        public int GetDistance()
        {
            return this.distance;
        }

        public void SetDistance(int distance)
        {
            this.distance = distance;
        }

        public int GetSpeed()
        {
            return this.speed;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public double GetFuelCapacity()
        {
            return this.fuelCapacity;
        }

        public void SetFuelCapacity(double fuelCapacity)
        {
            this.fuelCapacity = fuelCapacity;
        }

        public double GetFuelConsumption()
        {
            return this.fuelConsumption;
        }

        public void SetFuelConsumption(double fuelConsumption)
        {
            this.fuelConsumption = fuelConsumption;
        }

        public double GetCurrentFuel()
        {
            return this.currentFuel;
        }

        public void SetCurrentFuel(double currentFuel)
        {
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

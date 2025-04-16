using System;
using System.IO;
using System.Text.Json;

namespace AirUFV;

public class Runway {
    private string ID;
    private enum RunwayStatus{
        Free,
        Occupied
    }
    private RunwayStatus status;

    private Aircraft currentAircraft;

    private int ticksAvailability;

    public Runway(string ID){
        this.ID = ID;
        this.status = RunwayStatus.Free;
        this.currentAircraft = null;
        this.ticksAvailability = 0;
    }

    public string GetID(){
        return this.ID;
    }

    public void SetID(string ID){
        this.ID = ID;
    }

    public Aircraft GetCurrentAircraft(){
        return this.currentAircraft;
    }

    public void SetCurrentAircraft(Aircraft aircraft){
        this.currentAircraft = aircraft;
    }

     public bool IsFree(){
        return this.status == RunwayStatus.Free;
    }

    public int GetTicksAvailability(){
        return this.ticksAvailability;
    }

    public string GetStatus(){
        return this.status.ToString();
    }

    public bool RequestRunway(Aircraft aircraft){
        if (this.status == RunwayStatus.Free)
        {
            this.currentAircraft = aircraft;
            this.status = RunwayStatus.Occupied;
            this.ticksAvailability = 3;
            aircraft.Status = AircraftStatus.Landing;
            return true;
        }
        return false;
    }

    public void AdvanceTick(){
        if (this.status == RunwayStatus.Occupied && this.currentAircraft != null)
        {
            this.ticksAvailability--;
            if (this.ticksAvailability <= 0)
            {
                ReleaseRunway();
            }
        }
    }

    public void ReleaseRunway(){
        if (this.currentAircraft != null)
        {
            this.currentAircraft.Status = AircraftStatus.OnGround;
            this.currentAircraft = null;
        }
        this.status = RunwayStatus.Free;
    }
}
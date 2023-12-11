using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    //Implementing buttons and toggles to select our options for our vehicle 
    public Button createVehicle;
    public Toggle hasAnEngine;
    public Slider passengers; 
    public Slider numOfWheels;
    public Toggle hasCargo; 
    


    //Our text component to display our text; 
    public TMP_Text text;

    //Other variables for our VehicleRequirements and IVehicle 
    VehicleRequirements vRequirements;
    IVehicle ourVehicle; 


    // Start is called before the first frame update
    void Start()
    {
        // validate our data
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        vRequirements = new VehicleRequirements();
        UpdateRequirements();
    }

    // Update is called once per frame
    void Update()
    {
        //In here we will be checking the buttons/sliders and correlate their values/input with the desired requirements
        text.text = ourVehicle.Start();
    }

    //We need to create our buttons 
    public void UpdateRequirements()
    {
        //Here we will be checking the requirements and displaying what kind of vehicle 
        //  we get based on those requirements that we meet 

        vRequirements.Engine = hasAnEngine.isOn;
        vRequirements.Passengers = (int)passengers.value;
        vRequirements.NumberOfWheels = (int)numOfWheels.value;
        vRequirements.HasCargo = hasCargo.isOn; 

        ourVehicle = GetVehicle(vRequirements);
    }

    public void UpdateWheels(int num)
    {
        NumberOfWheels += num; 
    }

    public void UpdatePassengers(int num)
    {
        Passengers += num; 
    }

    public void UpdateEngine()
    {
        Engine = !Engine; 
    }

    public void UpdateCargo()
    {
        Cargo = !Cargo; 
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        // based on requirements.Engine
        // choose a motorvehicle factory or a cycle factory
        // call create on the factory to get an appropriate vehicle
        // and return it

        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create(); 
    }
}

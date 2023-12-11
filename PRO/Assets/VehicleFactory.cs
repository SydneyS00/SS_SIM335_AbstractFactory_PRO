using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements vehicleRequirements);
}

//These will be not farm animals
public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 0 && requirements.Passengers == 1) 
                    return new Snake();
                return new Snake(); 
            case 2:
                if (requirements.NumberOfWheels == 2 && requirements.Passengers == 2)
                    return new Bird();
                return new Bird();
            case 3:
                if (requirements.Passengers == 3 && requirements.NumberOfWheels == 4)
                    return new Cat();
                return new Cat();
            case 4:
                if (requirements.Passengers == 4 && requirements.NumberOfWheels == 4)
                    return new Dog();
                return new Dog(); 
            default:
                return new Snake();
        }
    }
}
public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.Passengers == 2 && requirements.NumberOfWheels == 2)
                    return new Chicken();
                return new Chicken();
            case 2:
                if (requirements.Passengers == 3 && requirements.NumberOfWheels == 4)
                    return new Pig();
                return new Pig();
            case 3:
                if (requirements.Passengers == 4 && requirements.NumberOfWheels == 4)
                    return new Cow();
                return new Cow();
            case 4:
                if (requirements.HasCargo)
                    return new Horse();
                return new Cow(); 
            default:
                return new Chicken(); 
        }
    }
}
public abstract class AbstractVehicleFactory
{
    public abstract IVehicle Create();
}
public class VehicleFactory : AbstractVehicleFactory
{
    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new CycleFactory();
        _requirements = requirements;
    }
    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}
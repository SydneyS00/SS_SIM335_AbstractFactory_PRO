using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicle 
{
    //This will display our starting text along with what kind of vehicle we pick 
    string Start(); 
}

public class Snake : IVehicle 
{
    public string Start()
    {
        return ("I am a snake!"); 
    }
}
public class Bird : IVehicle 
{
    public string Start()
    {
        return ("I am bird!"); 
    }
}
public class Cat : IVehicle 
{
    public string Start()
    {
        return ("I am a cat!");
    }
}
public class Dog : IVehicle 
{
    public string Start()
    {
        return ("I am a dog"); 
    }
}
public class Chicken : IVehicle 
{
    public string Start()
    {
        return ("I am a chicken!"); 
    }
}
public class Pig : IVehicle 
{
    public string Start()
    {
        return ("I am a pig!"); 
    }
}
public class Cow : IVehicle 
{
    public string Start()
    {
        return ("I am a cow!");
    }
}
public class Horse : IVehicle 
{
    public string Start()
    {
        return ("I am a horse"); 
    }
}




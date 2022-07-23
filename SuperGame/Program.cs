using System;
Console.WriteLine(SuperPowerGenerator.SuperPowerAmount());
class SuperPowerGenerator
{
    public static int SuperPowerAmount()
    {
        Random rd = new Random();
        int m = rd.Next(1, 1000);  //module
        int x0 = rd.Next(0, m); ; //seed
        int a = rd.Next(1, m);  // multiplier
        int b = rd.Next(0, m);  // increment

        x0 = (a * x0 + b) % m;  // randomness
        double value = 5.0 + (5.0 * ((double)x0/1000.0));  // convert to value between 5 and 10
        return (int)Math.Round(value, 0, MidpointRounding.ToEven);     
    }
}



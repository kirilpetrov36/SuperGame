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

abstract class Warrior
{
    public int Life { get; set; } = 100;
    public int Armour { get; set; }
    public int Power { get; set; }
    public virtual void AddSuperPower(AddSuperPower addSuperPower, int amount) {}
}

class Human: Warrior
{
   public Human(int armour = 10, int power = 10)
   {
        Armour = armour;
        Power = power;
   }

}

class Elf : Warrior
{
    public Elf(int armour = 5, int power = 15)
    {
        Armour = armour;
        Power = power;
    }

    public override void AddSuperPower(AddSuperPower addSuperPower, int amount) {
        addSuperPower.AddSuperPower(this, amount);
    }

}

class Dwarf : Warrior
{
    public Dwarf(int armour = 15, int power = 5)
    {
        Armour = armour;
        Power = power;
    }

    public override void AddSuperPower(AddSuperPower addSuperPower, int amount)
    {
        addSuperPower.AddSuperPower(this, amount);
    }

}

class Orc : Warrior
{
    public Orc(int armour = 5, int power = 15)
    {
        Armour = armour;
        Power = power;
    }
    public override void AddSuperPower(AddSuperPower addSuperPower, int amount)
    {
        addSuperPower.AddSuperPower(this, amount);
    }

}

interface AddSuperPower
{
    void AddSuperPower(Warrior person, int amount);
}

class AddLife : AddSuperPower
{
    public void AddSuperPower(Warrior person, int amount)
    {
        person.Life += amount;
    }
}

class AddArmour : AddSuperPower
{
    public void AddSuperPower(Warrior person, int amount)
    {
        person.Armour += amount;
    }
}

class AddPower : AddSuperPower
{
    public void AddSuperPower(Warrior person, int amount)
    {
        person.Power += amount;
    }
}

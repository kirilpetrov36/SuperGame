string[] races = new string[] { "Human", "Elf", "Dwarf", "Orc" };
Console.WriteLine("Choose a 1-st warrior:");
Console.WriteLine("Human - 1");
Console.WriteLine("Elf - 2");
Console.WriteLine("Dwarf - 3");
Console.WriteLine("Orc - 4");
string? firstPlayer = Console.ReadLine();
Console.WriteLine($"First warrior - {races[Int32.Parse(firstPlayer!) - 1]}");
Console.WriteLine("Choose a 2-nd warrior:");
string? secondPlayer = Console.ReadLine();
Console.WriteLine($"First warrior - {races[Int32.Parse(secondPlayer!) - 1]}");


// 1-st task
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

// 2-nd task
abstract class Warrior
{
    public double Life { get; set; } = 100;
    public double Armour { get; set; }
    public double Power { get; set; }
    public bool isAlive
    {
        get
        {
            if (this.Life > 0)
                return true;
            else
                return false;
        }
    }
    public virtual void AddSuperPower(AddSuperPower addSuperPower, double amount) {}

    public void Protect(double attackAmount)
    {
        if (Armour >= (attackAmount/2)) {
            attackAmount /= 2;
            Armour -= attackAmount;       
        }
        
        Life -= attackAmount;
    }

    public double Attack()
    {
        return Power;
    }
}

class Human: Warrior
{
   public Human(double armour = 10, double power = 10)
   {
        Armour = armour;
        Power = power;
   }

}

class Elf : Warrior
{
    public Elf(double armour = 5, double power = 15)
    {
        Armour = armour;
        Power = power;
    }

    public override void AddSuperPower(AddSuperPower addSuperPower, double amount) {
        addSuperPower.AddSuperPower(this, amount);
    }

}

class Dwarf : Warrior
{
    public Dwarf(double armour = 15, double power = 5)
    {
        Armour = armour;
        Power = power;
    }

    public override void AddSuperPower(AddSuperPower addSuperPower, double amount)
    {
        addSuperPower.AddSuperPower(this, amount);
    }

}

class Orc : Warrior
{
    public Orc(double armour = 5, double power = 15)
    {
        Armour = armour;
        Power = power;
    }
    public override void AddSuperPower(AddSuperPower addSuperPower, double amount)
    {
        addSuperPower.AddSuperPower(this, amount);
    }

}

// 3-rd task
interface AddSuperPower
{
    void AddSuperPower(Warrior person, double amount);
}

class AddLife : AddSuperPower
{
    public void AddSuperPower(Warrior person, double amount)
    {
        person.Life += amount;
    }
}

class AddArmour : AddSuperPower
{
    public void AddSuperPower(Warrior person, double amount)
    {
        person.Armour += amount;
    }
}

class AddPower : AddSuperPower
{
    public void AddSuperPower(Warrior person, double amount)
    {
        person.Power += amount;
    }
}

// 4-th task

static class Scene
{
    public static void Fight(Warrior firstPlayer, Warrior secondPlayer)
    {

    }
}
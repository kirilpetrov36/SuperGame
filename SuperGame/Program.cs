string[] races = new string[] { "Human", "Elf", "Dwarf", "Orc" };

Console.WriteLine("Choose a 1-st warrior:");
Console.WriteLine("Human - 1");
Console.WriteLine("Elf - 2");
Console.WriteLine("Dwarf - 3");
Console.WriteLine("Orc - 4");

string? firstPlayerRace = Console.ReadLine();
Console.WriteLine($"1-st warrior created - {races[Int32.Parse(firstPlayerRace!) - 1]}");
Console.WriteLine();

Console.WriteLine("Choose a 2-nd warrior:");
string? secondPlayerRace = Console.ReadLine();
Console.WriteLine($"2-nd warrior created - {races[Int32.Parse(secondPlayerRace!) - 1]}");
Console.WriteLine();

Warrior firstPlayer = Warrior.Create(firstPlayerRace!);         //create first player
Warrior secondPlayer = Warrior.Create(secondPlayerRace!);       //create second player

int firstSuperPower = SuperPowerGenerator.SuperPowerAmount();   // generate SuperPower value for the first player
int secondSuperPower = SuperPowerGenerator.SuperPowerAmount();  // generate SuperPower value for the second player

Console.WriteLine($"Random value for the first player is generated - {firstSuperPower}");
Console.WriteLine("Choose what SuperPower you want to boost: ");
Console.WriteLine("Life - 1");
Console.WriteLine("Armour - 2");
Console.WriteLine("Power - 3");
string? firstSuperPowerToBoost = Console.ReadLine();            // ask first player what SuperPower he wants to boost
firstPlayer.Boost(firstSuperPower, firstSuperPowerToBoost!);    // boost first player SuperPower
Console.WriteLine("SuperPower has been boosted successfully");
Console.WriteLine();

Console.WriteLine($"Random value for the second player is generated - {secondSuperPower}");
Console.WriteLine("Choose what SuperPower you want to boost: ");
string? secondSuperPowerToBoost = Console.ReadLine();           // ask second player what SuperPower he wants to boost
secondPlayer.Boost(secondSuperPower, secondSuperPowerToBoost!);  // boost second player SuperPower
Console.WriteLine("SuperPower has been boosted successfully");
Console.WriteLine();

Console.WriteLine("1-st player SuperPowers:");
Console.WriteLine($"Life - {firstPlayer.Life}");
Console.WriteLine($"Armour - {firstPlayer.Armour}");
Console.WriteLine($"Power - {firstPlayer.Power}");
Console.WriteLine();
Console.WriteLine("2-nd player SuperPowers:");
Console.WriteLine($"Life - {secondPlayer.Life}");
Console.WriteLine($"Armour - {secondPlayer.Armour}");
Console.WriteLine($"Power - {secondPlayer.Power}");
Console.WriteLine();

Scene.Fight(firstPlayer, secondPlayer);

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
        if (Armour >= (attackAmount/2.0)) {
            attackAmount /= 2.0;
            Armour -= attackAmount;       
        }
        
        Life -= attackAmount;
    }

    public double Attack()
    {
        if (Armour > 0) 
        { 
            return Power;
        }
        else
        {
            Power--;
            return Power;
        }
    }

    public static Warrior Create(string race)
    {
        switch (race)
        {
            case "1": return new Human();
            case "2": return new Elf();
            case "3": return new Dwarf();
            case "4": return new Orc();
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public void Boost(int powerAmount, string choosePower)
    {
        switch (choosePower)
        {
            case "1": 
                Life += (double)powerAmount;
                break;
            case "2": 
                Armour += (double)powerAmount;
                break;
            case "3": 
                Power += (double)powerAmount;
                break;
            default: throw new ArgumentOutOfRangeException();
        }
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
        int currentRound = 1;
        while (true)
        {
            Console.WriteLine($"Round #{currentRound}");
            Console.WriteLine();
            if (currentRound % 2 == 1) {
                Console.WriteLine("1-st player attacks 2-nd player");
                double oldPower = firstPlayer.Power;
                double oldLife = secondPlayer.Life;
                double oldArmour = secondPlayer.Armour;
                if (firstPlayer.Power > 0)
                    secondPlayer.Protect(firstPlayer.Attack());
                else
                    Console.WriteLine("1-st player lost his power");
                Console.WriteLine($"1-st player Power : {oldPower} -> {firstPlayer.Power} ");
                Console.WriteLine($"2-nd player Life : {oldLife} -> {secondPlayer.Life} ");
                Console.WriteLine($"2-nd player Armor : {oldArmour} -> {secondPlayer.Armour} ");
            }
            else {
                Console.WriteLine("2-nd player attacks 1-st player");
                double oldPower = secondPlayer.Power;
                double oldLife = firstPlayer.Life;
                double oldArmour = firstPlayer.Armour;
                if (secondPlayer.Power > 0)
                    firstPlayer.Protect(secondPlayer.Attack());
                else
                    Console.WriteLine("2-nd player lost his power");
                Console.WriteLine($"2-nd player Power : {oldPower} -> {secondPlayer.Power} ");
                Console.WriteLine($"1-st player Life : {oldLife} -> {firstPlayer.Life} ");
                Console.WriteLine($"1-st player Armor : {oldArmour} -> {firstPlayer.Armour} ");
            }

            if (firstPlayer.Life <= 0) {
                Console.WriteLine();
                Console.WriteLine("2-ND PLAYER HAS WON");
                break; 
            }
            if (secondPlayer.Life <= 0) {
                Console.WriteLine();
                Console.WriteLine("1-ST PLAYER HAS WON");
                break; 
            }

            currentRound++;
        }
    }
}
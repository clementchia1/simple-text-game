namespace simple_text_game
{
    using System;

    internal abstract class Character
    {
        public string Type { get; set; }

        public int Health { get; set; }
        public int Max_Health { get; set; }

        public virtual void Getinfo()// virtual, abstract, 
        {
            Console.WriteLine($" is a {Type}" + $" with {Health} health.");
        }
    }

    interface Action
    {
        public void reducehealth(Character c1);

        public void heal();
    }

    internal class Attacker : Character, Action
    {
        internal int Attack_value { get; set; }
        internal string Name { get; set; }
        public string GetName()
        {
            return Name;
        }

        public Attacker(int attack_value, int health, string name)
        {
            Type = "Attacker";
            Health = health;
            Max_Health = health;
            Attack_value = attack_value;
            Name = name;
        }

        public override void Getinfo()
        {
            Console.Write(Name);
            base.Getinfo();
            Console.WriteLine($"It has {Attack_value} attack value\n");
        }

        public void reducehealth(Character c1)
        {
            if (c1.Health-Attack_value>=0)
            {
                c1.Health -= Attack_value;
            }
        }

        public void heal()
        {
            if (Health + 5<=Max_Health)
            {
                Health += 5;
            }
        }
    }

    internal class Program
    {
        internal static void Main(string[] args)
        {
            Attacker attacker1 = new Attacker(10, 50, "Mario");
            Attacker attacker2 = new Attacker(5, 100, "Luigi");
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
                Console.Clear();
                switch (input)
                {
                    case ConsoleKey.D1:
                        attacker2.reducehealth(attacker1);
                        break;
                    case ConsoleKey.D2:
                        attacker1.reducehealth(attacker2);
                        break;
                    case ConsoleKey.D3:
                        attacker1.heal();
                        break;
                    case ConsoleKey.D4:
                        attacker2.heal();
                        break;
                    default:
                        break;
                }
                attacker1.Getinfo();
                attacker2.Getinfo();
                Console.WriteLine("1: attack " + attacker1.Name);
                Console.WriteLine("2: attack " + attacker2.Name);
                Console.WriteLine("3: heal" + attacker1.Name);
                Console.WriteLine("4: heal" + attacker2.Name);
                Console.WriteLine("ESC to quit");
            } while (input != ConsoleKey.Escape);
        }
    }
}

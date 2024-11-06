using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Simulator
{
    public class Elf : Creature // i need to highlight inheritance
    {
        public Elf() : base("Unknown", 1) { } //konstruktor bezparametrowy
        public Elf(string name, int level =1, int agility = 0) : base(name, level)
        {
            
            Agility = agility;
        }
        private int agility;
        public int Agility
        {
            get => agility;
            set { agility = Validator.Limiter(value, 0, 10); }
        }
        private bool _isSingCalled = false;
        private int counter = 1;
        public void Sing()
        {
            _isSingCalled = true;
            counter++;
            if (counter % 3 == 0) { agility++; _isSingCalled = false; } 
            Console.WriteLine($"{Name} is singing.");
        }

        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}!");
        }

        public override string Info
        {
            get { return $"{Name} [{Level}] [{Agility}]"; }
        }


        private int power;
        public override int Power
        {
            get
            {
                if (Level == 0 && Agility == 0)
                {
                    power = 0;
                    return power;
                }
                else
                {
                    power = 8 * Level + 2 * Agility;
                    return power;
                }
                
            }

        }

    }
    
}
/*klasa nie deklaruje jawnie konstruktorów, więc kompilator wygeneruje jej
 konstruktor bezparametrowy, który wywołuje konstruktor bezparametrowy
 klasy Creature*/

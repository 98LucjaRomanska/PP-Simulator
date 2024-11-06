using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage;
        public int Rage
        {
            get { return rage; }
            init 
            { 
                if (value < 0) { rage = 0; }
                else if (value > 10) { rage = 10; }
            }
        }

        private bool _isHuntCalled = false;
        private int counter = 1;
        public void Hunt()
        {
            _isHuntCalled = true;
            counter++;
            if(counter%2 == 0)
            {
                rage++;
                Console.WriteLine($"Rage increased to {rage} level.");
            }
            _isHuntCalled = false; 
            Console.WriteLine($"{Name} is hunting.");

        }

        //wywołanie konstruktora bazowego i zdefiniowanie własnego klasy pochodnej
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        //public Orc() : base() { }

        //wywołanie konstruktora bazowego przez base() - konstruktor bezparametrowy
        public Orc() : base("Unknown", 1) { }

        //nadpisanie metody wirtualnej
        public override void SayHi()
        {
            Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
        }

        private int power;
        public override int Power
        {
            get
            {
                if (Level == 0 && Rage == 0)
                {
                    power = 0;
                    return power;
                }
                else
                {
                    power = 7 * Level + 3 * Rage;
                    return power;
                }

            }

        }
    }
}

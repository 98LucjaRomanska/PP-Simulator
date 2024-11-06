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
            init { rage = Validator.Limiter(value, 0, 10); }
        }

        private bool _isHuntCalled = false;
        private int counter = 1;
        public void Hunt()
        {
            _isHuntCalled = true;
            counter++;
            if(counter%2 == 0 && rage < 10)
            {
                rage++;
            }
            _isHuntCalled = false; 
            Console.WriteLine($"{Name} is hunting.");

        }
        public override string Info
        {
            get { return $"{Name} [{Level}] [{Rage}]"; }
        }
        /*
        public override String ToString(Creature c)
        {

            string x = c.GetType().ToString();
            string[] down_class = x.Split(".");
            string type = down_class[1].ToUpper();
            return $"{type} : {c.Info}";

        }*/

        //wywołanie konstruktora bazowego i zdefiniowanie własnego klasy pochodnej
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        public Orc() : base() { }

        //wywołanie konstruktora bazowego przez base() - konstruktor bezparametrowy
        //public Orc() : base("Unknown", 1) { }

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
                power = 7 * Level + 3 * Rage;
                return power;
            }

        }
    }
}

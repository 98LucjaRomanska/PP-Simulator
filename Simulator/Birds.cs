using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        private bool canFly = true;
        public Birds() : base() { }
    

        public bool CanFly
        {
            get { return canFly; }
            set { canFly = value;  }
        }
        public override string Info
        {
            
        get {
                string Enquire = CanFly ? "fly+" : "fly-";
                return $"{Description} ({Enquire}) <{Size}>"; 
            }
        }
    }
}

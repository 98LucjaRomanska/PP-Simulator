using System.ComponentModel;

namespace Simulator;

public class Animals //definicja klasy
{


    /* alternatywne podejście - z użyciem inicjatorów, bez konstruktora */
    private string description;
    public required string Description //required używane gdy mamy konstruktor domyślny
    { 
        get {return description; }
        init 
        {
            description = (value ?? "Unknown");
            description = description.Trim();
            if (description.Length < 3)
            {
                int rem = 3 - description.Length;
                string rem_h = "";
                for (int i = 0; i < rem; i++)
                {
                    rem_h += "#";
                }
                description += rem_h;
            }
            if (description.Length > 15)
            {
                description = description.Substring(0, 15);
            }

        }
    }
    public uint Size { get; set; } = 3;
    
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
    //ustawienie domyślnej wartości automatic property
    //w powyższej klasie jest konstruktor domyślny <<nie ma go napisanego formalnie>>
    //public string Info =>  $"{Description} <{Size}>"; 

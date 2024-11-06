using System.ComponentModel;

namespace Simulator;

public class Animals //definicja klasy
{


    /* alternatywne podejście - z użyciem inicjatorów, bez konstruktora */
    private string description;
    public string Description //required używane gdy mamy konstruktor domyślny
    { 
        get {return description; }
        init 
        {
            description = (value ?? "Unknown").Trim();
            description = Validator.Shortener(value, 3, 15, '#');

        }
    }
    public uint Size { get; set; } = 3;
    
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
    public override string ToString() 
    {
        return  $"{GetType().Name.ToUpper()}: {Info}";
    }
}
    //ustawienie domyślnej wartości automatic property
    //w powyższej klasie jest konstruktor domyślny <<nie ma go napisanego formalnie>>
    //public string Info =>  $"{Description} <{Size}>"; 

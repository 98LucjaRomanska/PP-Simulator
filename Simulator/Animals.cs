namespace Simulator;

public class Animals //definicja klasy
{


    /* alternatywne podejście - z użyciem inicjatorów, bez konstruktora */
    public required string Description { get; set; } //required używane gdy mamy konstruktor domyślny
    public uint Size { get; set; } = 3;
    
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
    //ustawienie domyślnej wartości automatic property
    //w powyższej klasie jest konstruktor domyślny <<nie ma go napisanego formalnie>>
    //public string Info =>  $"{Description} <{Size}>"; 

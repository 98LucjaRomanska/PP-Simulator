namespace Simulator;

    public class Creature
    {
    //właściwości automatyczne 
    public string Name { get; }
    public int Level { get; set; }

    //pola
    private string name; 
    private int level;

    //konstruktor
    public Creature(string name, int level = 1 )
    {
        Name = name;
        Level = level; 
    }
    public string Info //właściwość automatyczna - pole publiczne z get/set
    {
    get { return $"{Name} [{Level}]"; }
    }
    public void SayHi() //metoda
    { 
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}."); 
    }
  
    
        
            
        

}


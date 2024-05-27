namespace ConsoleAppCyberVoillier;

public class Penalite
{
    private string id;
    private double duree;
    private string desc; //raison de la penalite
    
    //properties
    public string Id
    {
        get => id;
        set => id = (value ?? throw new ArgumentNullException(nameof(value))).Trim()
            .Length == 0 ? throw new ArgumentException("ne peut pas être vide ou un espace", nameof(value))
                : value;
    }

    public double Duree
    {
        get => duree;
        set
        {
            duree = value <= 0 
                ? throw new ArgumentOutOfRangeException(nameof(value), "Duree doit être plus grande que zero.")
                : value;
        }
    }

    public string Desc
    {
        get => desc;
        set => desc = (value ?? throw new ArgumentNullException(nameof(value)))
            .Trim().Length == 0 
                ? throw new ArgumentException("Desc ne peut pas être vide ou un espace.", nameof(value))
                : value;
    }
    
    //constructor
    public Penalite(string id, double duree, string desc)
    {
        Id = id;
        Duree = duree;
        Desc = desc;
    }
}
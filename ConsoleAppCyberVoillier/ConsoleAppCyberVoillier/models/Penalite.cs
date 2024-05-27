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
        set => id = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Duree
    {
        get => duree;
        set => duree = value;
    }

    public string Desc
    {
        get => desc;
        set => desc = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    //constructor
    public Penalite(string id, double duree, string desc)
    {
        Id = id;
        Duree = duree;
        Desc = desc;
    }
}
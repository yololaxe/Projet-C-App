namespace ConsoleAppCyberVoillier;

public class Sponsor
{
    private int id;
    private string nom;

    //properties
    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    //constructor
    public Sponsor(int id, string nom)
    {
        this.id = id;
        this.nom = nom;
    }
}

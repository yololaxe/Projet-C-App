namespace ConsoleAppCyberVoillier;

public class Personne
{
    private int id;
    private string nom;
    private string prenom;
    private string post;
    
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

    public string Prenom
    {
        get => prenom;
        set => prenom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Post
    {
        get => post;
        set => post = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    //constructor
    public Personne(int id, string nom, string prenom, string post)
    {
        this.id = id;
        this.nom = nom;
        this.prenom = prenom;
        this.post = post;
    }
}


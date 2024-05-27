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
        set  {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Id doit être plus grand que zero.");
            }
            id = value;
        }
    }

    public string Nom
    {
        get => nom;
        set {
            nom = (value ?? throw new ArgumentNullException(nameof(value)))
                .Trim().Length == 0
                    ? throw new ArgumentException("Nom ne peut pas être vide ou un espace.", nameof(value))
                    : value;
        }
    }

    public string Prenom
    {
        get => prenom;
        set {
            prenom = (value ?? throw new ArgumentNullException(nameof(value)))
                .Trim().Length == 0
                    ? throw new ArgumentException("Prenom ne peut pas être vide ou un espace.", nameof(value))
                    : value;
        }
    }

    public string Post
    {
        get => post;
        set {
            post = (value ?? throw new ArgumentNullException(nameof(value)))
                .Trim().Length == 0
                    ? throw new ArgumentException("Post ne peut pas être vide ou un espace.", nameof(value))
                    : value;
        }
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


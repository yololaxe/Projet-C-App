namespace ConsoleAppCyberVoillier;

public class VoilierInscrit: Voilier
{
    private Personne[] equipage;
    private Sponsor[] entreprise;
    //private course;
    
    //properties
    public Personne[] Equipage
    {
        get => equipage;
        set => equipage = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Sponsor[] Entreprise
    {
        get => entreprise;
        set => entreprise = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    //constructor
    public VoilierInscrit(int id, string code, Personne[] equipage, Sponsor[] entreprise) : base(id, code)
    {
        this.equipage = equipage;
        this.entreprise = entreprise;
    }
}
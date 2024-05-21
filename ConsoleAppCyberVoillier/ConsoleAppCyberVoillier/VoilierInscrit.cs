namespace ConsoleAppCyberVoillier;

public class VoilierInscrit: Voilier
{
    
    private Sponsor[] entreprise;
    //private course;
    
    //properties
   

    public Sponsor[] Entreprise
    {
        get => entreprise;
        set => entreprise = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    //constructor
    public VoilierInscrit(int id, string code, Personne[] equipage, Sponsor[] entreprise) : base(id, code, equipage)
    {
       
        this.entreprise = entreprise;
    }
}
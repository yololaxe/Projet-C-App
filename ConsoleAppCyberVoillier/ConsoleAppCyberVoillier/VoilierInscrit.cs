namespace ConsoleAppCyberVoillier;

public class VoilierInscrit: Voilier
{
    
    private List<Sponsor> entreprises;
    private string codeInscription;

    public List<Sponsor> Entreprises
    {
        get => entreprises;
        set => entreprises = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string CodeInscription
    {
        get => codeInscription;
        set => codeInscription = value ?? throw new ArgumentNullException(nameof(value));
    }

    //constructor
    public VoilierInscrit(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription) : base(id, code, equipage)
    {
        this.entreprises = entreprises;
        this.codeInscription = codeInscription;
    }
}
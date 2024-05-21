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
    
    //CREATE, READ, UPDATE, DELETE
    private bool addSponsor(Sponsor sponsor)
    {
        if (sponsor == searchSponsor(sponsor.Id))
            return false;
        entreprises.Add(sponsor);
        return true;

    }

    private Sponsor searchSponsor(int id)
    {
        return entreprises.Find(a => a.Id == id);
    }

    private bool RemoveSponsor(Sponsor sponsor)
    {
        if (!entreprises.Contains(sponsor))
            return false;
        entreprises.Remove(sponsor);
        return true;
    }
}
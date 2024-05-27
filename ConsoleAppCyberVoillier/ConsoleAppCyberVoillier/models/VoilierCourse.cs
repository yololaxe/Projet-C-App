namespace ConsoleAppCyberVoillier;

public class VoilierCourse : VoilierInscrit
{
    private double tempsBrute;
    private double tempsReel;
    private List<Penalite> penalites = [];
    private List<Epreuve> epreuvesEffectues = [];
    
    //properties
    public double TempsBrute
    {
        get => tempsBrute;
        set => tempsBrute = value;
    }

    public double TempsReel
    {
        get => tempsReel;
        set => tempsReel = value;
    }

    public List<Epreuve> EpreuvesEffectues
    {
        get => epreuvesEffectues;
        set => epreuvesEffectues = value ?? throw new ArgumentNullException(nameof(value));
    }

    public VoilierCourse(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription, double tempsBrute, double tempsReel) : base(id, code, equipage, entreprises, codeInscription)
    {
        this.tempsBrute = tempsBrute;
        this.tempsReel = tempsReel;
    }

    
    public void AjouterTempsBrut(double tempsEpreuve) {
        tempsBrute += tempsEpreuve;
    }
    
    public void CalculerTempsReel() {
        double totalPenalites = penalites.Sum(p => p.Duree);
        TempsReel = tempsBrute - totalPenalites;
    }
}
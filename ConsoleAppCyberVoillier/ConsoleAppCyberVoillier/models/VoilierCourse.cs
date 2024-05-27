namespace ConsoleAppCyberVoillier;

public class VoilierCourse : VoilierInscrit
{
    private double tempsBrute;
    private double tempsReel = 0;
    private List<Penalite> penalites = [];
    private List<Epreuve> epreuvesEffectuees = [];
    
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

    public List<Epreuve> EpreuvesEffectuees
    {
        get => epreuvesEffectuees;
        set => epreuvesEffectuees = value ?? throw new ArgumentNullException(nameof(value));
    }


    public List<Penalite> Penalites
    {
        get => penalites;
        set => penalites = value ?? throw new ArgumentNullException(nameof(value));
    }

    public VoilierCourse(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription, double tempsBrute) : base(id, code, equipage, entreprises, codeInscription)
    {
        this.tempsBrute = tempsBrute;
    }

    public VoilierCourse(VoilierInscrit voilierInscrit, double tempsBrute) : base(voilierInscrit.Id, voilierInscrit.Code, voilierInscrit.Equipage, voilierInscrit.Entreprises, voilierInscrit.CodeInscription)
    {
        this.tempsBrute = tempsBrute;
    }
    
    public void AjouterTempsBrut(double tempsEpreuve) {
        tempsBrute += tempsEpreuve;
    }
    
    public void CalculerTempsReel() {
        double totalPenalites = penalites.Sum(p => p.Duree);
        TempsReel = tempsBrute - totalPenalites;
    }
}
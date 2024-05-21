namespace ConsoleAppCyberVoillier;

public class VoilierCourse : VoilierInscrit
{
    private double tempsBrute;
    private double tempsReel;
    private List<Penalite> penalites;
    
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

    //constructor
    public VoilierCourse(int id, string code, List<Personne> equipage, List<Sponsor> entreprise, double tempsBrute, string codeInscription) : base(id, code, equipage, entreprise, codeInscription)
    {
        TempsBrute = tempsBrute;
        TempsReel = 0;
        penalites = [];
    }
    
    //applique la penalite sur temps reel
    public void CalculPenalite()
    {
        foreach (Penalite penalite in penalites)
        {
            tempsReel += penalite.Duree;
        }
    }
    
    
}
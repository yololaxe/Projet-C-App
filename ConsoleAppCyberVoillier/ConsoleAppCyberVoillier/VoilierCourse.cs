namespace ConsoleAppCyberVoillier;

public class VoilierCourse : VoilierInscrit
{
    private double tempsBrute;
    private double tempsReel;
    
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
    public VoilierCourse(int id, string code, Personne[] equipage, Sponsor[] entreprise, double tempsBrute, double tempsReel) : base(id, code, equipage, entreprise)
    {
        this.tempsBrute = tempsBrute;
        this.tempsReel = tempsReel;
    }
}
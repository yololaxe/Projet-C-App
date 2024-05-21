namespace ConsoleAppCyberVoillier;

public class Course
{
    private VoilierInscrit[] inscrits;
    private VoilierCourse[] enCourse;

    public VoilierInscrit[] Inscrits
    {
        get => inscrits;
        set => inscrits = value ?? throw new ArgumentNullException(nameof(value));
    }

    public VoilierCourse[] EnCourse
    {
        get => enCourse;
        set => enCourse = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Course(VoilierInscrit[] inscrits, VoilierCourse[] enCourse)
    {
        Inscrits = inscrits;
        EnCourse = enCourse;
    }
}
namespace ConsoleAppCyberVoillier;

public class Course
{
    private List<VoilierInscrit> inscrits;
    private List<VoilierCourse> enCourse;
    private List<Epreuve> epreuves;

    public List<VoilierInscrit> Inscrits
    {
        get => inscrits;
        set => inscrits = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Epreuve> Epreuves
    {
        get => epreuves;
        set => epreuves = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<VoilierCourse> EnCourse
    {
        get => enCourse;
        set => enCourse = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Course(List<VoilierInscrit> inscrits, List<VoilierCourse> enCourse, List<Epreuve> epreuves)
    {
        Inscrits = inscrits;
        EnCourse = enCourse;
        Epreuves = epreuves;
    }
    
    
    //CRUD VOILIER INSCRIT
    public void AddVoilierInscrit(VoilierInscrit voilier)
    {
        if (voilier == GetVoilierCourse(voilier.Id) ) throw new ArgumentNullException(nameof(voilier));
        inscrits.Add(voilier);
    }

    public VoilierInscrit GetVoilierInscrit(int id)
    {
        return inscrits.Find(v => v.Id == id);
    }

    public void UpdateVoilierInscrit(VoilierInscrit updatedVoilier)
    {
        VoilierInscrit? voilier = GetVoilierInscrit(updatedVoilier.Id);
        if (voilier == null) throw new KeyNotFoundException("Voilier not found");

        int index = inscrits.IndexOf(voilier);
        inscrits[index] = updatedVoilier;
    }

    public void DeleteVoilierInscrit(int id)
    {
        VoilierInscrit? voilier = GetVoilierInscrit(id);
        if (voilier == null) throw new KeyNotFoundException("Voilier not found");

        inscrits.Remove(voilier);
    }

    // CRUD VOILIERCOURSE
    public bool InscrireVoilier(Voilier voilier, List<Personne> equipage, List<Sponsor> sponsors)
    {
        if (inscrits.Any(v => v.Code == voilier.Code))
        {
            Console.WriteLine($"Voilier déjà inscrit : {voilier.Code}");
            return false;
        }

        VoilierInscrit voilierInscrit = new VoilierInscrit(
            voilier.Id, 
            voilier.Code,
            equipage,
            sponsors, 
            $"C{DateTime.Now.Year}{inscrits.Count + 1:0000}"
            );
        
        inscrits.Add(voilierInscrit);
        return true;
    }

    public bool DesinscrireVoilier(string codeInscription)
    {
        var voilierInscrit = inscrits.FirstOrDefault(v => v.CodeInscription == codeInscription);
        if (voilierInscrit == null)
        {
            return false;
        }
        inscrits.Remove(voilierInscrit);
        return true;
    }
    
    public VoilierCourse GetVoilierCourse(int id)
    {
        return enCourse.Find(v => v.Id == id);
    }

    public void UpdateVoilierCourse(VoilierCourse updatedVoilier)
    {
        VoilierCourse? voilier = GetVoilierCourse(updatedVoilier.Id);
        if (voilier == null) throw new KeyNotFoundException("Voilier not found");

        int index = enCourse.IndexOf(voilier);
        enCourse[index] = updatedVoilier;
    }

    public void DeleteVoilierCourse(int id)
    {
        VoilierCourse voilier = GetVoilierCourse(id);
        if (voilier == GetVoilierCourse(voilier.Id)) throw new KeyNotFoundException("Voilier not found");

        enCourse.Remove(voilier);
    }

    // CRUD EPREVE
    public void AddEpreuve(Epreuve epreuve)
    {
        if (epreuve == GetEpreuve(epreuve.Numero)) throw new ArgumentNullException(nameof(epreuve));
        epreuves.Add(epreuve);
    }

    public Epreuve GetEpreuve(int numero)
    {
        return epreuves.FirstOrDefault(e => e.Numero == numero);
    }

    public void UpdateEpreuve(Epreuve updatedEpreuve)
    {
        Epreuve? epreuve = GetEpreuve(updatedEpreuve.Numero);
        if (epreuve == null) throw new KeyNotFoundException("Epreuve not found");

        int index = epreuves.IndexOf(epreuve);
        epreuves[index] = updatedEpreuve;
    }

    public void DeleteEpreuve(int id)
    {
        Epreuve epreuve = GetEpreuve(id);
        if (epreuve == GetEpreuve(epreuve.Numero)) throw new KeyNotFoundException("Epreuve not found");

        epreuves.Remove(epreuve);
    }
    
    //METHODES 
    
    public List<VoilierCourse> ClasserVoiliers(Course course) {
        List<VoilierCourse> voiliersComplets = course.EnCourse
            .Where(v => v.EpreuvesEffectues.Count == course.Epreuves.Count)
            .ToList();
        
        foreach (VoilierCourse voiliersComplet in voiliersComplets)
        {
            voiliersComplet.CalculerTempsReel();
        }
    
        List<VoilierCourse> classement = voiliersComplets.OrderBy(v => v.TempsReel).ToList();
        return classement;
    }

}
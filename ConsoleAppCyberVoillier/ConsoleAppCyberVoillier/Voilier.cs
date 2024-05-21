namespace ConsoleAppCyberVoillier;

public class Voilier
{
    private int id;
    private string code;
    private List<Personne> equipage = new();

    //properties
    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Code
    {
        get => code;
        set => code = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Personne> Equipage
    {
        get => equipage;
        set => equipage = value ?? throw new ArgumentNullException(nameof(value));
    }

    //constructor
    public Voilier(int id, string code, List<Personne> equipage)
    {
        
        Id = id;
        Code = code;
        Equipage = equipage;
    }

    private bool AddPersonne(Personne personne)
    {
        if (personne == SearchPersonne(personne.Id))
            return false;
        equipage.Add(personne);
        return true;

    }

    private Personne SearchPersonne(int id)
    {
        return equipage.Find(a => a.Id == id);
    }

    private bool RemovePersonne(Personne personne)
    {
        if (!equipage.Contains(personne))
            return false;
        equipage.Remove(personne);
        return true;
    }

    //CREATE, READ, UPDATE, DELETE


}
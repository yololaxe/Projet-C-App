namespace ConsoleAppCyberVoillier;

public class Voilier
{
    private int id;
    private string code;
    //private course

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

    //constructor
    public Voilier(int id, string code)
    {
        Id = id;
        Code = code;
    }
}
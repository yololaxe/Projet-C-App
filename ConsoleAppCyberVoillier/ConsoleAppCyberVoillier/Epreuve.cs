namespace ConsoleAppCyberVoillier;

public class Epreuve
{
    private int numero;
    private string libelle;
    private int ordre;

    public int Numero
    {
        get => numero;
        set => numero = value;
    }

    public string Libelle
    {
        get => libelle;
        set => libelle = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Ordre
    {
        get => ordre;
        set => ordre = value;
    }

    public Epreuve(int numero, string libelle, int ordre)
    {
        Numero = numero;
        Libelle = libelle;
        Ordre = ordre;
    }
    
    //DECALER L'ORDRE
}
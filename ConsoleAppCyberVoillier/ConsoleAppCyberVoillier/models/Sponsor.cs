using System;

namespace ConsoleAppCyberVoillier;

public class Sponsor
{
    private int id;
    private string nom;

    //properties cc
    public int Id
    {
        get => id;
        set  {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Id doit être plus grand que zero.");
            }
            id = value;
        }
    }

    public string Nom
    {
        get => nom;
        set {
            nom = (value ?? throw new ArgumentNullException(nameof(value)))
                .Trim().Length == 0
                    ? throw new ArgumentException("Nom ne peut pas être vide ou un espace.", nameof(value))
                    : value;
        }
    }

    //constructor
    public Sponsor(int id, string nom)
    {
        this.id = id;
        this.nom = nom;
    }
}

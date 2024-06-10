using System;

namespace ConsoleAppCyberVoillier;

public class Penalite
{
    private string id;
    private double duree;
    private string description; //raison de la penalite
    public int? VoilierCourseId { get; set; }
    public VoilierCourse VoilierCourse { get; set; }
    
    //properties
    public string Id
    {
        get => id;
        set => id = (value ?? throw new ArgumentNullException(nameof(value))).Trim()
            .Length == 0 ? throw new ArgumentException("ne peut pas être vide ou un espace", nameof(value))
                : value;
    }

    public double Duree
    {
        get => duree;
        set
        {
            duree = value <= 0 
                ? throw new ArgumentOutOfRangeException(nameof(value), "Duree doit être plus grande que zero.")
                : value;
        }
    }

    public string Description
    {
        get => description;
        set => description = (value ?? throw new ArgumentNullException(nameof(value)))
            .Trim().Length == 0 
                ? throw new ArgumentException("Desc ne peut pas être vide ou un espace.", nameof(value))
                : value;
    }
    
    //constructor
    public Penalite() {}
    public Penalite(string id, double duree, string description)
    {
        Id = id;
        Duree = duree;
        Description = description;
    }
    
}
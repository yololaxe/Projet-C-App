using System;
using System.Collections.Generic;

namespace ConsoleAppCyberVoillier;

public class VoilierInscrit: Voilier
{
    
    private List<Sponsor> entreprises;
    private string codeInscription;
//properties
    public List<Sponsor> Entreprises
    {
        get => entreprises;
        set  {
            entreprises = value ?? throw new ArgumentNullException(nameof(value));
            if (entreprises.Count == 0)
            {
                throw new ArgumentException("Entreprises ne peut être vide.", nameof(value));
            }
        }
    }

    public string CodeInscription
    {
        get => codeInscription;
        set {
            codeInscription = (value ?? throw new ArgumentNullException(nameof(value)))
                .Trim().Length == 0
                    ? throw new ArgumentException("CodeInscription ne peut être vide ou un espace.", nameof(value))
                    : value;
        }
    }

    //constructor
    public VoilierInscrit(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription) : base(id, code, equipage)
    {
        this.entreprises = entreprises;
        this.codeInscription = codeInscription;
    }
    
    //CREATE, READ, UPDATE, DELETE
    private bool AddSponsor(Sponsor sponsor)
    {
        if (sponsor == SearchSponsor(sponsor.Id))
            return false;
        entreprises.Add(sponsor);
        return true;

    }

    private Sponsor SearchSponsor(int id)
    {
        return entreprises.Find(a => a.Id == id);
    }

    private bool RemoveSponsor(Sponsor sponsor)
    {
        if (!entreprises.Contains(sponsor))
            return false;
        entreprises.Remove(sponsor);
        return true;
    }
    
}
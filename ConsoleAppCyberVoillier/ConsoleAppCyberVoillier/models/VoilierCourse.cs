using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCyberVoillier;

public class VoilierCourse : VoilierInscrit
{
    private double tempsBrute;
    private double tempsReel = 0;
    private List<Penalite> penalites = [];
    private List<Epreuve> epreuvesEffectuees = [];
    
    //properties
    public double TempsBrute
    {
        get => tempsBrute;
        set => tempsBrute = (value >= 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Le temps brut doit être positif.");
    }

    public double TempsReel
    {
        get => tempsReel;
        set => tempsReel = (value >= 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Le temps réel doit être positif.");
    }

    public List<Epreuve> EpreuvesEffectuees
    {
        get => epreuvesEffectuees;
        set => epreuvesEffectuees = value ?? throw new ArgumentNullException(nameof(value), "La liste des épreuves effectuées ne peut pas être nulle.");
    }

    public List<Penalite> Penalites
    {
        get => penalites;
        set => penalites = value ?? throw new ArgumentNullException(nameof(value), "La liste des pénalités ne peut pas être nulle.");
    }
    public VoilierCourse(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription, double tempsBrute) : base(id, code, equipage, entreprises, codeInscription)
    {
        this.tempsBrute = tempsBrute;
    }

    public VoilierCourse(VoilierInscrit voilierInscrit, double tempsBrute) : base(voilierInscrit.Id, voilierInscrit.Code, voilierInscrit.Equipage, voilierInscrit.Entreprises, voilierInscrit.CodeInscription)
    {
        this.tempsBrute = tempsBrute;
    }
    
    public void AjouterTempsBrut(double tempsEpreuve) {
        tempsBrute += tempsEpreuve;
    }
    
    public void CalculerTempsReel() {
        double totalPenalites = penalites.Sum(p => p.Duree);
        TempsReel = tempsBrute - totalPenalites;
    }
}
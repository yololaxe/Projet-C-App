using System;

namespace ConsoleAppCyberVoillier;

public class Epreuve
{
    private int numero;
    private string libelle;
    private int ordre;

    public int Numero
    {
        get => numero;
        set => numero = (value > 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Numero doit être supérieur à 0");
    }

    public string Libelle
    {
        get => libelle;
        set => libelle = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(nameof(value), "Libelle doit ne peut pas être null ou vide");
    }

    public int Ordre
    {
        get => ordre;
        set => ordre = (value > 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "ordre doit être supérieur à 0");
    }

    public Epreuve(int numero, string libelle, int ordre)
    {
        Numero = numero;
        Libelle = libelle;
        Ordre = ordre;
    }
    
    //DECALER L'ORDRE
}
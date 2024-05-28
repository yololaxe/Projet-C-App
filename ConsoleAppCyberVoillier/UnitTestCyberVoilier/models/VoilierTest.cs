using ConsoleAppCyberVoillier;

namespace UnitTestCyberVoilier.models;

[TestFixture]
[TestOf(typeof(Sponsor))]
public class VoilierTest
{

    [Test]
    public void CreerVoilier_AvecCodeEtEquipage_CreeCorrectement()
    {
        string code = "VA102SETE";
        List<Personne> equipage = new List<Personne>
        {
            new Personne(1,"Doe","John", "Skipper"),
            new Personne(2,"Ouagro","Jack", "Skipper"),
            new Personne(3,"Rogue","Louise", "AutreRôle"),
            new Personne(4,"Panamous","Martha", "AutreRôle")
        };
            
            
        Voilier voilier = new Voilier(1, code, equipage);
            
        Assert.That(voilier.Code, Is.EqualTo(code));
        Assert.That(voilier.Equipage.Count, Is.EqualTo(4));
        Assert.That(voilier.Equipage[0].Nom, Is.EqualTo("Doe"));
    }
}
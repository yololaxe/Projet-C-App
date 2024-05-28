using ConsoleAppCyberVoillier;

namespace UnitTestCyberVoilier.models;

[TestFixture]
[TestOf(typeof(Personne))]
public class EpreuveTest
{

    [Test]
    public void CreerEpreuve_AvecNumeroLibelleEtOrdre_CreeCorrectement()
    {
        // Arrange
        int numero = 1;
        string libelle = "Test Epreuve";
        int ordre = 2;

        // Act
        Epreuve epreuve = new Epreuve(numero, libelle, ordre);

        // Assert
        Assert.That(epreuve.Numero, Is.EqualTo(numero));
        Assert.That(epreuve.Libelle, Is.EqualTo(libelle));
        Assert.That(epreuve.Ordre, Is.EqualTo(ordre));
    }

    [Test]
    public void CreerEpreuve_AvecNumeroNegatif_DevraitLeverArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Epreuve(-1, "Test Epreuve", 2));
    }

    [Test]
    public void CreerEpreuve_AvecLibelleNull_DevraitLeverArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Epreuve(1, null, 2));
    }

    [Test]
    public void CreerEpreuve_AvecLibelleVide_DevraitLeverArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Epreuve(1, "", 2));
    }

    [Test]
    public void CreerEpreuve_AvecOrdreNegatif_DevraitLeverArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Epreuve(1, "Test Epreuve", -2));
    }
}
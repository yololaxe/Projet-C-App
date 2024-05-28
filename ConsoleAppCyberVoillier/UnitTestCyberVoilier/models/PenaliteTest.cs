using ConsoleAppCyberVoillier;

namespace UnitTestCyberVoilier.models;

[TestFixture]
[TestOf(typeof(Penalite))]
public class PenaliteTest
{

    [Test]
    public void AjouterPenalite_VoilierNonInscrit_DoitLancerUneException()
    {
            // Arrange
            var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
            var course = new Course(epreuves);

            // Assert
            Assert.Throws<InvalidOperationException>(() => course.AjouterPenalite(999, new Penalite("test", 10, "test")), "Le voilier n'est pas inscrit.");
    }
    [Test]
    public void AjouterPenalite_PenalitesAjouteesCorrectement()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Act
        course.AjouterPenalite(voilier.Id, new Penalite("test", 10, "test"));

        // Assert
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).Penalites.Count, Is.EqualTo(1));
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).Penalites[0].Desc, Is.EqualTo("test"));
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).Penalites[0].Duree, Is.EqualTo(10));
    }
}
using NUnit.Framework;
using ConsoleAppCyberVoillier;
using System.Collections.Generic;

namespace TestProject1
{
    [TestFixture]
    public class VoilierTests
    {
        [Test]
        public void CreerVoilier_AvecCodeEtEquipage_CreeCorrectement()
        {
            string code = "VA102SETE";
            var equipage = new List<Personne>
            {
                new Personne(1,"Doe","John", "Skipper"),
                new Personne(2,"Ouagro","Jack", "Skipper"),
                new Personne(3,"Rogue","Louise", "AutreRôle"),
                new Personne(4,"Panamous","Martha", "AutreRôle")
            };
            
            var voilier = new Voilier(1, code, equipage);
            
            Assert.AreEqual(code, voilier.Code);
            Assert.AreEqual(4, voilier.Equipage.Count);
            Assert.AreEqual("Doe", voilier.Equipage[0].Nom);
        }
    }
}
using NUnit.Framework;
using Library;
using System.Collections.Generic;


namespace Library.Test
{
    public class WinnersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método SelectWinners.
        /// En este caso se evalúa que se seleccione al ganador correctamente.
        /// </summary>

        [Test]
        public void SelectWinners_ListOfTravelers_ListOfWinner()
        {
            Traveler traveler1 = new Traveler();
            Traveler traveler2 = new Traveler();
            Traveler traveler3 = new Traveler();
            traveler1.AddScore(20);
            traveler2.AddScore(30);
            traveler3.AddScore(40);

            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler1);
            travelers.Add(traveler2);
            travelers.Add(traveler3);

            Winners winners = new Winners(travelers);

            List<Traveler> correctResult = new List<Traveler>();
            correctResult.Add(traveler3);

            Assert.AreEqual(winners.ListOfWinners, correctResult);

        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método SelectWinners.
        /// En este caso se evalúa que si hay 2 ganadores se agreguen ambos a la lista de ganadores.
        /// </summary>

         [Test]
        public void SelectWinners_ListOfTravelers_ListOfWinners()
        {
            Traveler traveler1 = new Traveler();
            Traveler traveler2 = new Traveler();
            Traveler traveler3 = new Traveler();
            traveler1.AddScore(40);
            traveler2.AddScore(20);
            traveler3.AddScore(40);

            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler1);
            travelers.Add(traveler2);
            travelers.Add(traveler3);

            Winners winners = new Winners(travelers);

            List<Traveler> correctResult = new List<Traveler>();
            correctResult.Add(traveler1);
            correctResult.Add(traveler3);

            Assert.AreEqual(winners.ListOfWinners, correctResult);

        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método SelectWinners.
        /// En este caso se evalúa que si todos los viajeros van directo hasta el EndStep sin entrar a ninguna experiencia, al tener todos la 
        /// misma cantidad de puntos (0), todos serían ganadores.
        /// </summary>
        [Test]
        public void SelectWinners_ListOfTravelers_AllWinners()
        {
            Traveler traveler1 = new Traveler();
            Traveler traveler2 = new Traveler();
            Traveler traveler3 = new Traveler();

            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler1);
            travelers.Add(traveler2);
            travelers.Add(traveler3);

            Winners winners = new Winners(travelers);

            List<Traveler> correctResult = new List<Traveler>();
            correctResult.Add(traveler1);
            correctResult.Add(traveler2);
            correctResult.Add(traveler3);

            Assert.AreEqual(winners.ListOfWinners, correctResult);

        }
    }
}
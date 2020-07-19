using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class StationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método PlayerArrival cuando el parámetro decision es true.
        /// </summary>

        [Test]
        public void PlayerArrival_TravelerAndDecision_UpdatePlayersInAndUpdateScore()
        {
            int peopleLimit = 3;
            bool decision = true;
            Traveler traveler = new Traveler();
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler);
            StationTestDummy station = new StationTestDummy(peopleLimit, new EndStep());
            station.PlayerArrival(traveler,decision);
            Assert.AreEqual(station.PlayersIn,travelers);
            Assert.AreEqual(station.PlayersIn[0].Score,2);
        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método PlayerArrival cuando el parámetro decision es false.
        /// </summary>

        [Test]
         public void PlayerArrival_TravelerAndDecision_UpdatePlayersIn()
        {
            int peopleLimit = 3;
            bool decision = false;
            Traveler traveler = new Traveler();
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler);
            StationTestDummy station = new StationTestDummy(peopleLimit, new EndStep());
            station.PlayerArrival(traveler,decision);
            Assert.AreEqual(station.PlayersIn,travelers);
            Assert.AreEqual(station.PlayersIn[0].Score,0);
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método IsRoomAvailable.
        /// </summary>

        [Test]
         public void IsRoomAvailable_IsThereRoomOrNot()
        {
            int peopleLimit = 1;
            bool decision = true;
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            StationTestDummy station = new StationTestDummy(peopleLimit, new EndStep());
            station.PlayerArrival(travelers[0],decision);
            station.PlayerArrival(travelers[1],decision);
            Assert.AreEqual(station.IsRoomAvailable(),false);
            
        }



        /// <summary>
        /// Clase dummy que al heredar de Station se usa para crear una instancia de esta clase y poder llamar al método PlayerArrival que es el que se
        /// va a probar en el test PlayerArrival_TravelerAndDecision_UpdatePlayersIn() y PlayerArrival_TravelerAndDecision_UpdatePlayersInAndUpdateScore().
        /// </summary>
        internal class StationTestDummy : Station
        {
            public StationTestDummy(int peopleLimit, Step nextStep) : base(peopleLimit, nextStep)
            {

            }
            public override void Host(Traveler player)
            {
                player.AddScore(2);
            }
        }
    }
}
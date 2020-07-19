using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class FirstStepTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método PlayerArrival.
        /// Se evalúa que ambos viajeros estén en la lista de viajeros del FirstStep.
        /// </summary>

        [Test]
        public void PlayerArrival_TravelerAndDecision_UpdatePlayersIn()
        {   
            int peopleLimit = 3;
            bool decision = true;
            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            ThermalWaters thermalWaters = new ThermalWaters(peopleLimit,new EndStep());
            Farm farm = new Farm(peopleLimit,thermalWaters);
            FirstStep firstStep = new FirstStep(farm);
            firstStep.PlayerArrival(travelers[0],decision);
            firstStep.PlayerArrival(travelers[1],decision);
            Assert.AreEqual(firstStep.PlayersIn[0],travelers[0]);
            Assert.AreEqual(firstStep.PlayersIn[1],travelers[1]);
        }
    }
}
using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class EndStepTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de PlayerArrival.
        /// Evalúa que el viajero esté en la lista de viajeros de EndStep.
        /// </summary>

        [Test]
        public void PlayerArrival_TravelerAndDecision_UpdatePlayersIn()
        {   
            bool decision = true;
            EndStep endStep = new EndStep();
            Traveler traveler = new Traveler();
            endStep.PlayerArrival(traveler,decision);
            Assert.AreEqual(endStep.PlayersIn[0],traveler);
            
        }
    }
}
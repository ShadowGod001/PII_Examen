using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class OceanTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método Host.
        /// En este caso la correcta asignación de Score y la correcta cantidad de veces que un viajero pasa por la experiencia.
        /// </summary>

        [Test]
        public void Host_Traveler_UpdateRegisterPlayerAndUpdateScore()
        {
            int peopleLimit = 3;
            Ocean ocean = new Ocean(peopleLimit, new EndStep());
            Traveler traveler = new Traveler();
            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler);
            
            ocean.Host(traveler);
            Assert.AreEqual(ocean.PlayersRegistry[traveler], 1);
            Assert.AreEqual(travelers[0].Score, 1);
           
            ocean.Host(traveler);
            Assert.AreEqual(ocean.PlayersRegistry[traveler], 2);
            Assert.AreEqual(travelers[0].Score, 4);
            
            ocean.Host(traveler);
            Assert.AreEqual(ocean.PlayersRegistry[traveler], 3);
            Assert.AreEqual(travelers[0].Score, 9);
            
        }
    }
}
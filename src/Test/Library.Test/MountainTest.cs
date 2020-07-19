using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test
{
    public class MountainTest
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
            Mountain mountain = new Mountain(peopleLimit, new EndStep());
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());

            mountain.Host(travelers[0]);
            Assert.AreEqual(mountain.PlayersRegistry[travelers[0]], 1);
            Assert.AreEqual(travelers[0].Score, 1);

            mountain.Host(travelers[0]);
            Assert.AreEqual(mountain.PlayersRegistry[travelers[0]], 2);
            Assert.AreEqual(travelers[0].Score, 3);

            mountain.Host(travelers[0]);
            Assert.AreEqual(mountain.PlayersRegistry[travelers[0]], 3);
            Assert.AreEqual(travelers[0].Score, 6);

            mountain.Host(travelers[0]);
            Assert.AreEqual(mountain.PlayersRegistry[travelers[0]], 4);
            Assert.AreEqual(travelers[0].Score, 10);
        
        }
    }
}
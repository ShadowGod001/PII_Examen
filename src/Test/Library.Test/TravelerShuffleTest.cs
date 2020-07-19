using NUnit.Framework;
using System.Collections.Generic;
using Library;
using System.Linq;
using System;

namespace Library.Test
{
    public class TravelerShuffleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método GetTravelerShuffler. 
        /// En este caso que no se puedan crear varias instancias de TravelerShuffler y que al obtener la 
        /// instancia a través del método GetShuffler esta instancia sea siempre la misma.
        /// </summary>

        [Test]
        public void GetTravelerShuffler()
        {
            TravelerShuffler shufflerOne = TravelerShuffler.GetShuffler();
            TravelerShuffler shufflerTwo = TravelerShuffler.GetShuffler();

            Assert.AreEqual(shufflerOne,shufflerTwo);
            Assert.AreSame(shufflerOne,shufflerTwo);

        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método ShuffleTravelers.
        /// Se controla que la lista devuelta por el método ShuffledTravelers resulte aleatoria comprobando que sea 
        /// diferente a la lista original.
        /// </summary>

        [Test]
        public void ShuffleTravelers_ListOfTravelers_ShuffledListOfTravelers()
        {
            TravelerShuffler shufflerOne = TravelerShuffler.GetShuffler();
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            Assert.AreNotEqual(shufflerOne.ShuffleTravelers(travelers),travelers);
           

        }

        
    }
}
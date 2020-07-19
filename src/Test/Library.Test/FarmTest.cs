using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class FarmTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa que el método Host llame correctamente al método AddCoins de Traveler y la cantidad de 
        /// Coins agregada sea la esperada.
        /// </summary>

        [Test]
        public void Host_Traveler_UpdateCoins()
        {   
            int peopleLimit = 2;
            Farm farm = new Farm(peopleLimit, new EndStep());
            Traveler traveler = new Traveler();
            farm.Host(traveler);
            Assert.AreEqual(traveler.Coins,3);
        }
    }
}
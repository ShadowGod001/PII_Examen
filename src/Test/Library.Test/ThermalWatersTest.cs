using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class ThermalWatersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa que el método Host llame correctamente al método AddScore de Traveler y la cantidad de 
        /// Score agregada sea la esperada.
        /// </summary>

        [Test]
        public void Host_Traveler_ScoreUpdate()
        {   
            int peopleLimit = 3;
            int travelerScore = 2;
            Traveler traveler = new Traveler();
            ThermalWaters twaters = new ThermalWaters(peopleLimit, new EndStep());
            twaters.Host(traveler);

            Assert.AreEqual(traveler.Score,travelerScore);
            
        }
    }
}
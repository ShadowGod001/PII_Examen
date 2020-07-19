using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class TravelerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de la condición dentro del método AddScore.
        /// Controla que el Score no pase del máximo valor permitido.
        /// </summary>
        
        [Test]
        public void Traveler_ScoreOverflow()
        {
            Traveler traveler = new Traveler();
            traveler.AddScore(int.MaxValue);
            traveler.AddScore(1);

            Assert.AreEqual(traveler.Score, int.MaxValue);
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de la condición dentro del método AddCoins.
        /// Test que controla que la cantidad de Coins no pase del máximo valor permitido.
        /// </summary>
        
        [Test]
        public void Traveler_CoinsOverflow()
        {
            Traveler traveler = new Traveler();
            traveler.AddCoins(int.MaxValue);
            traveler.AddCoins(1);

            Assert.AreEqual(traveler.Coins, int.MaxValue);
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método AddScore. 
        /// En este caso que se añada Score correctamente.
        /// </summary>
        
        [Test]
        public void AddScore_Score_UpdatedScore()
        {
            Traveler traveler = new Traveler();
            traveler.AddScore(10);
            traveler.AddScore(10);
            int result = 20;

            Assert.AreEqual(traveler.Score, result);
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método AddCoins. 
        /// En este caso que se añadan Coins correctamente.
        /// </summary>
        
        [Test]
        public void AddCoins_Coins_UpdatedCoins()
        {
            Traveler traveler = new Traveler();
            traveler.AddCoins(10);
            int result = 10;

            Assert.AreEqual(traveler.Coins, result);
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método RemoveScore. 
        /// En este caso que se remueva Score correctamente.
        /// </summary>

        [Test]
        public void RemoveScore_Score_UpdatedScore()
        {
            Traveler travelerOne = new Traveler();
            travelerOne.AddScore(10);
            travelerOne.RemoveScore(5);
            int resultOne = 5;

            Assert.AreEqual(travelerOne.Score, resultOne);
            
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método RemoveCoins. 
        /// En este caso que se remuevan Coins correctamente.
        /// </summary>

        [Test]
        public void RemoveCoins_Coins_UpdatedCoins()
        {
            Traveler traveler = new Traveler();
            traveler.AddCoins(10);
            traveler.RemoveCoins(5);
            int result = 5;

            Assert.AreEqual(traveler.Coins, result);
            
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método RemoveScore. 
        /// En este caso controla que no pueda haber Score negativa.
        /// </summary>

          [Test]
        public void RemoveScore_Score_NeutralScore()
        {
            Traveler traveler = new Traveler();
            traveler.RemoveScore(10);
            int result = 0;

            Assert.AreEqual(traveler.Score, result);
        }

        /// <summary>
        /// Test que controla el correcto funcionamiento del método RemoveCoins. 
        /// En este caso que no pueda haber cantidad de Coins negativa.
        /// </summary>

          [Test]
        public void RemoveCoins_Coins_NeutralCoins()
        {
            Traveler traveler = new Traveler();
            traveler.RemoveCoins(10);
            int result = 0;

            Assert.AreEqual(traveler.Coins, result);
        }

    }
}
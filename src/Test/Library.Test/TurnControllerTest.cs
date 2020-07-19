using NUnit.Framework;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de los métodos TurnToNextPlayer y GetPlayerInTurn.
        /// Verifica de efectivamente el primer turno sea del primer viajero de la lista.
        /// </summary>

        [Test]
        public void TurnToNextPlayerAndGetPlayerInTurn_PlayerInTurn()
        {
            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            TurnController turn = new TurnController(travelers);
            turn.TurnToNextPlayer();
            Assert.AreEqual(turn.GetPlayerInTurn(),travelers[0]);
            
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de los métodos TurnToNextPlayer y GetPlayerInTurn.
        /// En este caso se verifica que se cumpla exitosamente el ciclo de turnos de los viajeros.
        /// </summary>

        [Test]
        public void TurnToNextPlayerAndGetPlayerInTurn_PlayerTurnCycle()
        {   
            List <Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            TurnController turn = new TurnController(travelers);
            turn.TurnToNextPlayer();
            Assert.AreEqual(turn.GetPlayerInTurn(),travelers[0]);
            turn.TurnToNextPlayer();
            Assert.AreEqual(turn.GetPlayerInTurn(),travelers[1]);
            turn.TurnToNextPlayer();
            Assert.AreEqual(turn.GetPlayerInTurn(),travelers[0]);

            
        }
    }
}
using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class StepTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test para evaluar el correcto funcionamiento del método PlayerDeparture.
        /// Se compara una lista que queda vacía con una lista de travelers que con el método PlayerDeparture queda vacía.
        /// </summary>

        [Test]
        public void PlayerDeparture_Traveler_UpdatePlayersIn()
        {
            Traveler traveler = new Traveler();
            StepTestDummy step = new StepTestDummy();
            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(traveler);
            travelers.Remove(traveler);
            step.PlayersIn.Add(traveler);
            step.PlayerDeparture(traveler);

            Assert.AreEqual(step.PlayersIn, travelers);



        }

    }

    /// <summary>
    /// Clase dummy que al heredar de Step se usa para crear una instancia de esta clase y poder llamar al método PlayerDeparture que es el que se va 
    /// a probar en el test PlayerDeparture_Traveler_UpdatePlayersIn().
    /// </summary>

    internal class StepTestDummy : Step
    {   
        public StepTestDummy()
        {
            this.PlayersIn = new List<Traveler>();
        }
        public override void PlayerArrival(Traveler player, bool decision)
        {
            
        }

        public override void RegisterPlayer(Traveler player)
    {
        
    }

    }

}
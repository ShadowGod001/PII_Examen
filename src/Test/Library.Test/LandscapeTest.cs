using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class LandscapeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método RegisterPlayer.
        /// Se prueban las dos condiciones. Si no está, se agrega y si está, aumenta en uno la cantidad de veces que estuvo.
        /// </summary>

        [Test]
        public void RegisterPlayer_Traveler_UpdatePlayersRegistry()
        {   
            int peopleLimit = 3;
            LandscapeTestDummy landscape = new LandscapeTestDummy(peopleLimit, new EndStep());
            List<Traveler> travelers = new List<Traveler>();
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());

            Assert.AreEqual(landscape.PlayersRegistry.ContainsKey(travelers[0]),false);

            landscape.RegisterPlayer(travelers[0]);
            Assert.AreEqual(landscape.PlayersRegistry.ContainsKey(travelers[0]),true);
            Assert.AreEqual(landscape.PlayersRegistry[travelers[0]],1);

            landscape.RegisterPlayer(travelers[0]);
            Assert.AreEqual(landscape.PlayersRegistry.ContainsKey(travelers[0]),true);
            Assert.AreEqual(landscape.PlayersRegistry[travelers[0]],2);
            
        }
    }

    /// <summary>
    /// Clase dummy que al heredar de Landscape se usa para crear una instancia de esta clase y poder llamar al método RegisterPlayer 
    /// que es el que se va a probar en el test RegisterPlayer_Traveler_UpdatePlayersRegistry().
    /// </summary>
    internal class LandscapeTestDummy : Landscape
    {
        public LandscapeTestDummy(int peopleLimit, Step nextStep) : base(peopleLimit, nextStep)
        {

        }
        public override void Host(Traveler player)
        {
            
        }
    }
}
using NUnit.Framework;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class TravelerNullExceptionTest
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// Test que evalúa el correcto funcionamiento de la excepción TravelerNullException.
        /// </summary>
        [Test]
        public void PlayerArrival_TravelerAndDecision_TravelerNullException()
        {
            void Excecute()
            {
                StationTestDummmy station = new StationTestDummmy(3, new EndStep());
                station.PlayerArrival(null, true);
            }

            Assert.Throws(typeof(TravelerNullException), Excecute);
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento de la excepción TravelerNullException en el constructor de GameData.
        /// </summary>
        [Test]
        public void GameDataConstructor_TravelerAndBoard_TravelerNullException()
        {
            void Excecute()
            {   
                int peopleLimit = 3;
                EndStep endStep = new EndStep();
                Mountain mountain = new Mountain(peopleLimit, endStep);
                Ocean ocean = new Ocean(peopleLimit, mountain);
                ThermalWaters thermalWaters = new ThermalWaters(peopleLimit, ocean);
                Farm farm = new Farm(peopleLimit, thermalWaters);
                FirstStep firstStep = new FirstStep(farm);
                List<Step> steps = new List<Step>();
                steps.Add(farm);
                steps.Add(thermalWaters);
                steps.Add(ocean);
                steps.Add(mountain);
                Board board = new Board(steps, firstStep, endStep);
                List<Traveler> travelers = new List<Traveler>();
                travelers.Add(null);
                travelers.Add(null);
                GameData data = new GameData(travelers,board);
            }

            Assert.Throws(typeof(TravelerNullException), Excecute);
        }



    }

    /// <summary>
    /// Clase dummy que al heredar de Station se usa para crear una instancia de esta clase y poder probar el correcto funcionamiento de la excepción.
    /// </summary>
    internal class StationTestDummmy : Station
    {
        public StationTestDummmy(int peopleLimit, Step nextStep) : base(peopleLimit, nextStep)
        {

        }
        public override void Host(Traveler player)
        {
            player.AddCoins(3);
        }
    }

}
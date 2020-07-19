using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Test
{
    public class MovementTest
    {

        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Test que evalúa que el método MakeMove funcione correctamente.
        /// En este caso se evalúa el correcto recorrido de un viajero hasta llegar al final desde donde ya no se puede seguir moviendo hacia delante.
        /// </summary>

        [Test]
        public void MakeMove_TravelerAndDecision_MoveTravelerFromOneStepToAnother()
        {
            int peopleLimit = 3;
            bool decision = true;
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
            travelers.Add(new Traveler());
            GameData data = new GameData(travelers, board);
            Movement movement = new Movement(data);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(firstStep.PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(steps[0].PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(steps[1].PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(steps[2].PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(steps[3].PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(endStep.PlayersIn[0], travelers[0]);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(endStep.PlayersIn[0], travelers[0]);

        }

        /// <summary>
        /// Test que evalúa que el método MakeMove funcione correctamente y no deje entrar sí la estación no permite más viajeros.
        /// </summary>

        [Test]
        public void MakeMove_TravelerAndDecision_NotLetTravelerIntoACompleteStation()
        {
            int peopleLimit = 1;
            bool decision = true;
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
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            GameData data = new GameData(travelers, board);
            Movement movement = new Movement(data);

            movement.MakeMove(travelers[0], decision);
            movement.MakeMove(travelers[0], decision);

            movement.MakeMove(travelers[1], decision);
            movement.MakeMove(travelers[1], decision);

            Assert.AreEqual(steps[0].PlayersIn[0], travelers[0]);
            Assert.AreEqual(steps[0].PlayersIn[1], travelers[1]);

            Assert.AreEqual(steps[0].PlayersIn[0].Coins, 3);


            Assert.AreEqual(steps[0].PlayersIn[1].Coins, 0);


        }

        /// <summary>
        /// Test que evalúa que el método AreThereMovementsLeft funcione correctamente. 
        /// En este caso se evalúa varias veces con 2 jugadores y se espera que solo retorne false cuando ambos llegaron al final.
        /// </summary>
        [Test]
        public void AreThereMovementsLeft_AreTravelersStillTraveling()
        {
            int peopleLimit = 3;
            bool decision = true;

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
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            GameData data = new GameData(travelers, board);
            Movement movement = new Movement(data);

            movement.MakeMove(travelers[0], decision);
            movement.MakeMove(travelers[0], decision);

            movement.MakeMove(travelers[1], decision);
            Assert.AreEqual(movement.AreThereMovementsLeft(), true);

            movement.MakeMove(travelers[0], decision);
            movement.MakeMove(travelers[0], decision);
            movement.MakeMove(travelers[0], decision);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(movement.AreThereMovementsLeft(), true);

            movement.MakeMove(travelers[1], decision);
            movement.MakeMove(travelers[1], decision);
            movement.MakeMove(travelers[1], decision);
            movement.MakeMove(travelers[1], decision);
            movement.MakeMove(travelers[1], decision);
            Assert.AreEqual(movement.AreThereMovementsLeft(), false);

        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método FindStepWithPlayer.
        /// </summary>

        [Test]
        public void FindStepWithPlayer_Traveler_Step()
        {
            int peopleLimit = 3;
            bool decision = true;
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
            travelers.Add(new Traveler());
            travelers.Add(new Traveler());
            GameData data = new GameData(travelers, board);
            Movement movement = new Movement(data);
            movement.MakeMove(travelers[0], decision);
            Assert.AreEqual(movement.FindStepWithPlayer(travelers[0]), firstStep);
            Assert.AreEqual(movement.FindStepWithPlayer(travelers[1]), null);

        }



    }
}
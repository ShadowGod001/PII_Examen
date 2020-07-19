using NUnit.Framework;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class NextStepNullExceptionTest
    {
        [SetUp]
        public void Setup()
        {
        }

       
        
        /// <summary>
        /// Test que evalúa el correcto funcionamiento de la excepción NextStepNullException.
        /// </summary>
        [Test]
        public void StationConstructor()
        {
            void Excecute()
            {
                StationTestDummy station = new StationTestDummy(3, null);
            }

            Assert.Throws(typeof(NextStepNullException), Excecute);
        }


    }

    /// <summary>
    /// Clase dummy que al heredar de Station se usa para crear una instancia de esta clase y poder probar el correcto funcionamiento de la excepción.
    /// </summary>
    internal class StationTestDummy : Station
    {
        public StationTestDummy(int peopleLimit, Step nextStep) : base(peopleLimit, nextStep)
        {

        }
        public override void Host(Traveler player)
        {
            
        }
    }
}
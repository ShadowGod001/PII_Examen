using System;
using System.Collections.Generic;
using System.Linq;
using Library;

/// <summary>
/// La clase TravelerShuffler mezcla la lista de travelers participantes para decidir en qué orden comienzan a moverse.
/// La implementación es la que se debe encargar de mezclar a los jugadores para saber de quién es turno. 
/// De no quererse utilizar se puede jugar perfectamente de todas formas ya que no condiciona el movimiento de los travelers.
/// Cumple con el patrón Expert porque tiene toda la información necesaria para poder mezclar a los travelers.
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de mezclar la lista de travelers. 
/// La única razón de cambio de la clase es que se tenga que cambiar la manera en que se mezclan los travelers
/// Hay alta cohesión debido al cumplimiento de SRP ya que la única responsabilidad de la clase es mezclar a los travelers. 
/// Hay algo de acoplamiento ya que para mezclar debe recibir por parámetro una lista de objetos tipo Traveler.
/// Sin embargo este nivel de acoplamiento es necesario para que haya mayor modularidad y esté abierto a la extensión.
/// Esta clase ademas utiliza el patron Singleton ya que solo se necesita una instancia que tenga los datos del orden de movimiento.
/// </summary>

namespace Library
{
    public class TravelerShuffler
    {   
        /// <summary>
        /// Variable estática donde se guarda la única instancia de TravelerShuffler.
        /// </summary>
        private static TravelerShuffler shuffler;

        /// <summary>
        /// Constructor privado para que sólo la misma clase se pueda instanciar.
        /// </summary>
        private TravelerShuffler()
        {

        }

        /// <summary>
        /// Método get que se llama desde afuera de la clase para crear una nueva instancia de TravelerShuffler.
        /// </summary>
        /// <returns></returns>
        public static TravelerShuffler GetShuffler()
        {
            if (shuffler == null)
            {
                shuffler = new TravelerShuffler();
            }
            return shuffler;
        }

        /// <summary>
        /// Método que recibe una lista de objetos tipo Traveler y los mezcla.
        /// </summary>
        /// <param name="travelers"></param>
        /// <returns></returns>
        public List<Traveler> ShuffleTravelers(List<Traveler> travelers)
        {
            List<Traveler> shuffledList = travelers;
            Random random = new Random();

            List<Traveler> travelersToSelect = new List<Traveler>(travelers);

            if (travelers.Count > 1)
            {

                shuffledList = new List<Traveler>();


                while (shuffledList.Count != travelers.Count)
                {

                    int Index = random.Next(0, travelersToSelect.Count - 1);

                    Traveler randomTraveler = travelersToSelect[Index];
                    shuffledList.Add(randomTraveler);
                    travelersToSelect.Remove(randomTraveler);
                }
                
                if (shuffledList.SequenceEqual(travelers))
                {
                    shuffledList.Reverse();
                }
            }
            
            return shuffledList;
        }

    }
}

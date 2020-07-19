using System;
using System.Collections.Generic;

/// <summary>
/// Esta clase se encarga de controlar de cuál viajero es turno de moverse.
/// La implementación es la que se debe encargar de saber de cuál viajero es turno.
/// Si no se desea usar este sistema de turnos, se puede no implementar y se podrá jugar y mover a los jugadores de todas formas.
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de devolver de cuál viajero es turno. 
/// La única razón de cambio de la clase es que se quiera cambiar de cuál viajero es turno arbitrariamente.
/// Hay alta cohesión debido al cumplimiento de SRP ya que la única responsabilidad de la clase es la de devolver de cuál viajero es turno.
/// Exite algo de acoplamiento porque se recibe una lista de objetos tipo Traveler que es necesaria para devolver el turno de los jugadores.
/// Este nivel de acoplamiento es necesario para que haya mayor modularidad.
/// Se usa agregación con Traveler porque se crean instancias de Traveler en TurnController pero además hay instancias de Traveler guardadas en otras clases.
/// </summary>

namespace Library
{
    public class TurnController
    {

        private List<Traveler> Travelers;
        
        /// <summary>
        /// Este índice esta seteado a -1 para que el primer turno sea del primer traveler de la lista al pasar a ser 0 al ejecutarse TurnToNextPlayer() por primera vez. 
        /// Una vez se mueve el primero nunca más va a volver al -1. Se va a mantener en un bucle entre 0 y la cantidad de viajeros en la lista.
        /// </summary>
        private int TurnOfIndex = -1;

        /// <summary>
        /// El constructor necesita recibir una lista de Travelers.
        /// </summary>
        /// <param name="travelers"></param>
        public TurnController(List<Traveler> travelers)
        {
            this.Travelers = travelers;
        }

        /// <summary>
        /// Método que cambia el turno y devuelve de quien es el turno siguiente.
        /// Toma el índice seteado a -1 y entra en la condición else. Una vez pasó esto se le va a sumar 1 devolviendo el jugador que tenga índice 0 en la lista.
        /// La implementación se debe encargar de llamar a este método para controlar de quíen es el turno. 
        /// Si no desea usar este método de turnos, puede no implementarlo y se podrá jugar y mover a los jugadores de todas formas.
        /// </summary>
        /// <returns></returns>

        public Traveler TurnToNextPlayer()
        {
            if (TurnOfIndex == Travelers.Count-1)
            {
                TurnOfIndex = 0;
            }
            else
            {
                TurnOfIndex++;
            }

            return Travelers[TurnOfIndex];
        }

        /// <summary>
        /// Método que devuelve de quién es el turno sin cambiarlo
        /// </summary>
        /// <returns></returns>

        public Traveler GetPlayerInTurn()
        {
            return Travelers[TurnOfIndex];
        }
    }
}
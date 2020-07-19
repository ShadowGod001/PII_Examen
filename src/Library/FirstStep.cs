using Library;
using System.Collections.Generic;

/// <summary>
/// La clase FirstStep representa el primer paso en el juego desde donde todos los jugadores comienzan.
/// Sin embargo, no se tiene porque esperar a que todos los jugadores estén en el FirstStep para comenzar.
/// Hay alta cohesión porque la responsabilidad de la clase es agregar a la lista de PlayersIn a los viajeros que lleguen al FirstStep.
/// Hay acoplamiento porque hereda la clase abstracta Step, es decir que si Step se rompe FirstStep lo hará también. 
/// Sin embargo es un nivel de acoplamiento aceptable para mantener la modularidad.
/// La clase cumple con poliformismo ya que implementa la operación PlayerArrival y define la operación según sus necesidades.
/// Esta operación a su vez es implementada por EndStep y Station por lo que cumple la definición de operación polimórfica de que la operación debe
/// ser implementada por dos o más objetos de diferentes tipos.
/// FirstStep hereda la clase abstracta Step, por lo tanto FirstStep es subtipo de Step.
/// Se cumple composición entre FirstStep y Board siendo FirstStep la componente y Board la compuesta. 
/// Esto es porque se se guardan instancias de FirstStep en Board y sólo existen guardadas instancias de FirstStep en Board.
/// </summary>

namespace Library
{
    public class FirstStep : Step
    {   
        /// <summary>
        /// El constructor de la clase instancia una nueva lista PlayersIn donde se guardan los travelers, y un NextStep que se recibe por 
        /// parámetro para indicar a cuál step el jugador se deberá mover después de este.
        /// </summary>
        /// <param name="nextStep"></param>
        public FirstStep(Step nextStep)
        {   
            this.NextStep = nextStep;
            this.PlayersIn = new List<Traveler>();
            this.PlayersRegistry = new Dictionary<Traveler, int>();
        }

        /// <summary>
        /// Método que recibe un objeto tipo Traveler por parámetro, verifica que no sea null y lo agrega al diccionario PlayersRegistry si no está, 
        /// y si está aumenta en 1 su valor.
        /// </summary>
        /// <param name="player"></param>
        public override void RegisterPlayer(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException();
            }

            if (PlayersRegistry.ContainsKey(player))
            {
                PlayersRegistry[player]++;
            }
            else
            {
                PlayersRegistry.Add(player, 1);
            }
        }

        /// <summary>
        /// Método que recibe una condición y un objeto tipo Traveler valida que no sea null y lo agrega a la lista de PlayersIn.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="decision"></param>
        public override void PlayerArrival(Traveler player, bool decision)
        {
            if (player == null)
            {
                throw new TravelerNullException("Traveler no puede ser null");
            }
            
            PlayersIn.Add(player);
            RegisterPlayer(player);


        }
    }
}
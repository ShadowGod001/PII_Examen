using Library;
using System.Collections.Generic;

/// <summary>
/// La clase EndStep representa el último paso del juego, de manera que cuando todos los jugadores hayan llegado a este paso se acaba el juego.
/// Hay alta cohesión porque la responsabilidad de la clase es agregar a la lista de PlayersIn a los viajeros que lleguen al EndStep.
/// Hay acoplamiento porque hereda la clase abstracta Step, es decir que si Step se rompe EndStep lo hará también. 
/// Sin embargo es un nivel de acoplamiento aceptable para mantener la modularidad.
/// La clase cumple con poliformismo ya que implementa la operación PlayerArrival y define la operación según sus necesidades.
/// Esta operación a su vez es implementada por FirstStep y Station por lo que cumple la definición de operación polimórfica de que la operación debe
/// ser implementada por dos o más objetos de diferentes tipos.
/// EndStep hereda la clase abstracta Step, por lo tanto EndStep es subtipo de Step.
/// Se cumple composición entre EndStep y Board siendo EndStep la componente y Board la compuesta. 
/// Esto es porque se se guardan instancias de EndtStep en Board y sólo existen guardadas instancias de EndStep en Board.
/// </summary>

namespace Library
{
    public class EndStep : Step
    {
        /// <summary>
        /// Método que recibe una condición y un objeto tipo Traveler el cuál valida que no sea null y lo agrega a la lista de PlayersIn.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="decision"></param>
        public override void PlayerArrival(Traveler player, bool decision)
        {
            if (player == null)
            {
                throw new TravelerNullException();
            }

            PlayersIn.Add(player);
            RegisterPlayer(player);
            
            
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
        /// El constructor de la clase instancia un NextStep null para indicar que este es el último step y una nueva instancia 
        /// de la lista PlayersIn donde se guardan los travelers.
        /// </summary>
        public EndStep(string name = "EndStep") : base(name)
        {
            this.NextStep = null;
            this.PlayersIn = new List<Traveler>();
            this.PlayersRegistry = new Dictionary<Traveler, int>();
        }
    }
}

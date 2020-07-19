using System;
using System.Collections.Generic;

/// <summary>
/// Esta clase se encarga de mover a los travelers desde un step a otro.
/// Cumple con el patrón Expert porque tiene toda la información necesaria para poder mover a los travelers.
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de mover a los jugadores. 
/// La única razón de cambio de la clase es que se tenga que cambiar la manera en que se mueven los travelers.
/// Hay alta cohesión debido al cumplimiento de SRP ya que la única responsabilidad de la clase es la de mover a los travelers. 
/// Existe algo de acoplamiento porque hay métodos que reciben como parámetros objetos de otras clases y 
/// hay una instancia de GameData en la clase de la que se depende para utilizar los métodos de la clase.
/// Sin embargo este nivel de acoplamiento es necesario para que haya mayor modularidad y esté abierto a la extensión.
/// Se usa composición entre Movement y GameData siendo Movement la clase compuesta y GameData la clase componente.
/// Esto es porque se se guardan instancias de GameData en Movement y sólo existen guardadas instancias de GameData en Movement.
/// Se usa delegación en el método MakeMove cuando se llaman a los métodos PlayerArrival y PlayerDeparture del objeto componente Data.
/// Se cumple con LSP en los métodos MakeMove y FindStepWithPlayer.
/// </summary>
/// <param name="player"></param>
/// <param name="decision"></param>

namespace Library
{   
    public class Movement
    {   
        /// <summary>
        /// Objeto Data de tipo GameData donde se guarda una lista de objetos tipo Traveler y un objeto tipo Board.
        /// </summary>
        /// <value></value>
        public GameData Data { get; private set; }

        /// <summary>
        /// El constructor de la clase recibe por parámetro un objeto tipo GameData que luego asigna al objeto Data.
        /// </summary>
        /// <param name="data"></param>
        public Movement(GameData data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Método que permite movel al traveler. 
        /// Recibe un objeto tipo traveler y una condición que de ser True le va a permitir al viajero entrar
        /// a las experiencias y sumar puntos y monedas, y de ser false se va a quedar en la "puerta" de la experiencia sin ganar nada.
        /// MakeMove utiliza un objeto Step pero funcionará correctamente si se utiliza un subtipo de step por lo que el método cumple con LSP.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="decision"></param>
        public void MakeMove(Traveler player, bool decision)
        {
            if (player == null)
            {
                throw new TravelerNullException("No puedes mover un Traveler null");
            }

            if (AreThereMovementsLeft())
            {
                Step actualStep = FindStepWithPlayer(player); 
                if (actualStep == null)
                {
                    Data.GetFirstStep().PlayerArrival(player, decision);
                }
                else
                {
                    if (actualStep.NextStep != null)
                    {
                        actualStep.PlayerDeparture(player); 
                        actualStep.NextStep.PlayerArrival(player, decision);
                    }
                }
            }
        }

        /// <summary>
        /// Método para saber si todos los jugadores ya llegaron a la meta o no.
        /// No quedan más movimientos cuando todos los travelers llegaron al EndStep.
        /// Este método es necesario para la responsabilidad de mover a los viajeros.
        /// </summary>
        /// <returns></returns>
        public bool AreThereMovementsLeft()
        {
            foreach (var player in Data.ListPlayers)
            {
                if (!Data.GetEndStep().PlayersIn.Contains(player))
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Método que encuentra la posición del traveler.
        /// FindStepWithPlayer utiliza una lista objetos Step pero funcionará correctamente si se encuentran en la lista objetos subtipos de step 
        /// por lo que el método cumple con LSP.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>

        public Step FindStepWithPlayer(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException("El Traveler no puede ser null");
            }

            if (Data.GetFirstStep().PlayersIn.Contains(player))
            {
                return Data.GetFirstStep();
            }

            else if (Data.GetEndStep().PlayersIn.Contains(player))
            {
                return Data.GetEndStep();
            }

            else
            {
                foreach (Step step in Data.GetListOfSteps())
                {
                    if (step.PlayersIn.Contains(player))
                    {
                        return step;
                    }
                }
            }

            return null;
        }
    }
}
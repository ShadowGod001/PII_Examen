using System.Collections.Generic;

/// <summary>
/// La clase GameData guarda la información necesaria para la partida. 
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de guardar la información.
/// La única razón de cambio de la clase es que se tenga que cambiar la información que se guarda.
/// Hay alta cohesión debido al cumplimiento del SRP, ya que la única responsabilidad de la clase es guardar y devolver información de la partida.
/// Hay bajo acoplamiento porque guarda una lista de travelers y un objeto tipo Board, del cuál sólo este último se usa para obtener información a través de los métodos Get.
/// Cumple con Demeter poque oculta a la clase Board de Movement, ya que para acceder a atributos de Board se va a tener que hacer a través de
/// los métodos Get de GameData. 
/// De esa manera las clases que utilizen GameData no interactúan con Board como un objeto indirecto.
/// Cumple con el patrón Indirección porque GameData existe como mediador entre Board y Movement reduciendo el acoplamiento entre ellos.
/// Se usa agregación porque se crean instancias de Traveler en GameData pero además hay instancias de Traveler guardadas en otras clases.
/// Hay una relación de composición entre Board y GameData siendo GameData la compuesta y Board la componente.
/// Esto es porque se se guardan instancias de Board en GameData y sólo existen guardadas instancias de Board en GameData.
/// También hay composición entre Movement y GameData siendo GameData la clase componente y Movement la clase compuesta.
/// Esto es porque se se guardan instancias de GameData en Movement y sólo existen guardadas instancias de GameData en Movement.
/// </summary>

namespace Library
{
    public class GameData
    {   
        /// <summary>
        /// La lista ListPlayers guarda la lista de objetos tipo Traveler que van a jugar.
        /// </summary>
        /// <value></value>
        public List<Traveler> ListPlayers { get; private set; }

        /// <summary>
        /// Este objeto tipo Board guarda la lista de steps que forman el recorrido de la partida.
        /// </summary>
        /// <value></value>
        private Board GameBoard;

        /// <summary>
        /// Este método devuelve la lista de objetos tipo Step guardada en GameBoard.
        /// </summary>
        /// <returns></returns>
        public List<Step> GetListOfSteps()
        {
            return GameBoard.LisOfSteps;
        }

        /// <summary>
        /// Este método devuelve el step FirstStep.
        /// </summary>
        /// <returns></returns>
        public FirstStep GetFirstStep()
        {
            return GameBoard.FirstStep;
        }

        /// <summary>
        /// Este método devuelve el step EndStep.
        /// </summary>
        /// <returns></returns>
        public EndStep GetEndStep()
        {
            return GameBoard.EndStep;
        }

        /// <summary>
        /// El constructor de la clase recibe por parámetro una lista de objetos tipo Traveler que se envía como argumento al
        /// método CheckListOfTravelers y un objeto tipo Board a los que luego asigna a los objetos ListPlayers y GameBoard.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="board"></param>
        public GameData(List<Traveler> players, Board board)
        {
            CheckListOfTravelers(players);

            this.ListPlayers = players;
            this.GameBoard = board;
        }

        /// <summary>
        /// Método que evalúa si hay algún elemento null en la lista de travelers recibida por parámetro.
        /// </summary>
        /// <param name="travelers"></param>
        private void CheckListOfTravelers(List<Traveler> travelers)
        {
            foreach (Traveler player in travelers)
            {
                if (player == null)
                {
                    throw new TravelerNullException("Un Traveler en la lista era null");
                }
            }
        }
    }
}
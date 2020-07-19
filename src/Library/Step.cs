using System.Collections.Generic;

/// <summary>
/// Un Step es un punto dentro de la ruta del juego.
/// Hay alta cohesión porque se encarga de definir los atributos y métodos que implementará cualquier step, de los cuales los dos métodos
/// que se implementan son de llegada y salida de los travelers y el atributo lista PlayersIn es necesario para estos dos métodos.
/// Existe algo de acoplamiento porque hay métodos que reciben como parámetros objetos tipo Traveler.
/// Sin embargo este nivel de acoplamiento es necesario para que haya mayor modularidad y esté abierto a la extensión.
/// Cumple con DIP porque Step funciona como una clase más abstracta que Station que hace que Movement dependa de esta en vez de Station.
/// También se cumple DIP entre Movement y todas las clases que heredan de Station ya que ahora en vez de depender de esas clases mas específicas 
/// dependen de Step que es más abstracta.
/// Cumple con OCP ya que al ser una clase abstracta se puede heredar para extenderla sin modificar la clase en sí.
/// Se cumple composición entre Step y Board siendo Step la componente y Board la compuesta. 
/// Esto es porque se se guardan instancias de Step en Board y sólo existen guardadas instancias de Step en Board.
/// Se usa agregación porque se crean instancias de Traveler en Step pero además hay instancias de Traveler guardadas en otras clases.
/// </summary> 
namespace Library
{
    public abstract class Step
    {   

        /// <summary>
        /// Diccionario donde se guarda como clave el viajero y como valor la cantidad de veces que entró a la experiencia.
        /// </summary>
        /// <value></value>
        public Dictionary<Traveler, int> PlayersRegistry { get; set; }

        /// <summary>
        /// Este atributo indica el próximo step al que se va a mover el viajero.
        /// </summary>
        /// <value></value>
        public Step NextStep { get; set; }

        /// <summary>
        /// Lista de viajeros en el step.
        /// </summary>
        /// <value></value>
        public List<Traveler> PlayersIn { get; set; }

        /// <summary>
        /// Método abstracto que recibe un por parámetro un objeto tipo Traveler.
        /// </summary>
        /// <param name="player"></param>
        public abstract void RegisterPlayer(Traveler player);

        /// <summary>
        /// Este método controla si el viajero quiere entrar al step. 
        /// En caso de no querer, se tiene que especificar, sino entra por defecto.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="decision"></param>
        public abstract void PlayerArrival(Traveler player, bool decision = true);

        /// <summary>
        /// Este método se encarga de remover a los viajeros de la lista de viajeros de este step cuando pasen al siguiente.
        /// Antes de removerlos se verifica que el viajero no sea null.
        /// </summary>
        /// <param name="player"></param>
        public void PlayerDeparture(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException("El Traveler que se intenta quitar es null");
            }
            PlayersIn.Remove(player);
        }

    }
}

using System.Collections.Generic;
using Library;

/// <summary>
/// Un Station es un tipo de Step.
/// Hay alta cohesión porque todas sus responsabilidades tienen que ver con el manejo de los viajeros. Contie el atributo PeopleLimit que es donde 
/// se guarda la cantidad de viajeros que puede haber en cada estación y sus métodos tienen que controlar si el viajero entra a la experiencia
/// y que sucede cuando entra.
/// Hay acoplamiento porque hereda la clase abstracta Step, es decir que si step se rompe Station lo hará también.
/// Sin embargo este nivel de acoplamiento es necesario para que haya mayor modularidad y esté abierto a la extensión.
/// Station hereda la clase abstracta Step, por lo tanto Station es subtipo de Step.
/// Cumple con OCP ya que al ser una clase abstracta se puede heredar para extenderla sin modificar la clase en sí.
/// </summary>
public abstract class Station : Step
{

    /// <summary>
    /// La cantidad máxima de jugadores que pueden estar simultaneamente en una Station.
    /// </summary>
    private int peopleLimit;


    /// <summary>
    /// Se valida que la cantidad máxima de jugadores no sea negativa.
    /// </summary>
    /// <value></value>
    public int PeopleLimit 
    { get
        {
            return this.peopleLimit;
        }
      set
        {
            if (value < 0)
            {
                this.peopleLimit = 0;
            }
            else
            {
                this.peopleLimit = value;
            }
        }
    }

    /// <summary>
    /// El constructor de Station recibe como parámetro un entero que se asigna al atributo PeopleLimit y un objeto de tipo Step
    /// que se valida que no sea null y se agrega a su atributo NextStep.
    /// </summary>
    /// <param name="peopleLimit"></param>
    /// <param name="nextStep"></param>
    public Station(int peopleLimit, Step nextStep)
    {
        this.PeopleLimit = peopleLimit;
        this.PlayersIn = new List<Traveler>();
        if(nextStep == null)
        {
            throw new NextStepNullException("El siguiente Step no puede ser null");
        }
        this.NextStep = nextStep;
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
    /// Se altera el método PlayerArrival definido en la superclase Step para adecuarlo a sus necesidades.
    /// Se valida que el traveler recibido por parámetro no sea null, lo agrega a la lista de PlayersIn y 
    /// evalúa si se cumplen las condiciones para la entrada del viajero a la experiencia.
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

        if (decision == true && IsRoomAvailable() == true && !PlayersRegistry.ContainsKey(player))
        {
            RegisterPlayer(player);
            Host(player);
        }
        
    }

    /// <summary>
    /// En el método abstracto Host se especifica todo lo que suceda con el jugador si entra a la experiencia.
    /// </summary>
    /// <param name="player"></param>
    public abstract void Host(Traveler player);

    /// <summary>
    /// En el método IsRoomAvailable se compara la cantidad de viajeros en la estación con la cantidad máxima permitida.
    /// </summary>
    /// <returns></returns>
    public bool IsRoomAvailable()
    {
        return (PlayersIn.Count <= PeopleLimit);
    }

}
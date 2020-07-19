using System;
using Library;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Esta clase se encarga de seleccionar al ganador. 
/// Si hay varios jugadores con la misma cantidad de puntos habrá varios ganadores.
/// La implementación se debe encargar de llamar a esta clase para elegir al ganador.
/// La clase cumple con Expert ya que conoce toda la información necesaria para decidir al ganador.
/// La clase se creó basandose en SRP, ya que la única responsabilidad que tiene es la de seleccionar al ganador. 
/// Su única razón de cambio sería que se cambiara la forma en que se selecciona el ganador.
/// Hay alta cohesión debido al cumplimiento de SRP ya que la única responsabilidad de la clase es seleccionar al ganador.
/// Exite algo de acoplamiento porque se recibe una lista de objetos tipo Traveler con los viajeros que están jugando.
/// Este nivel de acoplamiento es necesario para que haya mayor modularidad.
/// Se usa agregación porque se crean instancias de Traveler en Winners pero además hay instancias de Traveler guardadas en otras clases.
/// </summary>

namespace Library
{
    public class Winners
    {
        /// <summary>
        /// Lista de objetos tipo Traveler donde se van a guardar los ganadores.
        /// </summary>
        /// <value></value>
        public List <Traveler> ListOfWinners { get; private set; }

        /// <summary>
        /// Constructor de la clase que recibe como parámetro una lista de objetos tipo Traveler y los pasa como argumento a SelectWinners.
        /// </summary>
        /// <param name="travelers"></param>
        public Winners(List<Traveler> travelers)
        {
            this.ListOfWinners = SelectWinners(travelers);

        }

        /// <summary>
        /// Método que recorre la lista de travelers recibida por parámetro y guarda en la lista de winners a quién/es tenga/n mayor puntaje.
        /// </summary>
        /// <param name="travelers"></param>
        /// <returns></returns>
        private List<Traveler> SelectWinners(List<Traveler> travelers)
        {
            

            List<Traveler> winners = new List<Traveler>();
            Dictionary<Traveler, int> leaderboard = new Dictionary<Traveler, int>();

            foreach (var traveler in travelers)
            {
                if (traveler == null)
                {
                    throw new TravelerNullException("Un traveler en la lista era null");
                }

                leaderboard.Add(traveler, traveler.Score);
            }

            int max = leaderboard.Values.Max();

            foreach (var par in leaderboard)
            {
                if (par.Value == max)
                {
                    winners.Add(par.Key);
                }
            }

            return winners;

        }
    }
}
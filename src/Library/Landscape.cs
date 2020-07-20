using Library;
using System.Collections.Generic;

/// <summary>
/// Esta clase define un nuevo tipo de Station llamado Landscape (Paisaje).
/// Hay alta cohesión porque la responsabilidad de la clase es identificar cuantas veces entró el viajero a cada experiencia.
/// Hay acoplamiento porque hereda la clase abstracta Station, es decir que si Station se rompe Landscape lo hará también.
/// Sin embargo este nivel de acoplamiento es necesario para que haya mayor modularidad y esté abierto a la extensión.
/// Landscape hereda la clase abstracta Station, por lo tanto Landscape es subtipo de Station.
/// Cumple con OCP ya que al ser una clase abstracta se puede heredar para extenderla sin modificar la clase en sí.
/// </summary>

namespace Library
{
    public abstract class Landscape : Station
    {   
        

        /// <summary>
        /// Constructor de la clase que recibe por parámetro un entero y un objeto de tipo Step e instancia al objeto PlayersRegistry.
        /// </summary>
        /// <param name="peopleLimit"></param>
        /// <param name="nextStep"></param>
        /// <returns></returns>
        public Landscape(int peopleLimit, Step nextStep, string name = "Landscape") : base(peopleLimit, nextStep, name)
        {
          
        }

        
    }
}
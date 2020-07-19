using Library;
using System.Collections.Generic;

/// La clase Mountain representa la experiencia del paisaje de montaña.
/// Hay alta cohesión porque la responsabilidad de la clase es asignar puntos a los viajeros.
/// Hay acoplamiento porque hereda de la clase abstracta Landscape, es decir que si Landscape se rompe Mountain lo hará también. 
/// Sin embargo es un nivel de acoplamiento aceptable para mantener la modularidad.
/// La clase cumple con poliformismo ya que implementa la operación Host y define la operación según sus necesidades.
/// Esta operación a su vez es implementada por ThermalWaters, Ocean, y Farm por lo que cumple la definición de operación polimórfica 
/// de que la operación debe ser implementada por dos o más objetos de diferentes tipos.
/// Mountain hereda la clase abstracta Landscape, por lo tanto Mountain es subtipo de Landscape.
/// Se usa delegación en el método Host cuando se llaman al método RegisterPlayer de la superclase Landscape.

namespace Library
{
    public class Mountain : Landscape
    {
        
        /// <summary>
        /// El constructor debe recibir como parámetro un int que represente la cantidad máxima de viajeros que van a poder estar en la experiencia
        /// al mismo tiempo.
        /// </summary>
        /// <param name="peopleLimit"></param>
        /// <returns></returns>
        public Mountain(int peopleLimit, Step nextStep) : base(peopleLimit, nextStep)
        {

        }

        /// <summary>
        /// En el método Host en este caso se verifica que el traveler que se recibió por parámetro no sea null.
        /// Luego se pasa el objeto tipo Traveler como argumento al método RegisterPlayer de la superclase Landscape.
        /// Después se calcula cuantos puntos se le van a asignar al viajero dependiendo de la cantidad de veces que haya pasado por la experiencia.
        /// </summary>
        /// <param name="player"></param>
        public override void Host(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException("Traveler no puede ser null");
            }

            RegisterPlayer(player);

            if (PlayersRegistry[player] == 1)
            {
                player.AddScore(1);
            }
            else if (PlayersRegistry[player] > 1)
            {
                int suma = 1;

                for (int n = 1; n < PlayersRegistry[player]; n++)
                {
                    suma += 1;
                }
                player.AddScore(suma);
            }
        }

    }
}
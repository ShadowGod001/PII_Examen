using Library;

/// <summary>
/// La clase ThermalWaters representa la experiencia de las aguas termales.
/// Hay alta cohesión porque la responsabilidad de la clase es asignar puntos a los viajeros.
/// Hay acoplamiento porque hereda de la clase abstracta Station, es decir que si Station se rompe ThermalWaters lo hará también. 
/// Sin embargo es un nivel de acoplamiento aceptable para mantener la modularidad.
/// La clase cumple con poliformismo ya que implementa la operación Host y define la operación según sus necesidades.
/// ThermalWaters hereda de la clase abstracta Station, por lo tanto ThermalWaters es un tipo de Station.
/// Esta operación a su vez es implementada por Mountain, Ocean, y Farm por lo que cumple la definición de operación polimórfica 
/// de que la operación debe ser implementada por dos o más objetos de diferentes tipos.
/// </summary>

namespace Library
{
    public class ThermalWaters : Station
    {   
        /// <summary>
        /// El constructor debe recibir como parámetro un int que represente la cantidad máxima de viajeros que van a poder estar en la experiencia
        /// al mismo tiempo.
        /// </summary>
        /// <param name="peopleLimit"></param>
        /// <returns></returns>
        public ThermalWaters(int peopleLimit, Step nextStep, string name = "ThermalWaters") : base(peopleLimit, nextStep, name)
        {

        }

        /// <summary>
        /// En el método Host en este caso se valida que el viajero que se recibe por parámetro no sea null y se le asignan 2 puntos.
        /// </summary>
        /// <param name="player"></param>
        public override void Host(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException("Traveler no puede ser null");
            }

            player.AddScore(2);
        }
       

    }
}
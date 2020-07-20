using Library;

/// <summary>
/// La clase Farm representa la experiencia de la granja.
/// Hay alta cohesión porque la responsabilidad de la clase es asignar monedas a los viajeros.
/// Hay acoplamiento porque hereda de la clase abstracta Station, es decir que si Station se rompe farm lo hará también. 
/// Sin embargo es un nivel de acoplamiento aceptable para mantener la modularidad.
/// La clase cumple con poliformismo ya que implementa la operación Host y define la operación según sus necesidades.
/// Farm hereda de la clase abstracta Station, por lo tanto Farm es un tipo de Station.
/// Esta operación a su vez es implementada por Mountain, Ocean, y ThermalWaters por lo que cumple la definición de operación polimórfica 
/// de que la operación debe ser implementada por dos o más objetos de diferentes tipos.
/// </summary>

namespace Library
{
    public class Farm : Station
    {
        /// <summary>
        /// El constructor debe recibir como parámetro un int que represente la cantidad máxima de viajeros que van a poder estar en la experiencia
        /// al mismo tiempo.
        /// </summary>
        /// <param name="peopleLimit"></param>
        /// <returns></returns>
        public Farm(int peopleLimit, Step nextStep, string name = "Farm") : base(peopleLimit, nextStep, name)
        {

        }
        
        /// <summary>
        /// En el método Host en este caso se valida que el viajero que se recibe por parámetro no sea null y se le asignan 3 monedas.
        /// </summary>
        /// <param name="player"></param>
        public override void Host(Traveler player)
        {
            if (player == null)
            {
                throw new TravelerNullException("Traveler no puede ser null");
            }
            player.AddCoins(3);
        }


        

    }
}
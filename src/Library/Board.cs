using System;
using Library;
using System.Collections.Generic;

/// <summary>
/// La clase Board simula el tablero de juego.
/// Cumple con el patrón Expert porque tiene toda la información necesaria para armar el recorrido en el tablero.
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de guardar la lista de Steps.
/// La única razón de cambio de la clase es que se tenga que tenga que agregar un nuevo tipo de Step.
/// Tiene conocimiento sobre los pasos del juego, almacenando el paso inicial, el final, y una lista con el resto.
/// Hay alta cohesión porque al cumplir con SRP, la única responsabilidad de la clase es guardar tipos de Step.
/// Existe algo de acolpamiento porque los objetos que se reciben como parámetros y luego se guardan son de tipo Step.
/// Se cumple composición entre Board y Step, Board y FirstStep, y Board y EndStep siendo Board la compuesta y las demás componentes. 
/// Esto es porque se se guardan instancias de Step, FirstStep y EndStep en Board y sólo existen guardadas instancias de Step, FirstStep y EndStep en Board.
/// También hay composición entre Board y GameData siendo Board la componente y GameData la compuesta.
/// Esto es porque se se guardan instancias de Board en GameData y sólo existen guardadas instancias de Board en GameData.
/// </summary>
namespace Library
{
    public class Board
    {   
        /// <summary>
        /// Lista de objetos Step donde se guardan todos los steps que van a estar entre el FirstStep y el EndStep.
        /// </summary>
        /// <value></value>
        public List<Step> LisOfSteps { get; private set; }

        /// <summary>
        /// Objeto tipo FirstStep donde esta guardado el firststep.
        /// </summary>
        /// <value></value>
        public FirstStep FirstStep { get;  private set; }

        /// <summary>
        /// Objeto tipo EndStep donde esta guardado el endstep.
        /// </summary>
        /// <value></value>
        public EndStep EndStep { get; private set; }

        /// <summary>
        /// El constructor de la clase recibe por parámetro una lista de objetos tipo Step, un objeto tipo FirstStep, y un objeto tipo EndStep a los
        /// que luego asigna a los objetos ListOfSteps, FirstStep y EndStep.
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="firstStep"></param>
        /// <param name="endStep"></param>
        public Board(List<Step> steps, FirstStep firstStep, EndStep endStep)
        {
            this.LisOfSteps = steps;
            this.FirstStep = firstStep;
            this.EndStep = endStep;
        }
    }
}
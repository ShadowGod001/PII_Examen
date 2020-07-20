using System;
using System.Collections.Generic;

/// <summary>
/// Esta clase se encarga de representar a los travelers almacenando sus atributos ganados durante la partida.
/// Cumple con el patrón Expert porque tiene toda la información necesaria para cambiar correctamente los valores de los atributos.
/// Cumple con SRP, ya que la única responsabilidad que tiene es la de guardar los atributos. 
/// La única razón de cambio de la clase es que se tengan que cambiar los atributos de los travelers.
/// Hay alta cohesión debido al cumplimiento de SRP ya que la única responsabilidad es guardar los atributos.
/// Hay acoplamiento mínimo porque solo se trabaja con valores definidos dentro de la propia clase. 
/// Se usa agregación con GameData, Winners, TurnController y Step.
/// </summary>

namespace Library
{
    public class Traveler
    {   
        /// <summary>
        /// Constructor de la clase para ponerle un nombre al traveler.
        /// </summary>
        /// <param name="name"></param>
        public Traveler (string name = "Traveler")
        {
            this.Name = name;
        }
        /// <summary>
        /// Score es el puntaje del jugador.
        /// </summary>
        /// <value></value>
        public int Score { get; private set; }

        /// <summary>
        /// Coins es la cantidad de monedas del jugador.
        /// </summary>
        /// <value></value>
        public int Coins { get; private set; }

        /// <summary>
        /// Name es el nombre del viajero.
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }

        /// <summary>
        /// Método que añade puntuación al jugador y controla el overflow
        /// </summary>
        public int AddScore(int score)
        {   
            this.Score += score;
            if(this.Score < 0)
            {
                this.Score = int.MaxValue;
            }
            return this.Score;
        }

        /// <summary>
        /// Método que permita remover puntuación al jugador en caso de extensión.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public int RemoveScore(int score)
        {   
            this.Score -= score;
            if(this.Score < 0)
            {
                this.Score = 0;
            }
            return this.Score;
        }

        /// <summary>
        /// Método que añade monedas al jugador y controla el overflow
        /// </summary>
        public int AddCoins(int coins)
        {   
            this.Coins += coins;
            if(this.Coins < 0)
            {
                this.Coins = int.MaxValue;
            }
            return this.Coins;
        }

        /// <summary>
        /// Método que permita remover monedas al jugador en caso de extensión.
        /// </summary>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int RemoveCoins(int coins)
        {
            this.Coins -= coins;
            if(this.Coins < 0)
            {
                this.Coins = 0;
            }
            return this.Coins;
        }

      


    }
}
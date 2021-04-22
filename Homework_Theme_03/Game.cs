using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    /// <summary>
    /// Class the describes Game model
    /// </summary>
    public class Game
    {
        /// <summary>
        /// A switch between Default gameNumber (random value between 12 and 120) and userTry (impute from a player from 1 to 4)
        /// And Custom (user set value for gameNumber and userTry)
        /// </summary>
        public string GameMode { get; set; }

        /// <summary>
        /// The rules of the game, will be generated according to the number of players, game mod and difficulty
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// A list of players. For two-player mod the second player can be a Bot
        /// </summary>
        public List<Player> Players {get; set;}

        public Game(int numberOfPlayers)
        {
            Rules = "bla";
            GameMode = default;

            switch (numberOfPlayers)
            {
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }

            if (numberOfPlayers == 1)
            {

                
            }
            
            {
                
            }
            {
                GameMode = "Manual";
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework_Theme_03
{
    public class Player
    {
        /// <summary>
        /// The name of the player
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Constructor to set the values the player object
        /// </summary>
        /// <param name="playerName">The name of the player</param>
        public Player(string playerName)
        {
            this.PlayerName = playerName;
        }
    }
}

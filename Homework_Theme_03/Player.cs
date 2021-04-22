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

        ///// <summary>
        ///// Flag if the player is a bot(Computer)
        ///// </summary>
        //public bool Computer { get; set; }

        public Player(string playerName/*, bool computer*/)
        {
            this.PlayerName = playerName;
            //this.Computer = computer;
        }
    }
}

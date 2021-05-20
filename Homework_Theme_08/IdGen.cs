using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_Theme_08
{
    public class IdGen
    {
        /// <summary>
        /// Field "Id". Sequential identifier of the note to track it.
        /// </summary>
        private uint _id;

        private string _fileName = "ID.txt";

        /// <summary>
        /// Property ID.
        /// </summary>
        public uint ID {
            get => this._id;
            set => _id = value;
        } 

        /// <summary>
        /// Constructor for ID.
        /// </summary>
        public IdGen()
        {
            this._id = 1;

            //Create a file to store a diary if it doesn't exist
            if (!File.Exists(_fileName))
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (StreamWriter sw = new StreamWriter(_fileName))
                    {
                        sw.WriteLine(ID);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                using (var sr = new StreamReader(_fileName))
                {
                    this._id = uint.Parse(sr.ReadLine());
                }
            }
        }

        /// <summary>
        /// Saved the last ID into a file.
        /// </summary>
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                sw.WriteLine(ID);
            }
        }
    }
}

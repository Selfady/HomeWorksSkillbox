using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_Theme_07
{
    
    public struct Diary
    {
        #region Fields

        /// <summary>
        /// A list to store the notes.
        /// </summary>
        private List<Note> _notes;

        /// <summary>
        /// Path to the file with the Diary.
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// The number of the last added note.
        /// </summary>
        private int _lastNote;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for a Diary.
        /// </summary>
        /// <param name="Path"></param>
        public Diary(string Path)
        {
            this._path = Path;
            this._lastNote = 0;
            this._notes = new List<Note>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add a note to the diary.
        /// </summary>
        /// <param name="concreteNote">A note.</param>
        public void Add(Note concreteNote)
        {
            this._notes.Add(concreteNote);
            //Increment number of the last note.
            this._lastNote++;
        }

        /// <summary>
        /// Remove a note to the diary.
        /// </summary>
        /// <param name="concreteNote">A note.</param>
        public void Remove(Note concreteNote)
        {
            this._notes.Remove(concreteNote);
        }

        /// <summary>
        /// Saves the diary to a file.
        /// </summary>
        /// <param name="Path">Path to the file.</param>
        public void Save(string Path)
        {
            string pattern = String.Empty;
            
            foreach (var note in _notes)
            {
                pattern = $"{note.Number},{note.Summary},{note.Date},{note.Text},{note.Author},{note.Edited}";
                File.AppendAllText(Path, $"{pattern}\n");
            }
        }

        /// <summary>
        /// Prints all notes of the diary to the console.
        /// </summary>
        public void PrintDiary()
        {
            foreach (var n in this._notes)
            {
                Console.WriteLine(n.Print());
            }
        }

        /// <summary>
        /// Loads diary data.
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this._path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    _notes.Add(new Note(int.Parse(args[0]), args[1], DateTime.Parse(args[2]), args[3], args[4], bool.Parse(args[5])));
                }
            }
        }

        #endregion
    }
}

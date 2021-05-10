using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Homework_Theme_07
{
    /// <summary>
    /// Model of struct Diary
    /// </summary>
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
        private uint _lastNote;

        #endregion

        #region Fields

        /// <summary>
        /// Accessor for the number of the last added note.
        /// </summary>
        public uint LastNote { get => this._lastNote; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for a Diary.
        /// </summary>
        /// <param name="Path"></param>
        public Diary(string Path)
        {
            this._path = Path;
            this._lastNote = 1;
            this._notes = new List<Note>();
            Load();
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
        private void Remove(Note concreteNote)
        {
            this._notes.Remove(concreteNote);
        }

        /// <summary>
        /// Removes all notes with given ID
        /// </summary>
        /// <param name="iD">ID on the notes to be removed.</param>
        public void RemoveAll(int iD)
        {
            this._notes.RemoveAll(p => p.Number == iD);
        }

        /// <summary>
        /// Removes all notes with edited true/false
        /// </summary>
        /// <param name="edited">Edited flag of the note true/false.</param>
        public void RemoveAll(bool edited)
        {
            this._notes.RemoveAll(p => p.Edited == edited);
        }

        /// <summary>
        /// Removed all noted with the given date.
        /// </summary>
        /// <param name="date">The date and time when the note was taken.</param>
        public void RemoveAll(string date)
        {
            Console.WriteLine("Date in RemoveAll: " + date);
            this._notes.RemoveAll(p => p.Date == date);
        }

        /// <summary>
        /// Removes all notes with given author.
        /// </summary>
        /// <param name="author">The Author of the note.</param>
        public void RemoveAllByAuthor(string author)
        {
            this._notes.RemoveAll(p => p.Author == author);
        }

        /// <summary>
        /// Removes all notes with given summary.
        /// </summary>
        /// <param name="summary">Short summary for the note.</param>
        public void RemoveAllBySummary(string summary)
        {
            this._notes.RemoveAll(p => p.Summary == summary);
        }

        /// <summary>
        /// Removes all notes with given text..
        /// </summary>
        /// <param name="text">The text of the note.</param>
        public void RemoveAllByText(string text)
        {
            this._notes.RemoveAll(p => p.Text == text);
        }

        /// <summary>
        /// Saves the diary to a file.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public void Save()
        {
            string pattern = String.Empty;

            using (StreamWriter sw = new StreamWriter(this._path))
            {
                foreach (var note in _notes)
                {
                    pattern = $"{note.Number},{note.Summary},{note.Date},{note.Text},{note.Author},{note.Edited}";
                    sw.WriteLine(pattern);
                }
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

                    _notes.Add(new Note(uint.Parse(args[0]), args[1], args[2], args[3], args[4], bool.Parse(args[5])));
                }
            }
        }

        #endregion
    }
}

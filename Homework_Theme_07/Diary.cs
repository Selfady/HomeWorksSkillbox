using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private IdGen _lastNote;

        #endregion

        #region Fields

        ///// <summary>
        ///// Accessor for the number of the last added note.
        ///// </summary>
        public uint LastNote { get => this._lastNote.ID; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for a Diary.
        /// </summary>
        /// <param name="Path"></param>
        public Diary(string Path, IdGen IdGen)
        {
            this._path = Path;
            this._lastNote = IdGen;
            this._notes = new List<Note>();
            Load();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that returns a note with given ID.
        /// </summary>
        /// <param name="iD">Property "Number". Sequential identifier of the note to track it.</param>
        /// <returns>A note with given ID.</returns>
        public Note GetById(uint iD)
        {
            return _notes.Find(n => n.Number == iD);
        }

        /// <summary>
        /// Method to edit summary and text of a note with given ID.
        /// </summary>
        /// <param name="iD">Property "Number". Sequential identifier of the note to track it.</param>
        /// <param name="summary">Property "Summary". A summary for the note.</param>
        /// <param name="text">Property "Text". The main filed of the note that contains its text.</param>
        public void EditNoteById(uint iD, string summary, string text)
        {
            var edited = _notes.Find(n => n.Number == iD);
            if (edited.Number != iD) return;
            edited.Summary = summary;
            edited.Text = text;
            edited.Edited = true;

        }

        /// <summary>
        /// Method to edit text of a note with given ID.
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="text"></param>
        public void EditNoteTextById(uint iD, string text)
        {
            var note = _notes.Find(a => a.Number == iD);
            this._notes.Remove(note);
            note.Text = text;
            note.Edited = true;
            this._notes.Add(note);
        }

        /// <summary>
        /// Method to edit summary of a note with given ID.
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="summary"></param>
        public void EditNoteSummaryById(uint iD, string summary)
        {
            var note = _notes.Find(a => a.Number == iD);
            this._notes.Remove(note);
            note.Summary = summary;
            note.Edited = true;
            this._notes.Add(note);

        }

        /// <summary>
        /// Add a note to the diary.
        /// </summary>
        /// <param name="concreteNote">A note.</param>
        public void Add(Note concreteNote)
        {
            this._notes.Add(concreteNote);
            //Increment number of the last note.
            this._lastNote.ID++;
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
        public void RemoveAll(DateTime date)
        {
            //TODO: I have no clue how to compare DateTime objects in LINQ, so i remove them as strings... 
            this._notes.RemoveAll(p => Convert.ToString(p.Date) == Convert.ToString(date));
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
            //Removing notes with empty summary if user enters whitespace.
            if (string.IsNullOrEmpty(summary) || string.IsNullOrWhiteSpace(summary))
            {
                this._notes.RemoveAll(p => p.Summary == "");
            }
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
            _lastNote.Save();
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
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this._path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    _notes.Add(new Note(uint.Parse(args[0]), args[1], DateTime.Parse(args[2]), args[3], args[4], bool.Parse(args[5])));
                }
            }
        }

        /// <summary>
        /// Method to load notes from file that are withoin given timerange.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void LoadByTimeRange(string start, string end)
        {
            this._notes.Clear();
            using (StreamReader sr = new StreamReader(this._path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    if (DateTime.Parse(args[2]) >= DateTime.Parse(start) && DateTime.Parse(args[2]) <= DateTime.Parse(end))
                    {
                        _notes.Add(new Note(uint.Parse(args[0]), args[1], DateTime.Parse(args[2]), args[3], args[4], bool.Parse(args[5])));
                    }
                }
            }
        }

        /// <summary>
        /// Method to sort diary by note ID.
        /// </summary>
        public void SortById()
        {
            this._notes.Sort((x, y) =>
                x.Number.CompareTo(y.Number));
        }

        /// <summary>
        /// Method to sort diary by note summary.
        /// </summary>
        public void SortBySummary()
        {
            this._notes.Sort((x, y) =>
                string.Compare(x.Summary, y.Summary, StringComparison.Ordinal));
        }

        /// <summary>
        /// Method to sort diary by note Date and Time.
        /// </summary>
        public void SortByDateTime()
        {
            this._notes.Sort((x, y) =>
                x.Date.CompareTo(y.Date));
        }

        /// <summary>
        /// Method to sort diary by note text.
        /// </summary>
        public void SortByText()
        {
            this._notes.Sort((x, y) =>
                string.Compare(x.Text, y.Text, StringComparison.Ordinal));
        }

        /// <summary>
        /// Method to sort diary by author.
        /// </summary>
        public void SortByAuthor()
        {
            this._notes.Sort((x, y) =>
                string.Compare(x.Author, y.Author, StringComparison.Ordinal));
        }

        /// <summary>
        /// Method to sort diary by flag edited.
        /// </summary>
        public void SortByModified()
        {
            this._notes.Sort((x, y) =>
                x.Edited.CompareTo(y.Edited));
        }

        #endregion
    }
}

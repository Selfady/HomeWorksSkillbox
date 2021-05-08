using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_07
{
    public struct Note
    {
        #region Fields

        /// <summary>
        /// Field "Number". Sequential identifier of the note to track it.
        /// </summary>
        private int _number;

        /// <summary>
        /// Field "Edited". A flag that shows that a note was edited after its creation.
        /// </summary>
        private bool _edited;

        /// <summary>
        /// Field "Date". The date and time of the note.
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Field "Summary". A summary for the note.
        /// </summary>
        private string _summary;

        /// <summary>
        /// Field "Text". The main filed of the note that contains its text.
        /// </summary>
        private string _text;

        /// <summary>
        /// Field "Author". The author of the note.
        /// </summary>
        private string _author;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The number of the Note. Cannot be set after the note was created.
        /// </summary>
        public int Number 
        { 
            get => this._number;
            set => _number = value;
        }

        /// <summary>
        /// A flag to show if the note was modified.
        /// </summary>
        public bool Edited
        {
            get => this._edited;
            set => _edited = value;
        }

        /// <summary>
        /// Short summary for the note.
        /// </summary>
        public string Summary
        {
            get => this._summary;
            set => _summary = value;
        }

        /// <summary>
        /// The text of the note.
        /// </summary>
        public string Text
        {
            get => this._text;
            set => _text = value;
        }

        /// <summary>
        /// The Author of the note.
        /// </summary>
        public string Author
        {
            get => this._author;
            set => _author = value;
        }

        /// <summary>
        /// The date and time when the note was taken.
        /// </summary>
        public DateTime Date
        {
            get => this._date;
            set => _date = value;
        }

        #endregion Properties

        #region Methods
        /// <summary>
        /// Prints the note number, date, text and author.
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            var pattern = $"\n#{this._number} {this.Summary}\nDate: {this._date}\nText: {this._text}\nAuthor: {this._author}";

            if (_edited)
            {
                return pattern + "\nSomeone modified the note!";
            }
            return pattern;
        }

        #endregion Methods

        #region Constructors

        /// <summary>
        /// Constructor for a Note.
        /// </summary>
        /// <param name="Number">Number of the note.</param>
        /// <param name="Summary">Short summary for the note.</param>
        /// <param name="Date">The date and time of the note.</param>
        /// <param name="Text">The text of the note.</param>
        /// <param name="Author">The author of the note.</param>
        /// <param name="Edited">A flag that shows that a note was edited after its creation.</param>
        public Note(int Number, string Summary, DateTime Date, string Text, string Author, bool Edited)
        {
            this._number = Number;
            this._summary = Summary;
            this._date = Date;
            this._text = Text;
            this._author = Author;
            this._edited = Edited;
        }

        /// <summary>
        /// Constructor for a Note.
        /// </summary>
        /// <param name="Number">Number of the note.</param>
        /// <param name="Text">Text of the note.</param>
        public Note(int Number, string Text)
        {
            this._number = Number;
            this._summary = String.Empty;
            this._date = DateTime.Now;
            this._text = Text;
            this._author = WindowsIdentity.GetCurrent().Name;
            this._edited = false;
        }

        #endregion Constructors
    }
}

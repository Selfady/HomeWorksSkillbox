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
        private Note[] notes;

        /// <summary>
        /// Path to the file with the Diary.
        /// </summary>
        private string path;

        /// <summary>
        /// The number of the last added note.
        /// </summary>
        int lastNote;
        
        #endregion

        #region Constructor

        //public Diary(string Path)
        //{
        //    this.path = Path;
        //}
        #endregion
    }
}

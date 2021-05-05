using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_06
{
    /// <summary>
    /// A class to work with files.
    /// </summary>
    class Files
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void GenerateFile(string path)
        {
            File.Create(path);
        }
    }
}

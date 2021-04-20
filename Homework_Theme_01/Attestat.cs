using System;
using System.CodeDom;

namespace Homework_Theme_01
{
    /// <summary>
    /// Класс, описывающий имодель баллов пользователя
    /// </summary>
    public class Attestat
    {
        /// <summary>
        /// Russian language score
        /// </summary>
        public byte RussianLanguage { get; set; }

        /// <summary>
        /// History score
        /// </summary>
        public byte History { get; set; }

        /// <summary>
        /// Mathematics score
        /// </summary>
        public byte Mathematics { get; set; }

        /// <summary>
        /// Конструктор, позволяющий присвоить значение баллов
        /// </summary>
        /// <param name="RussianLanguage">Russian Language score</param>
        /// <param name="History">History score</param>
        /// <param name="Mathematics">Mathematics score</param>
        public Attestat(byte RussianLanguage, byte History, byte Mathematics)
        {
            this.RussianLanguage = RussianLanguage; // Saves set RussianLanguage score
            this.History = History; // Saves set History score
            this.Mathematics = Mathematics; // Saves set Mathematics score
        }

        /// <summary>
        /// Организация вывода информации о баллах
        /// </summary>
        /// <returns>Строковое представление информации</returns>
        public override string ToString()
        {
            return
                //returns interpolated string
                $"{RussianLanguage,7} {History,7} {Mathematics,10}";
        }
    }
}
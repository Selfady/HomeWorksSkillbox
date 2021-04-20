using System;
using System.ComponentModel.Design.Serialization;

namespace Homework_Theme_01
{   
    /// <summary>
    /// Класс, описывающий модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The age of the worker
        /// </summary>
        public ushort Age { get; set; }

        /// <summary>
        /// The height of the worker
        /// </summary>
        public ushort Height { get; set; }

        /// <summary>
        /// The Scores of the user
        /// </summary>
        public Attestat Attestat { get; set; }

        /// <summary>
        /// Конструктор, позволяющий присвоить значение соответствующим полям пользвателя
        /// </summary>
        /// <param name="Name">user name</param>
        /// <param name="Age">user age</param>
        /// <param name="Height">user height</param>
        /// <param name="Score">user scores</param>
        public User(string Name, ushort Age, ushort Height, Attestat Attestat)
        {
            this.Name = Name; // Сохранить переданное значение имени
            this.Age = Age;   // Сохранить переданное значение фамилии
            this.Height = Height;             // Сохранить переданное значение возраста
            this.Attestat = Attestat;       // Сохранить переданное значение Баллов
        }

        /// <summary>
        /// Returns average score for the user
        /// </summary>
        public string AverageScore()
        {
            //Cast one of the scores to float to save fraction
            float rus = Attestat.RussianLanguage;
            //Calculation the average
            float average = (rus + Attestat.History + Attestat.Mathematics) / 3;
            //return string with 2 digits after separator
            return average.ToString("#.##");
        }

        /// <summary>
        /// Организация вывода информации о пользователе
        /// </summary>
        /// <returns>Строковое представление информации</returns>
        public override string ToString()
        {
            return $"{Name,20} {Age,20} {Height,20} {Attestat,17}";
        }


    }
}



namespace Homework_Theme_01
{   
    /// <summary>
    /// Класс, описывающий имодель пользователя
    /// </summary>
    class User
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
        /// Конструктор, позволяющий присвоить значение соответствующим полям пользвателя
        /// </summary>
        /// <param name="Name">user name</param>
        /// <param name="Age">user age</param>
        /// <param name="Height">user height</param>
        public User(string Name, ushort Age, ushort Height)
        {
            this.Name = Name; // Сохранить переданное значение имени
            this.Age = Age;   // Сохранить переданное значение фамилии
            this.Height = Height;             // Сохранить переданное значение возраста
            //this.Score = new Score;       // Сохранить переданное значение зарплаты
        }

        public override string ToString()
        {
            return $"Имя {Name,15} Возраст {Age} Рост {Height}";
        }


    }
}



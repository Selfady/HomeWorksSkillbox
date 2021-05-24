namespace Homework_Theme_08
{
    /// <summary>
    /// Structure for an employee.
    /// </summary>
    public struct Employee
    {
        #region Fields

        /// <summary>
        /// Field "ID". Unique ID of the employee.
        /// </summary>
        private uint _id;

        /// <summary>
        /// Field "Name". The name of the employee.
        /// </summary>
        private string _name;

        /// <summary>
        /// Filed "Surname". The surname of the employee.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Field "Age". The age of the employee.
        /// </summary>
        private byte _age;

        /// <summary>
        /// Field "Salary". The salary of the employee.
        /// </summary>
        private uint _salary;

        /// <summary>
        /// Field "Department". A department the employee works for at the moment.
        /// </summary>
        private string _department;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The ID of the employee.
        /// </summary>
        public uint Id
        {
            get => this._id;
            set => _id = value;
        }

        /// <summary>
        /// The name of the employee.
        /// </summary>
        public string Name
        {
            get => this._name;
            set => _name = value;
        }


        /// <summary>
        /// The surname of the employee.
        /// </summary>
        public string Surname
        {
            get => this._surname;
            set => _surname = value;
        }

        /// <summary>
        /// The age of the employee.
        /// </summary>
        public byte Age  
        {
            get => this._age;
            set => _age = value;
        }
    
        /// <summary>
        /// The salary of the employee.
        /// </summary>
        public uint Salary
        {
            get => this._salary;
            set => _salary = value;
        }

        /// <summary>
        /// A department the employee works for at the moment.
        /// </summary>
        public string Department
        {
            get => this._department;
            set => _department = value;
        }

        #endregion Properties

        #region Methods
        /// <summary>
        /// Puts all properties of the employee to a string.
        /// </summary>
        /// <returns>All properties in a string.</returns>
        public override string ToString()
        {
            var pattern = $"\nEmployee ID: {this.Id}" +
                          $"\nFull Name: {this.Name} {this.Surname}" +
                          $"\nAge: {this.Age}" +
                          $"\nSalary: {this.Salary}" +
                          $"\nDepartment: {this.Department}";
            return pattern;
        }

        #endregion Methods

        #region Constructors

        /// <summary>
        /// Constructor for employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="surname">The surname of the employee.</param>
        /// <param name="age">The age of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        /// <param name="department">A department the employee works for at the moment.</param>
        
        public Employee(uint id, string name, string surname, byte age, uint salary, string department)
        {
            this._id = id;
            this._name = name;
            this._surname = surname;
            this._age = age;
            this._salary = salary;
            this._department = department;
        }

        #endregion Constructor
    }
}

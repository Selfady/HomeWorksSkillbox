using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Homework_Theme_08
{
    struct Department
    {
        #region Fields

        /// <summary>
        /// Field "Name" of the department.
        /// </summary>
        private string _name;

        
        /// <summary>
        /// Feild "Date". Department creation date.
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Field "Employees". A list of employees of the department.
        /// </summary>
        private List<Employee> _employees;

        /// <summary>
        /// Field "Departments". A list of sub-departments of the department.
        /// </summary>
        private List<Department> _subDepartments;
        
        #endregion Fields

        #region Propeties

        /// <summary>
        /// The name of the department.
        /// </summary>
        public string Name
        {
            get => this.Name;
            set => this._name = value;
        }

        /// <summary>
        /// Department creation date.
        /// </summary>
        public DateTime Date
        {
            get => this._date;
            set => this._date = value;
        }

        /// <summary>
        /// List of employees.
        /// </summary>
        public List<Employee> Employees
        {
            get => this._employees;
            set => this._employees = value;
        }

        public List<Department> SubDepartments
        {
            get => this._subDepartments;
            set => this._subDepartments = value;
        }

        #endregion Propeties

        #region Methods

        /// <summary>
        /// Add concrete employee to the department.
        /// </summary>
        /// <param name="employee">Concrete employee.</param>
        public void AddEmployee(Employee employee)
        {
            this._employees.Add(employee);
        }

        /// <summary>
        /// Add concrete sub-department to the department.
        /// </summary>
        /// <param name="subDepartment"></param>
        public void AddSubDepartment(Department subDepartment)
        {
            this._subDepartments.Add(subDepartment);
        }


        /// <summary>
        /// String representation of the Department.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var pattern = $"\nID: {this.Name}" + 
                          $"\nCreation date: {this.Date}" +
                          $"\nEmployees:";
            foreach (var e in Employees)
            {
                pattern += $"\n{e.Id}";
            }

            pattern += "Departments:";
            foreach (var d in SubDepartments)
            {
                pattern += $"\n{d.Name}";
            }

            return pattern;
        }

        #endregion Methods

        #region Constructor

        /// <summary>
        /// Constructor for a department.
        /// </summary>
        /// <param name="name"></param>
        public Department(string name)
        {
            this._name = name;
            this._date = DateTime.Today;
            this._employees = new List<Employee>();
            this._subDepartments = new List<Department>();
        }

        #endregion Constructor

    }
}

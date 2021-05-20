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
        /// Field "SubDepartments". A list of sub-departments of the department.
        /// </summary>
        private List<Department> _departments;

        /// <summary>
        /// Field "Name" of the Parent department.
        /// </summary>
        private string _parent;

        /// <summary>
        /// Field "Size". The size of the department.
        /// </summary>
        private uint _size;

        /// <summary>
        /// Field "NumberOfEmployees". The number of employees in the department.
        /// </summary>
        private uint _numberOfEmployees;

        
        #endregion Fields

        #region Propeties

        /// <summary>
        /// The name of the department.
        /// </summary>
        public string Name
        {
            get => this._name;
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

        /// <summary>
        /// List of sub-departments.
        /// </summary>
        public List<Department> Departments
        {
            get => this._departments;
            set => this._departments = value;
        }

        /// <summary>
        /// The name of the parent.
        /// </summary>
        public string Parent
        {
            get => this._parent;
            set => this._parent = value;
        }

        /// <summary>
        /// Approved size of the department.
        /// </summary>
        public uint Size
        {
            get => this._size;
            set => this._size = value;
        }

        /// <summary>
        /// Current number of employees in the department.
        /// </summary>
        public uint NumberOfEmployees
        {
            get => this._numberOfEmployees;
            set => this._numberOfEmployees = value;
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
        /// Returns an enployee with given ID.
        /// </summary>
        /// <param name="id">ID of an employee.</param>
        /// <returns></returns>
        public Employee GetEmployeeById(uint id)
        {
            var employee = this.Employees.Find(e => e.Id == id);
            return employee;
        }
        
        /// <summary>
        /// String representation of the Department.
        /// </summary>
        /// <returns>String representation of the department.</returns>
        public override string ToString()
        {
            var pattern = $"\nDepartment name: {this.Name}" + 
                          $"\nCreation date: {this.Date}" +
                          $"\nParent: {this.Parent}" +
                          $"\nWork positions: {this.Size}" + 
                          $"\nNumber of employees: {this.NumberOfEmployees}";

            foreach (var e in Employees)
            {
                pattern += $"\n{e.ToString()}";
            }

            foreach (var sd in Departments)
            {
                pattern += $"\n{sd.ToStringSubDepartment(sd)}";
            }

            return pattern;
        }

        /// <summary>
        /// Method that returns string representation of sub-department data.
        /// </summary>
        /// <param name="sebDep"></param>
        /// <returns>String representation of sub-department.</returns>
        public string ToStringSubDepartment(Department sebDep)
        {
            var pattern = $"\nSub-department Name: {this.Name}" +
                          $"\nCreation date: {this.Date}" +
                          $"\nParent: {this.Parent}" +
                          $"\nWork positions: {this.Size}" +
                          $"\nNumber of employees: {this.NumberOfEmployees}";


            foreach (var e in Employees)
            {
                pattern += $"\n{e.ToString()}";
            }

            foreach (var sd in Departments)
            {
                pattern += $"\n{sd.ToStringSubDepartment(sd)}";
            }

            return pattern;
        }


        #endregion Methods

        #region Constructor

        /// <summary>
        /// Constructor for a department.
        /// </summary>
        /// <param name="name">Field "Name" of the department.</param>
        public Department(string name)
        {
            this._name = name;
            this._date = DateTime.Now;
            this._employees = new List<Employee>();
            this._departments = new List<Department>();
            this._parent = null;
            this._size = default;
            this._numberOfEmployees = default;

        }

        /// <summary>
        /// Constructor for a department that sets parent name.
        /// </summary>
        /// <param name="name">Field "Name" of the department.</param>
        /// <param name="parent">Field "Name" of the Parent department.</param>
        public Department(string name, string parent)
        {
            this._name = name;
            this._date = DateTime.Now;
            this._employees = new List<Employee>();
            this._departments = new List<Department>();
            this._parent = parent;
            this._size = default;
            this._numberOfEmployees = default;
        }

        #endregion Constructor

    }
}

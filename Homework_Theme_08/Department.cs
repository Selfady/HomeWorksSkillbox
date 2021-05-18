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
        private List<Department> _subDepartments;

        /// <summary>
        /// Field "Name" of the Parent department.
        /// </summary>
        private string _parent;

        /// <summary>
        /// Field "Size". The size of the department.
        /// </summary>
        private uint _size;
        
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
        public List<Department> SubDepartments
        {
            get => this._subDepartments;
            set => this._subDepartments = value;
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
        /// String representation of the Department.
        /// </summary>
        /// <returns>String representation of the department.</returns>
        public override string ToString()
        {
            var pattern = $"\nDepartment name: {this.Name}" + 
                          $"\nCreation date: {this.Date}" +
                          $"\nParent: {this.Parent}" +
                          $"\nWork positions: {this.Size}";

            foreach (var e in Employees)
            {
                pattern += $"\n{e.ToString()}";
            }

            foreach (var sd in SubDepartments)
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
                          $"\nWork positions: {this.Size}";


            foreach (var e in Employees)
            {
                pattern += $"\n{e.ToString()}";
            }

            foreach (var sd in SubDepartments)
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
            this._subDepartments = new List<Department>();
            this._parent = null;
            this._size = default;

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
            this._subDepartments = new List<Department>();
            this._parent = parent;
            this._size = default;
        }

        #endregion Constructor

    }
}

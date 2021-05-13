using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_08
{
    class Company
    {
        /// <summary>
        /// Unique employee generator for a company.
        /// </summary>
        private IdGen _idGen;

        /// <summary>
        /// Company Name.
        /// </summary>
        private string _name;

        /// <summary>
        /// Field "Departments". A list of departments for the company.
        /// </summary>
        private List<Department> _departments;

        /// <summary>
        /// Company name.
        /// </summary>
        public string Name { get => this._name;
            set => this._name = value; }

        /// <summary>
        /// Departments of the company.
        /// </summary>
        public List<Department> Departments
        {
            get => this._departments;
            set => this._departments = value;
        }

        /// <summary>
        /// IdGen for the company.
        /// </summary>
        public IdGen IdGen
        {
            get => this._idGen;
            set => this._idGen = value;
        }

        /// <summary>
        /// Adds a department to the company.
        /// </summary>
        /// <param name="department"></param>
        public void Add(Department department)
        {
            this._departments.Add(department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToStringBlya()
        {
            var pattern = $"\nCompany name: {this.Name}" +
                          $"\nDepartments:";

            foreach (var d in Departments)
            {
                pattern += $"\n{d.Name}";
            }

            return pattern;
        }

        /// <summary>
        /// Constructor for company.
        /// </summary>
        /// <param name="name"></param>
        public Company(string name)
        {
            this._name = name;
            this._idGen = new IdGen();
            this._departments = new List<Department>();
        }

    }
}

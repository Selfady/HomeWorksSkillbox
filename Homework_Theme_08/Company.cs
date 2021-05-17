using System;
using System.Collections.Generic;
using System.IO.Enumeration;
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
        public void AddDepartment(Department department)
        {
            this.Departments.Add(department);
        }

        /// <summary>
        /// Adds a department by name to the company.
        /// </summary>
        /// <param name="name">Name of the new department.</param>
        public void AddDepartment(string name)
        {
            AddDepartment(new Department(name, Name));
        }

        /// <summary>
        /// Removes a department by given name.
        /// </summary>
        /// <param name="name">Name of a department to remove.</param>
        public void RemoveDepartment(string name)
        {
            Departments.Remove(FindDepartment(name));
        }
        
        /// <summary>
        /// Finds a department in company by department name.
        /// </summary>
        /// <param name="departmentName">The name of the department.</param>
        /// <returns>Department.</returns>
        public Department FindDepartment(string departmentName)
        {
            var department = this.Departments.Find(d => d.Name == departmentName);
            return department;
        }

        /// <summary>
        /// Finds sub-department in the given department by sub-department name.
        /// </summary>
        /// <param name="subDepartmentName">The name of the sub-department.</param>
        /// <param name="parentDepartment">Department we are searching in.</param>
        /// <returns>Department.</returns>
        public Department FindSubDepartment(string subDepartmentName, Department parentDepartment)
        {
            var parent = this.Departments.Find(d => d
                .Name == parentDepartment.Name);
            var target = parent.SubDepartments.Find(t => t.Name == subDepartmentName);
            return target;
        }

        /// <summary>
        /// Method to edit department property Name.
        /// </summary>
        /// <param name="name">Name of a department to edit.</param>
        /// <param name="newName">New name for the department.</param>
        public void ChangeDepartmentName(string name, string newName)
        {
            var edit = Departments.Find(d => d.Name == name);
            int index = Departments.FindIndex(a => a.Name == edit.Name);
            edit.Name = newName;
            Departments[index] = edit;
        }

        /// <summary>
        /// Method to edit department property Size.
        /// </summary>
        /// <param name="name">Name of a department to edit.</param>
        /// <param name="newSize">New size for the department.</param>
        public void ChangeDepartmentSize(string name, uint newSize)
        {
            var edit = Departments.Find(d => d.Name == name);
            int index = Departments.FindIndex(a => a.Name == edit.Name);
            edit.Size = newSize;
            Departments[index] = edit;
        }

        /// <summary>
        /// String representation of a company.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var pattern = $"\nCompany name: {this.Name}";

            foreach (var d in Departments)
            {
                pattern += $"\n{d.ToString()}";
                
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

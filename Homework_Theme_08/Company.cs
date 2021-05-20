using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_08
{
    class Company
    {
        #region Fields

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

        #endregion Fields

        #region Propeties

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

        #endregion Propeties

        #region Methods

        /// <summary>
        /// Returns sub-tree of departments under given root.
        /// Magic from stack overflow no one explained and was not even going to any soon.
        /// </summary>
        /// <param name="root">Department to find descendants of.</param>
        /// <returns>Departments.</returns>
        public static IEnumerable<Department> Descendants(List<Department> root)
        {
            var nodes = new Stack<Department>();
            foreach (var d in root)
            {
                nodes.Push(d);
            }
            while (nodes.Any())
            {
                Department node = nodes.Pop();
                yield return node;
                foreach (var n in node.Departments) nodes.Push(n);
            }
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
            //Adding new parent with constructor that allows setting the name of the parent department.
            AddDepartment(new Department(name, Name));
        }

        /// <summary>
        /// Add a sub-department with given name.
        /// </summary>
        /// <param name="name">A name for sub-department.</param>
        public void AddDepartment(string parentName, string subDepartmentName)
        {
            var parent = Company.Descendants(Departments).FirstOrDefault(d => d.Name == parentName);

            //Adding new parent with constructor that allows setting the name of the parent department.
            if (parent.Name != null)
            {
                parent.Departments.Add(new Department(subDepartmentName, parent.Name));
            }
            else
            {
                Console.WriteLine("We did not find a department with name {0}", parentName);
                throw new Exception("AddDepartment cannot add to null");
            }
        }

        /// <summary>
        /// Removes a department by given name.
        /// </summary>
        /// <param name="name">Name of a department to remove.</param>
        public void RemoveDepartment(string name)
        {
            var extra = Company.Descendants(Departments).FirstOrDefault(d => d.Name == name);
            if (Departments.Contains(extra))
            {
                Departments.Remove(extra);
            }
            else
            {
                var parentName = extra.Parent;
                var parent = Company.Descendants(Departments).FirstOrDefault(d => d.Name == parentName);
                if (parent.Name != null)
                {
                    parent.Departments.Remove(extra);
                }
                else
                {
                    Console.WriteLine("We did not find a department with name {0}",name);
                    throw new Exception("RemoveDepartment cannot remove null");
                }
            }
        }

        /// <summary>
        /// Method to edit department property Name.
        /// </summary>
        /// <param name="currentName">Name of a department to edit.</param>
        /// <param name="newName">New name for the department.</param>
        public void ChangeDepartmentName(string currentName, string newName)
        {
            var edit = Company.Descendants(Departments).FirstOrDefault(d => d.Name == currentName);
            int indexOfEdit = default;

            //check if the department within company.
            if (this.Departments.Contains(edit))
            {
                indexOfEdit = this.Departments.FindIndex(a => a.Name == edit.Name);

                #region Updating parent field of children

                var children = new Queue<Department>(Company.Descendants(edit.Departments));
                while (children.Any())
                {
                    var child = children.Dequeue();
                    if (child.Parent != edit.Name) continue;
                    var indexOfChild = edit.Departments.IndexOf(child);
                    child.Parent = newName;
                    edit.Departments[indexOfChild] = child;
                }

                #endregion Updating parent field of children
                
                //Renamed the root department
                edit.Name = newName;
                Departments[indexOfEdit] = edit;
            }
            //check if the department is a sub-department.
            else
            {
                var parent = Company.Descendants(Departments).FirstOrDefault(d => d.Name == edit.Parent);

                if (parent.Name != null && parent.Departments.Any())
                {
                    indexOfEdit = parent.Departments.FindIndex(a => a.Name == edit.Name);

                    #region Updating parent field of children

                    var children = new Queue<Department>(Company.Descendants(edit.Departments));
                    while (children.Any())
                    {
                        var child = children.Dequeue();
                        if (child.Parent != edit.Name) continue;
                        var indexOfChild = edit.Departments.IndexOf(child);
                        child.Parent = newName;
                        edit.Departments[indexOfChild] = child;
                    }

                    #endregion Updating parent field of children

                    edit.Name = newName;
                    parent.Departments[indexOfEdit] = edit;
                }
                else
                {
                    Console.WriteLine("We did not find a department with name {0}", currentName);
                    throw new Exception("ChangeDepartmentName cannot update null");
                }

            }
        }

        /// <summary>
        /// Method to edit department property Size.
        /// </summary>
        /// <param name="name">Name of a department to edit.</param>
        /// <param name="newSize">New size for the department.</param>
        public void ChangeDepartment(string name, uint newSize)
        {
            var edit = Company.Descendants(Departments).FirstOrDefault(d => d.Name == name);
            int indexOfEdit = default;

            //check if the department within company.
            if (this.Departments.Contains(edit))
            {
                indexOfEdit = Departments.FindIndex(a => a.Name == edit.Name);
                edit.Size = newSize;
                Departments[indexOfEdit] = edit;
            }
            //check if the department is a sub-department.
            else
            {
                var parent = Company.Descendants(Departments).FirstOrDefault(d => d.Name == edit.Parent);
                if (parent.Name != null && parent.Departments.Any())
                {
                    indexOfEdit = parent.Departments.FindIndex(a => a.Name == edit.Name);
                    edit.Size = newSize;
                    parent.Departments[indexOfEdit] = edit;
                }
                else
                {
                    Console.WriteLine("We did not find a department with name {0}", name);
                    throw new Exception("ChangeDepartment cannot update null");
                }
                
            }
        }

        /// <summary>
        /// Method to add employee into a department with given name
        /// </summary>
        /// <param name="toDepartmentName">Department name.</param>
        /// <param name="employee">Struct employee.</param>
        public void AddEmployee(string toDepartmentName, Employee employee)
        {
            Department addInTo = Company.Descendants(Departments).FirstOrDefault(d => d.Name == toDepartmentName);
            addInTo.Employees.Add(employee);
            IdGen.ID++;
        }

        /// <summary>
        /// Method to add employee into a department with given name
        /// </summary>
        /// <param name="toDepartmentName">Department name.</param>
        /// <param name="employeeName">Employee name.</param>
        public void AddEmployee(string toDepartmentName, string employeeName)
        {
            Department addInTo = Company.Descendants(Departments).FirstOrDefault(d => d.Name == toDepartmentName);
            addInTo.Employees.Add(new Employee(IdGen.ID, employeeName, String.Empty, 0, 0, addInTo.Name));
            IdGen.ID++;
        }

        /// <summary>
        /// Method to edit properties of an employee.
        /// </summary>
        /// <param name="id">ID of the employee.</param>
        /// <param name="newName">New name for the employee.</param>
        public void EditEmployee(uint id, string newName)
        {
            var parentDepartment = Company.Descendants(Departments).FirstOrDefault(d => d.GetEmployeeById(id).Id == id);
            var employeeToEdit = parentDepartment.GetEmployeeById(id);

            var indexOfEmployeeToEdit = parentDepartment.Employees.IndexOf(employeeToEdit);
            employeeToEdit.Name = newName;
            parentDepartment.Employees[indexOfEmployeeToEdit] = employeeToEdit;
        }

        /// <summary>
        /// Method to remove an employee with given ID.
        /// </summary>
        /// <param name="id">ID of the an employee.</param>
        public void RemoveEmployee(uint id)
        {
            var parentDepartment = Company.Descendants(Departments).FirstOrDefault(d => d.GetEmployeeById(id).Id == id);
            parentDepartment.Employees.Remove(parentDepartment.GetEmployeeById(id));
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

        #endregion Methods

        #region Constructor

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

        #endregion Constructor

    }
}

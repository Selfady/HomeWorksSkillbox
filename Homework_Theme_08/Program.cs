using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Homework_Theme_08
{
    /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
    /// В структуре присутствуют департаменты и сотрудники
    /// Каждый департамент может содержать не более 1_000_000 сотрудников.
    /// У каждого департамента есть поля: наименование, дата создания,
    /// количество сотрудников числящихся в нём 
    /// (можно добавить свои пожелания)
    /// 
    /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
    /// уникальный номер, размер оплаты труда, количество закрепленным за ним.
    ///
    /// В данной информаиционной системе должна быть возможность 
    /// - импорта и экспорта всей информации в xml и json
    /// Добавление, удаление, редактирование сотрудников и департаментов
    /// 
    /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
    /// по нескольким полям, например возрасту и оплате труда
    /// 
    ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
    ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
    ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
    ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
    ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
    ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
    ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
    ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
    ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
    ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
    /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
    /// 
    /// 
    /// Упорядочивание по одному полю возраст
    /// 
    ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
    ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
    /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
    ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
    ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
    ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
    ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
    ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
    ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
    ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
    ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
    /// 
    ///
    /// Упорядочивание по полям возраст и оплате труда
    /// 
    ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
    /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
    ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
    ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
    ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
    ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
    ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
    ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
    ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
    ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
    ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
    /// 
    /// 
    /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
    /// 
    ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
    ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
    ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
    ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
    ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
    ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
    ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
    ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
    /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
    ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
    ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
    /// 
    class Program
    {
        static void Main(string[] args)
        {

            //BUG when an employee is addded department property number of employees is not updated.
            //TODO iplement error handling for add/edit and remove employee methods.
            //TODO do not let the user add more than 1_000_000 employees to a department.
            //TODO get only date portion of creation date and time.
            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_08 8.6 Homework\"");

            //Creating company object from existing file.
            var company = LoadJson();

            if (company != null)
            {
                MainMenu(company);
            }
            else
            {
                Console.WriteLine("Before we begin:" +
                                  "\nPress 1 to create a new company." +
                                  "\nPress 2 to load test data.");
                var choice = MakeHimChoose(1, 2);
                if (choice == 1)
                {
                    MainMenu(company);
                }
                else
                {
                    //Create new test company.
                    #region addTestData
                    company = new Company("Test");

                    //Add first 3 departments to the company
                    string first = "First Department";
                    string second = "Second Department";
                    string third = "Third Department";
                    string toDelete = "To test deletion";

                    company.AddDepartment(first);
                    company.AddDepartment(second);
                    company.AddDepartment(third);
                    company.AddDepartment(toDelete);


                    //Add a sub-department to the first department
                    company.AddDepartment(first, "sub-dep for first dep");

                    ////add sub-department to the sub-department.
                    company.AddDepartment("sub-dep for first dep", "sub-sub-sub for 1st");
                    company.AddDepartment("sub-dep for first dep", "2nd sub-sub-sub for 1st");
                    company.AddDepartment("sub-sub-sub for 1st", "DNO");
                    company.AddDepartment("DNO", "DNO2");
                    company.AddDepartment(third, "Sub-dep for Third Dep");

                    //This is how assignment of new fields works
                    string secSubDep = "Second sub-dep";
                    company.AddDepartment(second, secSubDep);

                    //string newSecond = "Pretty name for second sub-department";
                    string newValue = "Changed name";
                    company.ChangeDepartmentName("sub-dep for first dep", newValue);
                    company.ChangeDepartment(newValue, 256);

                    //Departments to test deletion
                    company.AddDepartment(toDelete, "subtree to test deletion");

                    //Remove a department works this way
                    company.RemoveDepartment(toDelete);

                    //Add an employee
                    var firstEmployeeName = "fiest employee Name";
                    var secondEmployeeName = "second employee 2Name";
                    var firstEmployee = new Employee(company.IdGen.ID, firstEmployeeName, "Surname", 100, 10000, "no clue");
                    var secondEmployee = new Employee(company.IdGen.ID, secondEmployeeName, "2Surname", 200, 20000, "no clue");


                    company.AddEmployee(first, firstEmployeeName);
                    company.AddEmployee(secSubDep, secondEmployeeName);

                    var thirdEmployee = new Employee(company.IdGen.ID++, "third employee", "3Surname", 250, 30000, "no clue");
                    company.AddEmployee("DNO2", thirdEmployee);

                    //Edit employee
                    company.EditEmployee(1, "ChangedNameofSecond Employeee");

                    //Remove employee
                    var removedEmployeeName = "Will be removed";
                    company.AddEmployee(first, removedEmployeeName);
                    company.RemoveEmployee(5);

                    //Sort list od employees
                    string sortestingDepName = "To Test Sort";
                    company.AddDepartment(sortestingDepName);
                    var employee1 = new Employee(11, "Zame", "1Surname", 33, 10, "xz");
                    var employee2 = new Employee(12, "Aame", "2Surname", 50, 120, "xz");
                    var employee3 = new Employee(13, "Name", "3Surname", 13, 300, "xz");
                    var employee4 = new Employee(14, "Fame", "4Surname", 24, 40, "xz");
                    var employee5 = new Employee(15, "Fame", "5Surname", 14, 40, "xz");


                    company.AddEmployee(sortestingDepName, employee1);
                    company.AddEmployee(sortestingDepName, employee2);
                    company.AddEmployee(sortestingDepName, employee3);
                    company.AddEmployee(sortestingDepName, employee4);
                    company.AddEmployee(sortestingDepName, employee5);
                    #endregion addTestData
                    MainMenu(company);
                }
            }

            Console.ReadKey();
        }

       /// <summary>
       /// Saves company data to a file.
       /// </summary>
       /// <param name="company">Object company.</param>
        static void SaveJson(Company company)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize<Company>(company, options);

            //write string to file
            File.WriteAllText("company.json", json);
        }

        /// <summary>
        /// Loads company date from a file.
        /// </summary>
        /// <returns>Object company.</returns>
        static Company LoadJson()
        {
           if (!File.Exists("company.json"))
           {
               return null;
           }
           var file = File.ReadAllText("company.json");
           return JsonSerializer.Deserialize<Company>(file);
        }

        /// <summary>
        /// Method to make sure an input value is within the given range
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        /// <returns>True if within and false if not.</returns>
        private static bool IntWithinRange(int value, int min, int max)
        {
            var withinRange = value >= min && value <= max;
            return withinRange;
        }

        /// <summary>
        /// Method to make the user enter a number within given range to standard input.
        /// </summary>
        /// <returns>Integer.</returns>
        private static int MakeHimChoose(int min, int max)
        {
            //numberOfPlayers initialization to store the number of players
            byte userInput = default;

            //a flag that to show an error message for the user
            bool dataEntered = false;

            while (!IntWithinRange(userInput, min, max))
            {
                if (dataEntered)
                {
                    Console.WriteLine($"Please enter a number from {min} to {max} to select a corresponding menu option.");
                }
                byte.TryParse(Console.ReadLine(), out userInput);
                dataEntered = true;
            }

            return userInput;
        }

        /// <summary>
        /// Method to check that the department with given name already exists.
        /// </summary>
        /// <param name="departmentName">name property of a department.</param>
        /// <param name="company">A company.</param>
        /// <returns>True if a department exists and false if not.</returns>
        private static bool Exists(string departmentName, Company company)
        {
            var test = Company.Descendants(company.Departments).FirstOrDefault(d => d.Name == departmentName);

            if (!Object.Equals(test.Name, null))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Main menu for the program.
        /// </summary>
        /// <param name="company">Company object.</param>
        private static void MainMenu(Company company)
        {
            while (true)
            {
                if (company != null)
                {
                    Console.WriteLine(company.ToString());
                }
                else
                {
                    company = new Company("Company");
                }

                var options = new Dictionary<int, string>
                {
                    {1, "Add a department."},
                    {2, "Add an employee."},
                    {3, "Edit a department."},
                    {4, "Edit an employee."},
                    {5, "Remove a department."},
                    {6, "Remove an employee."},
                    {7, "Sort employees in a department."},
                    {8, "Save the company."},
                    {9, "Load the company."},
                    {10, "Exit the program."}
                };

                //Display the menu.
                Console.WriteLine("\nMenu:");
                foreach (var option in options)
                {
                    Console.WriteLine($"{option.Key} - {option.Value}");
                }

                //Requesting user action.
                switch (MakeHimChoose(options.Keys.Min(), options.Keys.Max()))
                {
                    case 1:
                        MenuAddDepartment(company);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        SaveJson(company);
                        continue;
                    case 9:
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Such an option doesn't exist");
                        break;
                }

                break;
            }
        }

        /// <summary>
        /// Add department menu functionality.
        /// </summary>
        /// <param name="company">Company object.</param>
        private static void MenuAddDepartment(Company company)
        {
            var options = new Dictionary<int, string>
            {
                {1, "Quickly add a department by name."},
                {2, "Quickly add a sub-department by name."},
                {3, "Create a new department."},
                {4, "Create a new sub-department."},
                {5, "Return to the main menu."}
            };

            //Display the menu.
            Console.WriteLine("\nAdd a department:");
            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }

            //Requesting and proceeding user action.
            switch (MakeHimChoose(options.Keys.Min(), options.Keys.Max()))
            {
                case 1:
                    var name = string.Empty;
                    while (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Please enter the name of the New department.");
                        name = Console.ReadLine().Trim();

                        //Make sure the department will be unique.
                        if (Exists(name,company))
                        {
                            name = null;
                            Console.WriteLine("Company already has a department with given name.");
                        }
                    }
                    company.AddDepartment(name);
                    MainMenu(company);
                    break;
                case 2:
                    name = string.Empty;
                    var parent = string.Empty;
                    //Make sure a department exists in the company.
                    if (company.Departments.Count == 0)
                    {
                        Console.WriteLine("The company has no departments, please add one first.");
                        MainMenu(company);
                        break;
                    }

                    //If a department exists start adding a sub-department.
                    //Requesting parent department name.
                    while (string.IsNullOrEmpty(parent))
                    {
                        Console.WriteLine("Please enter the name of the Parent department.");
                        parent = Console.ReadLine().Trim();

                        if (!Exists(parent, company))
                        {
                            parent = null;
                            Console.WriteLine("Company does not have a department with given name." +
                                              "\nCompany has the following department(s):");
                            foreach (var d in company.Departments)
                            {
                                Console.WriteLine(d.ToString());
                            }

                        }
                    }

                    //Requesting new department name.
                    while (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Please enter the name of the New department.");
                        name = Console.ReadLine().Trim();

                        //Make sure the department will be unique.
                        if (Exists(name, company))
                        {
                            name = null;
                            Console.WriteLine("Company has a department with given name.");
                        }
                    }

                    company.AddDepartment(parent, name);
                    MainMenu(company);
                    break;
                case 3:
                    name = string.Empty;
                    while (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Please enter a name for the New department.");
                        name = Console.ReadLine().Trim();

                        //Make sure the department will be unique.
                        if (Exists(name, company))
                        {
                            name = null;
                            Console.WriteLine("Company already has a department with the given name.");
                        }
                    }

                    //Requesting department size.
                    uint size;
                    do
                    {
                        Console.WriteLine("Please enter the size for the new department.");
                        if (uint.TryParse(Console.ReadLine(), out size))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Department size is a number.");
                        }
                    } 
                    while (true);

                    var dep = new Department(name,size);
                    company.AddDepartment(dep);
                    MainMenu(company);
                    break;
                case 4:
                    name = string.Empty;

                    //Make sure a department exists in the company.
                    if (company.Departments.Count == 0)
                    {
                        Console.WriteLine("The company has no departments, please add one first.");
                        MainMenu(company);
                        break;
                    }

                    //Requesting a name for the new department.
                    while (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Please enter a name for the New department.");
                        name = Console.ReadLine().Trim();

                        //Make sure the department will be unique.
                        if (Exists(name, company))
                        {
                            name = null;
                            Console.WriteLine("Company already has a department with the given name.");
                        }
                    }

                    parent = string.Empty;

                    //If a department exists start adding a sub-department.
                    //Requesting parent department name.
                    while (string.IsNullOrEmpty(parent))
                    {
                        Console.WriteLine("Please enter the name of the Parent department.");
                        parent = Console.ReadLine().Trim();

                        if (!Exists(parent, company))
                        {
                            parent = null;
                            Console.WriteLine("Company does not have a department with given name." +
                                              "\nCompany has the following department(s):");
                            foreach (var d in company.Departments)
                            {
                                Console.WriteLine(d.ToString());
                            }

                        }
                    }

                    //Requesting department size.
                    size = default;
                    do
                    {
                        Console.WriteLine("Please enter the size for the new department.");
                        if (uint.TryParse(Console.ReadLine(), out size))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Department size is a number.");
                        }
                    }
                    while (true);

                    dep = new Department(name, parent, size);
                    company.AddDepartment(dep);
                    MainMenu(company);
                    break;
                case 5:
                    MainMenu(company);
                    break;
                default:
                    Console.WriteLine("Such an option doesn't exist");
                    break;
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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
            //TODO get only date portion of creation date and time.
            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_08 8.6 Homework\"");

            //Create new company.
            var company = new Company("Test");

            //Add first 3 departments to the company
            string first = "First Dep";
            string second = "Second Dep";
            string third = "Third Dep";
            string toDelete = "To test deletion";

            company.AddDepartment(first);
            company.AddDepartment(second);
            company.AddDepartment(third);
            company.AddDepartment(toDelete);
            

            //Add a sub-department to the first department
            company.AddDepartment(first, "sub-dep for first dep");

            ////add sub-department to the sub-department.
            company.AddDepartment("sub-dep for first dep", "sub-sub-sub for 1st");
            company.AddDepartment("sub-sub-sub for 1st", "DNO");
            company.AddDepartment("DNO", "DNO2");
            company.AddDepartment("Third Dep", "Sub-dep for Third Dep");

            //This is how assignment of new fields works
            string secSubDep = "Second sub-dep";
            company.AddDepartment(second, secSubDep);

            //string newSecond = "Pretty name for second sub-department";
            string newValue = "Changed name";
            company.ChangeDepartmentName(second, newValue);
            company.ChangeDepartment(newValue, 256);

            //Departments to test deletion
            company.AddDepartment(toDelete, "subtree to test deletion");

            //Remove a department works this way
            company.RemoveDepartment(toDelete);
            
            Console.WriteLine(company.ToString());

            //department.AddEmployee(new Employee(company.IdGen.ID, "Name", "Surname", 100, 10000, "no clue"));

            //department.AddSubDepartment(new Department("Subdep for first"));
            //var subDepartment = department.SubDepartments.Find(sd => sd.Name == "subdep for first");
            //subDepartment.AddEmployee(new Employee(company.IdGen.ID, "NameSD", "SurnameSD", 200, 20000, "no clue"));
            //subDepartment.AddSubDepartment(new Department("subsubdep"));











            //Console.WriteLine(company.IdGen.ID);




            //Console.WriteLine((new Employee(1,"Sasha","Saprykin",35,0,"freelance").ToString()));
            Console.ReadKey();
        }
    }
}

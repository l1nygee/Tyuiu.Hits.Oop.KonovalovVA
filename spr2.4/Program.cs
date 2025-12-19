using System;

namespace EmployeeExample
{
    public class Employee
    {
        protected string Name { get; set; }
        protected string Position { get; set; }
        protected float Salary { get; set; }

        public Employee(string name, string position, float salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name}, Должность: {Position}, Зарплата: {Salary}");
        }
    }

    public class Manager : Employee
    {
        protected string Department { get; set; }

        public Manager(string name, string position, float salary, string department)
            : base(name, position, salary)
        {
            Department = department;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name}, Отдел: {Department}, Должность: {Position}, Зарплата: {Salary}");
        }
    }

    public interface IReportable
    {
        string GenerateReport(string report);
    }

    public interface ITeamLeader
    {
        string[] GetTeamMembers();
    }

    public class ProjectManager : Manager, IReportable, ITeamLeader
    {
        private string ProjectName { get; set; }
        protected string[] TeamMembers { get; set; }
        protected string Report { get; set; }

        public ProjectManager(string name, string position, float salary, string department, string projectName, string[] teamMembers)
            : base(name, position, salary, department)
        {
            ProjectName = projectName;
            TeamMembers = teamMembers;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name}, Отдел: {Department}, Должность: {Position}, Зарплата: {Salary}, Название проекта: {ProjectName}");
        }

        public string GenerateReport(string report)
        {
            Report = report;
            return Report;
        }

        public string[] GetTeamMembers()
        {
            return TeamMembers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Анна", "Python Data Scientist", 185000);
            Manager manager = new Manager("Сергей", "Mobile Team Lead", 245000, "Android Development");

            string[] team = { "Мария", "Иван", "Елена", "Артем", "Ольга" };
            ProjectManager projectManager = new ProjectManager("Михаил", "Lead DevOps", 312000, "Infrastructure", "Cloud Migration", team);

            employee.PrintInfo();
            Console.WriteLine();

            manager.PrintInfo();
            Console.WriteLine();

            projectManager.PrintInfo();
            projectManager.GenerateReport("Отчёт: миграция в облако AWS");
            projectManager.GetTeamMembers();
        }
    }
}
using System;

namespace ITI3
{
    public class Employee
    {
        public int Id;
        public string Name;
        public int Age;
        public double Salary;

        public Employee[] employees = new Employee[100];
        public int count = 0;

        public void Add()
        {
            if (count < employees.Length)
            {
                employees[count] = new Employee();
                Console.Write("Enter Employee Id: ");
                employees[count].Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                employees[count].Name = Console.ReadLine();

                Console.Write("Enter Age: ");
                employees[count].Age = int.Parse(Console.ReadLine());

                Console.Write("Enter Salary: ");
                employees[count].Salary = double.Parse(Console.ReadLine());

                count++;
                Console.WriteLine("Employee added successfully");
            }
        }

        public void Edit()
        {
            Console.Write("Enter Employee Id to edit: ");
            int editId = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (employees[i].Id == editId)
                {
                    found = true;

                    Console.Write("Enter new Name (leave empty to keep same): ");

                    string newName = Console.ReadLine();

                    if (newName != null && newName != "")
                        employees[i].Name = newName;

                    Console.Write("Enter new Age (leave empty to keep same): ");

                    string newAge = Console.ReadLine();

                    if (newAge != null && newAge != "")
                        employees[i].Age = int.Parse(newAge);

                    Console.Write("Enter new Salary (leave empty to keep same): ");

                    string newSalary = Console.ReadLine();

                    if (newSalary != null && newSalary != "")
                        employees[i].Salary = double.Parse(newSalary);

                    Console.WriteLine("Employee updated successfully");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void Delete()
        {
            Console.Write("Enter Employee Id to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (employees[i].Id == deleteId)
                {
                    found = true;
                    for (int j = i; j < count - 1; j++)
                    {
                        employees[j] = employees[j + 1];
                    }
                    employees[count - 1] = null;
                    count--;
                    Console.WriteLine("Employee deleted successfully");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void GetAll()
        {
            if (count == 0)
            {
                Console.WriteLine("No employees found");
            }
            else
            {
                Console.WriteLine("\nAll Employees:");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Id: {employees[i].Id}, Name: {employees[i].Name}, Age: {employees[i].Age}, Salary: {employees[i].Salary}");
                }
            }
        }

        public void GetById()
        {
            Console.Write("Enter Employee Id: ");
            int searchId = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (employees[i].Id == searchId)
                {
                    found = true;
                    Console.WriteLine($"Id: {employees[i].Id}, Name: {employees[i].Name}, Age: {employees[i].Age}, Salary: {employees[i].Salary}");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public static void Main(string[] args)
        {
            Employee employee = new Employee();

            while (true)
            {
                Console.WriteLine("\n===== Employee Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Get All Employees");
                Console.WriteLine("5. Get Employee By Id");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        employee.Add();
                        break;
                    case "2":
                        employee.Edit();
                        break;
                    case "3":
                        employee.Delete();
                        break;
                    case "4":
                        employee.GetAll();
                        break;
                    case "5":
                        employee.GetById();
                        break;
                    case "6":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again");
                        break;
                }
            }
        }
    }
}

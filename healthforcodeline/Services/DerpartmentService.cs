﻿using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class DepartmentService
    {




        public static void DisplayDepartmentMenu()// This method displays the department management menu and handles user input
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║     DEPARTMENT MANAGEMENT MENU       ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Add Department                    ║");
                Console.WriteLine("║ 2. View All Departments              ║");
                Console.WriteLine("║ 3. Update Department                 ║");
                Console.WriteLine("║ 4. Delete Department                 ║");
                Console.WriteLine("║ 5. Search Department by ID or Name  ║");
                Console.WriteLine("║ 6. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-6): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDepartment();// Add a new department
                        break;
                    case "2":
                        ViewDepartments();// View all departments
                        break;
                    case "3":
                        UpdateDepartment();// Update an existing department
                        break;
                    case "4":
                        DeleteDepartment();// Delete a department
                        break;
                    case "5":
                        SearchDepartment();// Search for a department by ID or name
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void AddDepartment()// This method allows the user to add a new department
        {
            try
            {
                Console.Write("Enter Department ID: ");
                int id = int.Parse(Console.ReadLine());

                if (HospitalData.Departments.Any(d => d.Id == id))// Check if the department ID already exists
                {
                    Console.WriteLine("❌ Department ID already exists.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();

                if (HospitalData.Departments.Any(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("❌ Department name already exists.");
                    Console.ReadKey();
                    return;
                }

                var department = new Department(id, name);
                HospitalData.Departments.Add(department);

                FileStorage.SaveToFile("departments.json", HospitalData.Departments);

                Console.WriteLine("✅ Department added and saved successfully.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to add department: {ex.Message}");
                Console.ReadKey();
            }
        }


        public static void ViewDepartments()// This method displays all departments in the hospital data
        {
            if (!HospitalData.Departments.Any())
            {
                Console.WriteLine("No departments found.");
                return;
            }

            Console.WriteLine("\nList of Departments:");
            foreach (var dept in HospitalData.Departments)
            {
                Console.WriteLine($"ID: {dept.Id}, Name: {dept.Name}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
        public static void UpdateDepartment()// This method allows the user to update an existing department
        {
            Console.Write("Enter Department ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var dept = HospitalData.Departments.FirstOrDefault(d => d.Id == id);
                if (dept == null)
                {
                    Console.WriteLine("❌ Department not found.");
                }
                else
                {
                    Console.Write("Enter new Department Name: ");
                    string newName = Console.ReadLine();

                    if (HospitalData.Departments.Any(d => d.Name.Equals(newName, StringComparison.OrdinalIgnoreCase) && d.Id != id))
                    {
                        Console.WriteLine("❌ A department with this name already exists.");
                    }
                    else
                    {
                        dept.Name = newName;
                        FileStorage.SaveToFile("departments.json", HospitalData.Departments);
                        Console.WriteLine("✅ Department updated successfully.");
                    }
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid ID format.");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public static void DeleteDepartment()// This method allows the user to delete a department
        {
            Console.Write("Enter Department ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var dept = HospitalData.Departments.FirstOrDefault(d => d.Id == id);
                if (dept == null)
                {
                    Console.WriteLine("❌ Department not found.");
                }
                else
                {
                    HospitalData.Departments.Remove(dept);
                    FileStorage.SaveToFile("departments.json", HospitalData.Departments);
                    Console.WriteLine("✅ Department deleted.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input.");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public static void SearchDepartment()// This method allows the user to search for a department by ID or name
        {
            Console.Write("Enter Department ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))// Check if the input is a valid number
            {
                var dept = HospitalData.Departments.FirstOrDefault(d => d.Id == id);// Search for the department by ID
                if (dept != null)
                {
                    Console.WriteLine($"\n🔍 Department Found:");
                    Console.WriteLine($"ID: {dept.Id}, Name: {dept.Name}");
                }
                else
                {
                    Console.WriteLine("❌ Department not found.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input. Please enter a valid number.");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }


    }
}

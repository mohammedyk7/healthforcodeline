﻿using System;
using System.Collections.Generic;
using System.Linq;
using hospitalsystem.models;

namespace hospitalsystem.services
{
    public static class branchService
    {
        public static void RunBranchService()// Branch service menu for managing hospital branches
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║              BRANCH SERVICE MENU           ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Branch                           ║");
                Console.WriteLine("║ 2. View All Branches                       ║");
                Console.WriteLine("║ 3. Update Branch                           ║");
                Console.WriteLine("║ 4. Delete Branch                           ║");
                Console.WriteLine("║ 5. Search Branch by ID                     ║");
                Console.WriteLine("║ 6. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1-6): ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1": CreateBranch(); break;// Create a new branch
                    case "2": ViewAllBranches(); break;// View all branches
                    case "3": UpdateBranch(); break;// Update an existing branch
                    case "4": DeleteBranch(); break;// Delete a branch
                    case "5": SearchBranchById(); break;// Search for a branch by ID
                    case "6": return;
                    default:
                        Console.WriteLine("⚠️ Invalid selection.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void CreateBranch()// Create a new branch with user input
        {
            Console.Write("Enter Branch ID: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Branch Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Branch Location: ");
            string location = Console.ReadLine()!;

            var branch = new Branch(id, name, location);// Create a new Branch object
            HospitalData.Branches.Add(branch);// Add the new branch to the hospital data
            FileStorage.SaveToFile("branches.json", HospitalData.Branches);
            Console.WriteLine("✅ Branch created.");
            Console.ReadKey();
        }

        public static void ViewAllBranches()// Display all branches in the hospital data
        {
            if (HospitalData.Branches.Count == 0)
            {
                Console.WriteLine("No branches found.");
            }
            else
            {
                foreach (var b in HospitalData.Branches)
                    b.Display(); // Make sure Branch has a Display() method
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public static void UpdateBranch()// Update an existing branch based on user input
        {
            Console.Write("Enter Branch ID to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var branch = HospitalData.Branches.FirstOrDefault(b => b.Id == id);// Find the branch by ID

            if (branch == null)
            {
                Console.WriteLine("❌ Branch not found.");
            }
            else
            {
                Console.Write("New Name: ");
                branch.Name = Console.ReadLine()!;
                Console.Write("New Location: ");
                branch.Location = Console.ReadLine()!;
                FileStorage.SaveToFile("branches.json", HospitalData.Branches);
                Console.WriteLine("✅ Branch updated.");
            }
            Console.ReadKey();
        }

        private static void DeleteBranch()// Delete a branch based on user input
        {
            Console.Write("Enter Branch ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            var branch = HospitalData.Branches.FirstOrDefault(b => b.Id == id);// Find the branch by ID

            if (branch == null)
            {
                Console.WriteLine("❌ Branch not found.");
            }
            else
            {
                HospitalData.Branches.Remove(branch);// Remove the branch from the list
                FileStorage.SaveToFile("branches.json", HospitalData.Branches);
                Console.WriteLine("✅ Branch deleted.");
            }
            Console.ReadKey();
        }

        private static void SearchBranchById()// Search for a branch by its ID
        {
            Console.Write("Enter Branch ID to search: ");
            int id = int.Parse(Console.ReadLine()!);
            var branch = HospitalData.Branches.FirstOrDefault(b => b.Id == id);// Find the branch by ID

            if (branch == null)
            {
                Console.WriteLine("❌ No branch found with that ID.");
            }
            else
            {
                Console.WriteLine("🔍 Branch Found:");
                branch.Display();
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }


    }
}

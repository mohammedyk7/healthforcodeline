using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // IBranchService.cs
    public interface IBranchService // Interface for branch management operations
    {
        void CreateBranch(Branch branch);// Create a new branch
        List<Branch> GetAllBranches();// Retrieve all branches
        Branch? GetBranchById(int id);// Retrieve a branch by its ID
        void DeleteBranch(int id);// Delete a branch by its ID
        void UpdateBranch(Branch branch);
    }// Interface for updating a branch
}

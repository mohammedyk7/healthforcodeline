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
        List<Branch> GetAllBranches();
        Branch? GetBranchById(int id);
        void DeleteBranch(int id);
        void UpdateBranch(Branch branch);
    }
}

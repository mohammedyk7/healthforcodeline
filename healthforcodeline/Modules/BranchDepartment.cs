namespace hospitalsystem.models
{    // Represents a many-to-many relationship between branches and departments

    public class BranchDepartment
    {
        // The ID of the branch in the relationship

        public int BranchId { get; set; }
        public int DepartmentId { get; set; }

        public BranchDepartment(int branchId, int departmentId)
        {
            BranchId = branchId;
            DepartmentId = departmentId;
        }

        public void Display()
        {
            Console.WriteLine($"Branch ID: {BranchId} is linked to Department ID: {DepartmentId}");
        }
    }
}

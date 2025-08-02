namespace hospitalsystem.models
{    // Represents a many-to-many relationship between branches and departments

    public class BranchDepartment
    {
        // The ID of the branch in the relationship

        public int BranchId { get; set; }
        // The ID of the department in the relationship

        public int DepartmentId { get; set; }
        // Constructor to initialize the relationship between a branch and a department

        public BranchDepartment(int branchId, int departmentId)
        {
            BranchId = branchId;
            DepartmentId = departmentId;
        }
        // Display method to show the relationship in a readable format

        public void Display()
        {
            Console.WriteLine($"Branch ID: {BranchId} is linked to Department ID: {DepartmentId}");
        }
    }
}

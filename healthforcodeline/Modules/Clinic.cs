namespace hospitalsystem.models
{
    public class Clinic
    {

    

        public int Id { get; set; }// Unique identifier for the clinic
        public string Name { get; set; }// Name of the clinic
        public int DepartmentId { get; set; }// Identifier for the department the clinic belongs to 
        public int BranchId { get; set; }// Identifier for the branch the clinic is associated with

        public Clinic() { }  // Default constructor

        public Clinic(int id, string name, int branchId)// Constructor with parameters for ID, name, and branch ID
        {
            Id = id;
            Name = name;
            BranchId = branchId;
        }
        public Clinic(int id, string name, int departmentId, int branchId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            BranchId = branchId;
        }


        public void Display()
        {
            Console.WriteLine($"Clinic #{Id}: {Name} (Branch ID: {BranchId})");
        }
    }
}

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
            Id = id;// Initialize the clinic's ID
            Name = name;// Initialize the clinic's name
            BranchId = branchId;// Initialize the clinic's branch ID
        }
        public Clinic(int id, string name, int departmentId, int branchId)// Constructor with parameters for ID, name, department ID, and branch ID
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;// Initialize the clinic's department ID
            BranchId = branchId;
        }


        public void Display()
        {
            Console.WriteLine($"Clinic #{Id}: {Name} (Branch ID: {BranchId})");
        }
    }
}

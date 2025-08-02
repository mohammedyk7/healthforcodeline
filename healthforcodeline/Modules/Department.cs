namespace hospitalsystem.models
{
    public class Department// Represents a department in the hospital system
    {
        public int Id { get; set; }// Unique identifier for the department
        public string Name { get; set; }// Name of the department

        public Department() { }// Default constructor

        public Department(int id, string name)// Constructor with parameters for ID and name
        {
            Id = id;// Initialize the department's ID
            Name = name;// Initialize the department's name
        }

        public void Display()// Method to display department information
        {
            Console.WriteLine($"Department #{Id}: {Name}");// Display the department's ID and name
        }
    }
}

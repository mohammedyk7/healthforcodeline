namespace hospitalsystem.models
{
    public class Department// Represents a department in the hospital system
    {
        public int Id { get; set; }// Unique identifier for the department
        public string Name { get; set; }

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Department #{Id}: {Name}");
        }
    }
}

namespace hospitalsystem.models
{        // Represents a hospital branch with an ID, name, and location

    public class Branch
    {
        // Unique identifier for the branch

        public int Id { get; set; }
        // Name of the branch (e.g., "Silaf Main Branch")

        public string Name { get; set; }
        public string Location { get; set; }


        public Branch() { }

        public Branch(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public void Display()
        {
            Console.WriteLine($"Branch #{Id}: {Name} - {Location}");
        }
    }
}
namespace hospitalsystem.models
{        // Represents a hospital branch with an ID, name, and location

    public class Branch
    {
        // Unique identifier for the branch

        public int Id { get; set; }
        // Name of the branch (e.g., "Silaf Main Branch")

        public string Name { get; set; }
        // Physical location/address of the branch

        public string Location { get; set; }

        // Parameterless constructor (useful for deserialization or manual property setting)

        public Branch() { }
        // Constructor to create a branch with specific values

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
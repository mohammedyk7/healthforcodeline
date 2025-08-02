namespace hospitalsystem.models
{
    public abstract class User// Represents a user in the hospital system
    {
        public string FullName { get; set; }// Full name of the user
        public string Email { get; set; }// Email address of the user
        public string Password { get; set; }// Password for the user account
        public string Role { get; set; }// Role of the user (e.g., Doctor, Patient, Admin)

        public User() { }

        public User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public abstract void DisplayMenu();
    }
}

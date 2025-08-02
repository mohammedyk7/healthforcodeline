using System.Text.Json;

namespace hospitalsystem.models
{
    public static class FileStorage
    {
        // Static utility class for handling generic and specific file operations (serialization and deserialization)

        public static void SaveToFile<T>(string fileName, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
        // Loads and deserializes data of type T from a specified file.

        public static List<T> LoadFromFile<T>(string fileName)
        {
            if (!File.Exists(fileName)) return new List<T>();
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // ✅ Specific loaders
        // Loads all doctor records from "doctors.json".

        public static List<Doctor> LoadDoctors()
        {
            return LoadFromFile<Doctor>("doctors.json");
        }
        //Loads all patient records from "patients.json".

        public static List<Patient> LoadPatients()
        {
            return LoadFromFile<Patient>("patients.json");
        }
        // Loads all booking records from "bookings.json".

        public static List<Booking> LoadBookings()
        {
            return LoadFromFile<Booking>("bookings.json");
        }
    }
}

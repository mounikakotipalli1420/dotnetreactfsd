namespace Doctor
{
    internal class Program
    {
        static List<Doctor> doctors = new List<Doctor>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Clinic Management System\n");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Modify Doctor Phone");
                Console.WriteLine("3. Modify Doctor Experience");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        ModifyDoctorPhone();
                        break;
                    case 3:
                        ModifyDoctorExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddDoctor()
        {
            Console.Write("Enter Doctor's Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Doctor's Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Doctor's Experience: ");
            int experience = int.Parse(Console.ReadLine());

            Doctor doctor = new Doctor
            {
                Name = name,
                Phone = phone,
                Experience = experience
            };

            doctors.Add(doctor);

            Console.WriteLine("Doctor added successfully!");
        }

        static void ModifyDoctorPhone()
        {
            Console.Write("Enter the name of the doctor: ");
            string name = Console.ReadLine();
            Doctor doctor = doctors.Find(d => d.Name == name);

            if (doctor != null)
            {
                Console.Write("Enter new phone number: ");
                string newPhone = Console.ReadLine();
                doctor.Phone = newPhone;
                Console.WriteLine("Phone number updated successfully!");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        static void ModifyDoctorExperience()
        {
            Console.Write("Enter the name of the doctor: ");
            string name = Console.ReadLine();
            Doctor doctor = doctors.Find(d => d.Name == name);

            if (doctor != null)
            {
                Console.Write("Enter new experience: ");
                int newExperience = int.Parse(Console.ReadLine());
                doctor.Experience = newExperience;
                Console.WriteLine("Experience updated successfully!");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        static void DeleteDoctor()
        {
            Console.Write("Enter the name of the doctor to delete: ");
            string name = Console.ReadLine();
            Doctor doctor = doctors.Find(d => d.Name == name);

            if (doctor != null)
            {
                doctors.Remove(doctor);
                Console.WriteLine("Doctor deleted successfully!");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }
    }

    class Doctor
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
    }
}
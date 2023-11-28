using ClinicModelLibrary;
using ClinicBLLibrary;
using System.Numerics;

namespace ClinicApp
{
    internal class Program
    {
        IClinicService clinicService;
        public Program()
        {
            clinicService = new ClinicService();
        }
        void displayAdminMenu()
        {
            Console.WriteLine(" 1.Add Doctor");
            Console.WriteLine(" 2.Modify Doctor Phone");
            Console.WriteLine(" 3.Modify Doctor Experience");
            Console.WriteLine(" 4.Delete Doctor");
            Console.WriteLine(" 5.Print All Doctors");
            Console.WriteLine(" 0. Exit ");

        }
        void StartAdminActivities()
        {
            int choice;
            do
            {
                displayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        UpdatePhone();
                        break;
                    case 3:
                        UpdateExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintAllDoctors();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        private void PrintAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctors = clinicService.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorDetails();
                var result = clinicService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Enter Doctor Name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Enter Doctor Qualification");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Enter Doctor Specialization");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Enter Doctor Experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctor Fee");
            doctor.Fee = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Doctor Mobile Number");
            doctor.Phone = Convert.ToDouble(Console.ReadLine());
            return doctor;
        }
        int GetProductIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the product id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetProductIdFromUser();
                if (clinicService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateExperience()
        {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the new experience");
            int experience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = experience;
            doctor.Id = id;
            try
            {
                var result = clinicService.UpdateDoctorExperience(id, experience);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdatePhone()
        {
            var id = GetProductIdFromUser();
            Console.WriteLine("Please enter the new phone number");
            double phone = Convert.ToDouble(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phone = phone;
            doctor.Id = id;
            try
            {
                var result = clinicService.UpdateDoctorPhone(id, phone);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int Main(string[] args)
        {
            Program program = new Program();
            program.StartAdminActivities();
            Console.WriteLine("Welcome to Clinic!!");
            return 0;
        }
    }
}
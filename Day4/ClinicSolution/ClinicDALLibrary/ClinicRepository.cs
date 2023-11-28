using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    public class ClinicRepository : IClinicRepository
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor">Doctor object that has to be added</param>
        /// <returns>The doctor object that has been added</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Doctor Add(Doctor doctor)
        {

            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The doctor Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;

        }

        private int GetTheNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }



        /// <summary>
        /// Deletes the doctor from the dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the docotr to be deleted</param>
        /// <returns>The deleted product</returns>

        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id of the Doctors are getting</param>
        /// <returns> returns the doctors using id</returns>
        public Doctor GetById(int id)
        {
            return doctors[id];
        }
        // <summary>
        /// 
        /// </summary>
        /// <param name="product"> Doctors updated using id from the dictionary</param>
        /// <returns>Returns the updated Doctor</returns>
        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
    }
}

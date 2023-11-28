using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorModelLibrary;

namespace DoctorDALLibrary
{
   
        public class ProductRepository : IRepository
        {
            Dictionary<string, Doctor> doctor = new Dictionary<string, Doctor>();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="product">Product object that has to be added</param>
            /// <returns>The product that has been added</returns>
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
                    Console.WriteLine("The product Id already exists");
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
            /// Deletes the product from teh dictionary using the id as key
            /// </summary>
            /// <param name="id">The Id of the product to be deleted</param>
            /// <returns>The deleted product</returns>
            public Doctors Delete(int id)
            {
                var product = doctors[id];
                doctors.Remove(id);
                return doctor;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns> Getting all the items using dictionaries</returns>

            public List<Doctor> GetAll()
            {
                var productList = doctors.Values.ToList();
                return doctorList;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="id">The id of the products are getting</param>
            /// <returns> returns the product using id</returns>
            public Doctor GetById(int id)
            {
                return doctors[id];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="product"> Products updated using id from the dictionary</param>
            /// <returns>Returns the updated product</returns>
            public Doctor Update(Doctor doctor)
            {
                doctors[doctor.Id] = doctor;
                return doctors[doctor.Id];
            }
        }
}


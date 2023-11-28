using DoctorDALLibrary;
using DoctorModelLibrary;

namespace DoctorBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }
        /// <summary>
        /// Adds the product to the collection using the repository
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <returns></returns>
        /// <exception cref="NotAddedException">Product Id duplicated</exception>
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
        /// <summary>
        /// Returns the product for teh given Id
        /// </summary>
        /// <param name="id">Id of the product to be returned</param>
        /// <returns></returns>
        /// <exception cref="NoSuchDoctortException">No product with the given Id</exception>
        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            //if (result != null) 
            //    return result;
            //throw new NoSuchProductException();

            //null collasing operator
            //return result ?? throw new NoSuchProductException();

            return result == null ? throw new NoSuchDoctorException() : result;
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateDoctorName(int id, string name)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Name = name;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateDoctorQuantity(int id, string name, int phone)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                if (name == "add")
                {
                    doctor.Name += name;
                }
                else if (name == "remove")
                {
                    doctor.Name -= name;
                }
                else
                    throw new InValidUpdateActionException();
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}
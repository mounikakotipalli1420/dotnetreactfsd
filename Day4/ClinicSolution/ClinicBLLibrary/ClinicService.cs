using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary;
using ClinicModelLibrary;

namespace ClinicBLLibrary
{
    public class ClinicService : IClinicService
    {
        IClinicRepository repository;
        public ClinicService()
        {
            repository = new ClinicRepository();
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var product = GetDoctor(id);
            if (product != null)
            {
                repository.Delete(id);
                return product;
            }
            throw new NoSuchDoctorException();
        }
        

        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            return result == null ? throw new NoSuchDoctorException() : result;
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateDoctorExperience(int id, int experience)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Experience = experience;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }


        public Doctor UpdateDoctorPhone(int id, double phone)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Phone = phone;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}

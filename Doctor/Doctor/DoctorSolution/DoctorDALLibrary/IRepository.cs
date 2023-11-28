using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorModelLibrary;

namespace DoctorDALLibrary
{
    public interface IRepository
    {
        public Doctor Add(Doctor doctor);
        public Doctor Update(Doctor doctor);
        public Doctor Delete(string name);
        public Doctor GetById(string name);
        public List<Doctor> GetAll();
    }
}

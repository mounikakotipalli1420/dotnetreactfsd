using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public interface IDoctorService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor(int id, string name);
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor UpdateDoctorQuantity(int id, string name, int phone);
        public Doctor Delete(int id);
    }
}

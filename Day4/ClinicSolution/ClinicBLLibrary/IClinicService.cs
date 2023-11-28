﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;
using ClinicDALLibrary;
namespace ClinicBLLibrary
{
    public interface IClinicService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctorPhone(int id, double phone);
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor UpdateDoctorExperience(int id, int experience);
        public Doctor Delete(int id);
    }
}

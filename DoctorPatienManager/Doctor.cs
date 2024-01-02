using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatienManager
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Doctor(int id, string name, string department)
        {
            Id = id;
            Name = name;
            Department = department;
        }
    }
}
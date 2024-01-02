using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatienManager
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public string History { get; set; }

        public Patient(int id, string name, int doctorId, string history)
        {
            Id = id;
            Name = name;
            DoctorId = doctorId;
            History = history;
        }
    }
}
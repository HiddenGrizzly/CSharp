using System;
using System.Collections.Generic;
using DoctorPatienManager;

class Program
{
    static List<Doctor> doctors = new List<Doctor>();
    static List<Patient> patients = new List<Patient>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Register New Doctor");
            Console.WriteLine("2. Maintain Existing Doctors");
            Console.WriteLine("3. Track Specific Doctor");
            Console.WriteLine("4. Display All Doctors");
            Console.WriteLine("5. Register New Patient");
            Console.WriteLine("6. Maintain Existing Patients");
            Console.WriteLine("7. Track Specific Patient");
            Console.WriteLine("8. Display All Patients");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterNewDoctor();
                    break;
                case 2:
                    MaintainExistingDoctors();
                    break;
                case 3:
                    TrackSpecificDoctor();
                    break;
                case 4:
                    DisplayAllDoctors();
                    break;
                case 5:
                    RegisterNewPatient();
                    break;
                case 6:
                    MaintainExistingPatients();
                    break;
                case 7:
                    TrackSpecificPatient();
                    break;
                case 8:
                    DisplayAllPatients();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void RegisterNewDoctor()
    {
        Console.Write("Enter Doctor ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Doctor Department: ");
        string department = Console.ReadLine();

        Doctor newDoctor = new Doctor(id, name, department);
        doctors.Add(newDoctor);

        Console.WriteLine("Doctor registered successfully!");
    }

    static void TrackSpecificDoctor()
    {
        Console.Write("Enter Doctor ID to track: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Doctor doctor = doctors.Find(d => d.Id == id);

        if (doctor != null)
        {
            Console.WriteLine($"Doctor ID: {doctor.Id}");
            Console.WriteLine($"Doctor Name: {doctor.Name}");
            Console.WriteLine($"Doctor Department: {doctor.Department}");
        }
        else
        {
            Console.WriteLine("Doctor not found!");
        }
    }

    static void DisplayAllDoctors()
    {
        Console.WriteLine("List of all Doctors:");
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine($"Doctor ID: {doctor.Id}");
            Console.WriteLine($"Doctor Name: {doctor.Name}");
            Console.WriteLine($"Doctor Department: {doctor.Department}");
            Console.WriteLine();
        }
    }

    static void RegisterNewPatient()
    {
        Console.Write("Enter Patient ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Patient Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Doctor ID for the Patient: ");
        int doctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Patient History: ");
        string history = Console.ReadLine();

        Patient newPatient = new Patient(id, name, doctorId, history);
        patients.Add(newPatient);

        Console.WriteLine("Patient registered successfully!");
    }

    static void TrackSpecificPatient()
    {
        Console.Write("Enter Patient ID to track: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Patient patient = patients.Find(p => p.Id == id);

        if (patient != null)
        {
            Console.WriteLine($"Patient ID: {patient.Id}");
            Console.WriteLine($"Patient Name: {patient.Name}");
            Console.WriteLine($"Doctor ID: {patient.DoctorId}");
            Console.WriteLine($"Patient History: {patient.History}");
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
    }

    static void DisplayAllPatients()
    {
        Console.WriteLine("List of all Patients:");
        foreach (Patient patient in patients)
        {
            Console.WriteLine($"Patient ID: {patient.Id}");
            Console.WriteLine($"Patient Name: {patient.Name}");
            Console.WriteLine($"Doctor ID: {patient.DoctorId}");
            Console.WriteLine($"Patient History: {patient.History}");
            Console.WriteLine();
        }
    }
    static void MaintainExistingDoctors()
    {
        Console.Write("Enter Doctor ID to maintain: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Doctor doctor = doctors.Find(d => d.Id == id);

        if (doctor != null)
        {
            Console.WriteLine($"1. Update Doctor Details");
            Console.WriteLine($"2. Delete Doctor");
            Console.WriteLine($"3. View Doctor Details");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UpdateDoctorDetails(doctor);
                    break;
                case 2:
                    DeleteDoctor(doctor);
                    break;
                case 3:
                    ViewDoctorDetails(doctor);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Doctor not found!");
        }
    }

    static void UpdateDoctorDetails(Doctor doctor)
    {
        Console.Write("Enter new Doctor Name: ");
        doctor.Name = Console.ReadLine();

        Console.Write("Enter new Doctor Department: ");
        doctor.Department = Console.ReadLine();

        Console.WriteLine("Doctor details updated successfully!");
    }

    static void DeleteDoctor(Doctor doctor)
    {
        doctors.Remove(doctor);
        Console.WriteLine("Doctor deleted successfully!");
    }

    static void ViewDoctorDetails(Doctor doctor)
    {
        Console.WriteLine($"Doctor ID: {doctor.Id}");
        Console.WriteLine($"Doctor Name: {doctor.Name}");
        Console.WriteLine($"Doctor Department: {doctor.Department}");
    }
    static void MaintainExistingPatients()
    {
        Console.Write("Enter Patient ID to maintain: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Patient patient = patients.Find(p => p.Id == id);

        if (patient != null)
        {
            Console.WriteLine($"1. Update Patient Details");
            Console.WriteLine($"2. Delete Patient");
            Console.WriteLine($"3. View Patient Details");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UpdatePatientDetails(patient);
                    break;
                case 2:
                    DeletePatient(patient);
                    break;
                case 3:
                    ViewPatientDetails(patient);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Patient not found!");
        }
    }

    static void UpdatePatientDetails(Patient patient)
    {
        Console.Write("Enter new Patient Name: ");
        patient.Name = Console.ReadLine();

        Console.Write("Enter new Doctor ID for the Patient: ");
        patient.DoctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Patient History: ");
        patient.History = Console.ReadLine();

        Console.WriteLine("Patient details updated successfully!");
    }

    static void DeletePatient(Patient patient)
    {
        patients.Remove(patient);
        Console.WriteLine("Patient deleted successfully!");
    }

    static void ViewPatientDetails(Patient patient)
    {
        Console.WriteLine($"Patient ID: {patient.Id}");
        Console.WriteLine($"Patient Name: {patient.Name}");
        Console.WriteLine($"Doctor ID: {patient.DoctorId}");
        Console.WriteLine($"Patient History: {patient.History}");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Medicine> medicines = new List<Medicine>();
    static List<Sale> sales = new List<Sale>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add Medicine");
            Console.WriteLine("2. Update Medicine");
            Console.WriteLine("3. Delete Medicine");
            Console.WriteLine("4. Add Sale");
            Console.WriteLine("5. Report Medicine State");
            Console.WriteLine("6. Report Income by Day");
            Console.WriteLine("7. Report Income by Month");
            Console.WriteLine("8. Report Income by Year");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddMedicine();
                    break;
                case 2:
                    UpdateMedicine();
                    break;
                case 3:
                    DeleteMedicine();
                    break;
                case 4:
                    AddSale();
                    break;
                case 5:
                    ReportMedicineState();
                    break;
                case 6:
                    ReportIncomeByDay();
                    break;
                case 7:
                    ReportIncomeByMonth();
                    break;
                case 8:
                    ReportIncomeByYear();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddMedicine()
    {
        Console.WriteLine("Enter Medicine details:");

        Medicine newMedicine = new Medicine();

        Console.Write("Id: ");
        newMedicine.Id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        newMedicine.Name = Console.ReadLine();

        Console.Write("Indication: ");
        newMedicine.Indication = Console.ReadLine();

        Console.Write("Ingredients: ");
        newMedicine.Ingredients = Console.ReadLine();

        Console.Write("Description: ");
        newMedicine.Description = Console.ReadLine();

        Console.Write("Quantity: ");
        newMedicine.Quantity = int.Parse(Console.ReadLine());

        medicines.Add(newMedicine);
        Console.WriteLine("Medicine added successfully!");
    }

    static void UpdateMedicine()
    {
        Console.Write("Enter the Id of the medicine to update: ");
        int medicineId = int.Parse(Console.ReadLine());

        Medicine existingMedicine = medicines.FirstOrDefault(m => m.Id == medicineId);

        if (existingMedicine != null)
        {
            Console.WriteLine("Enter updated details:");

            Console.Write("Name: ");
            existingMedicine.Name = Console.ReadLine();

            Console.Write("Indication: ");
            existingMedicine.Indication = Console.ReadLine();

            Console.Write("Ingredients: ");
            existingMedicine.Ingredients = Console.ReadLine();

            Console.Write("Description: ");
            existingMedicine.Description = Console.ReadLine();

            Console.Write("Quantity: ");
            existingMedicine.Quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Medicine updated successfully!");
        }
        else
        {
            Console.WriteLine("Medicine not found!");
        }
    }

    static void DeleteMedicine()
    {
        Console.Write("Enter the Id of the medicine to delete: ");
        int medicineId = int.Parse(Console.ReadLine());

        Medicine medicineToDelete = medicines.FirstOrDefault(m => m.Id == medicineId);

        if (medicineToDelete != null)
        {
            medicines.Remove(medicineToDelete);
            Console.WriteLine("Medicine deleted successfully!");
        }
        else
        {
            Console.WriteLine("Medicine not found!");
        }
    }

    static void AddSale()
    {
        Console.WriteLine("Enter Sale details:");

        Sale newSale = new Sale();

        Console.Write("Id: ");
        newSale.Id = int.Parse(Console.ReadLine());

        Console.Write("Patient: ");
        newSale.Patient = Console.ReadLine();

        Console.Write("Doctor: ");
        newSale.Doctor = Console.ReadLine();

        Console.Write("Time (yyyy-MM-dd HH:mm): ");
        newSale.Time = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);

        Console.Write("Number of Medicines: ");
        int numMedicines = int.Parse(Console.ReadLine());

        newSale.Medicines = new List<Medicine>();
        newSale.Quantities = new List<int>();

        for (int i = 0; i < numMedicines; i++)
        {
            Console.Write($"Medicine {i + 1} Id: ");
            int medicineId = int.Parse(Console.ReadLine());

            Medicine medicine = medicines.FirstOrDefault(m => m.Id == medicineId);

            if (medicine != null)
            {
                newSale.Medicines.Add(medicine);

                Console.Write($"Quantity of Medicine {i + 1}: ");
                int quantity = int.Parse(Console.ReadLine());
                newSale.Quantities.Add(quantity);
            }
            else
            {
                Console.WriteLine($"Medicine with Id {medicineId} not found. Sale not added.");
                return;
            }
        }

        sales.Add(newSale);
        Console.WriteLine("Sale added successfully!");
    }

    static void ReportMedicineState()
    {
        Console.WriteLine("Medicine State Report:");

        foreach (var medicine in medicines)
        {
            Console.WriteLine($"Medicine Id: {medicine.Id}");
            Console.WriteLine($"Name: {medicine.Name}");
            Console.WriteLine($"Indication: {medicine.Indication}");
            Console.WriteLine($"Ingredients: {medicine.Ingredients}");
            Console.WriteLine($"Description: {medicine.Description}");
            Console.WriteLine($"Quantity: {medicine.Quantity}");
            Console.WriteLine("------------------------");
        }
    }

    static void ReportIncomeByDay()
    {
        Console.Write("Enter the day (yyyy-MM-dd): ");
        DateTime targetDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);

        double totalIncome = 0;

        foreach (var sale in sales.Where(s => s.Time.Date == targetDate.Date))
        {
            double saleTotal = CalculateSaleTotal(sale);
            totalIncome += saleTotal;
        }

        Console.WriteLine($"Total Income on {targetDate.ToShortDateString()}: ${totalIncome}");
    }

    static void ReportIncomeByMonth()
    {
        Console.Write("Enter the month (yyyy-MM): ");
        DateTime targetMonth = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM", null);

        double totalIncome = 0;

        foreach (var sale in sales.Where(s => s.Time.Month == targetMonth.Month && s.Time.Year == targetMonth.Year))
        {
            double saleTotal = CalculateSaleTotal(sale);
            totalIncome += saleTotal;
        }

        Console.WriteLine($"Total Income in {targetMonth.ToString("MMMM yyyy")}: ${totalIncome}");
    }

    static void ReportIncomeByYear()
    {
        Console.Write("Enter the year (yyyy): ");
        int targetYear = int.Parse(Console.ReadLine());

        double totalIncome = 0;

        foreach (var sale in sales.Where(s => s.Time.Year == targetYear))
        {
            double saleTotal = CalculateSaleTotal(sale);
            totalIncome += saleTotal;
        }

        Console.WriteLine($"Total Income in {targetYear}: ${totalIncome}");
    }

    static double CalculateSaleTotal(Sale sale)
    {
        double saleTotal = 0;

        for (int i = 0; i < sale.Medicines.Count; i++)
        {
            double medicineTotal = sale.Medicines[i].Quantity * sale.Quantities[i];
            saleTotal += medicineTotal;
        }

        return saleTotal;
    }
}

class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Indication { get; set; }
    public string Ingredients { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}

class Sale
{
    public int Id { get; set; }
    public string Patient { get; set; }
    public string Doctor { get; set; }
    public DateTime Time { get; set; }
    public List<Medicine> Medicines { get; set; }
    public List<int> Quantities { get; set; }
}

using System;
using System.Globalization;
using ProjetoPOO.Entities.Enums;
using ProjetoPOO.Entities;

namespace ProjetoPOO {
    class Program {
        static void Main(string[] args) {;
            Console.Write("Enter departament's name: ");
            string departament = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior;Mid Level, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dep = new Departament(departament);

            Worker worker = new Worker(name, baseSalary, level, dep);

            Console.Write("How many contracts to this worker? ");

            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i< n; i++) {
                Console.WriteLine($"Enter #{i + 1} contract data:");
                Console.Write("Date DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePH = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePH, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculete income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int mes = int.Parse(monthAndYear.Substring(0, 2));
            int ano = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthAndYear + " : " + worker.Income(ano, mes).ToString("F2",CultureInfo.InvariantCulture)) ;

        }
    }
}

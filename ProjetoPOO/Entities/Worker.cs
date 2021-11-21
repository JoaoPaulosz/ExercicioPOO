using System;
using System.Collections.Generic;
using System.Text;
using ProjetoPOO.Entities.Enums;

namespace ProjetoPOO.Entities {
    class Worker {
        public string Name { get; set; }
        public double BaseSalary { get; private set; }

        WorkerLevel Level { get; set; }

        public Departament Departament { get; set; }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(string name, double baseSalary, WorkerLevel level, Departament departament) {
            Name = name;
            BaseSalary = baseSalary;
            Level = level;
            Departament = departament;
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void Remove(HourContract contract) {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts) {
                if (contract.Date.Year == year && contract.Date.Month == month) {
                    sum += contract.TotalVelue();
                }
            }
            return sum;
        }
    }
}

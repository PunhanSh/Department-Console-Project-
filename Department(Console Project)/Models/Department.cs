using System;
using System.Collections.Generic;
using System.Text;

namespace Department_Console_Project_.Models
{
    class Department
    {
        private string _name;
        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                if (NameCheck(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
                }
            } 
        }
        private bool NameCheck(string Name)
        {
            if (Name.Length < 2)
            {
                return false;
            }
            foreach (char item in Name)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }


        private int _workerlimit;
        public int WorkerLimit 
        { 
            get
            {
                return _workerlimit;
            }
            set
            {
                if (value >= 1)
                {
                    _workerlimit = value;
                }
                else
                {
                    Console.WriteLine("Isci sayi minimum 1 ola biler");
                }
            }
        }
        private double _salarylimit;
        public double SalaryLimit 
        { 
            get
            {
                return _salarylimit;
            }
            set
            {
                if (value >= 250)
                {
                    _salarylimit = value;
                }
            }
        }
        public List<Employee> Employees { get; set; }
        public double CalcSalaryAverage()
        {
            double sum = 0;
            double average = 0;

            foreach (var item in Employees)
            {
                sum += item.Salary;
            }
            
            if (Employees.Count != 0)
            {
                average = sum / Employees.Count;
                return average;
            }

            else
            {
                return 0;
            }            
        }
    }
}

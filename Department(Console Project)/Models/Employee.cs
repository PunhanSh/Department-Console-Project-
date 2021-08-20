using System;
using System.Collections.Generic;
using System.Text;

namespace Department_Console_Project_.Models
{
    class Employee
    {
        private static int _counter = 1000;
        public string No { get; set; }
        public Employee()
        {
            _counter++;
            No = DepartmentName.Substring(0,2).ToUpper() + _counter;
        }
        
        public string Fullname { get; set; }

        private string _position;
        public string Position 
        { 
            get
            {
                return _position;
            }
            set
            {
                if (NameCheck(value))
                {
                    _position = value;
                }
                else
                {
                    Console.WriteLine("Isci vezifesi minimum 2 herfden ibaret olmalidir");
                }
            }
        }
        private bool NameCheck(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }
            foreach (char item in name)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }
        private double _salary;
        public double Salary 
        { 
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 250)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Iscinin maasi 250-den asagi ola bilmez");
                }
            }
        }
        public string DepartmentName { get; set; }
        public override string ToString()
        {
            return $"{No} {Fullname} {Position} {Salary} {DepartmentName}";
        }
    }
}

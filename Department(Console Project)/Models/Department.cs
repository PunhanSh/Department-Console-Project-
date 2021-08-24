using System;
using System.Collections.Generic;
using System.Text;

namespace Department_Console_Project_.Models
{
    class Department
    {
        #region Name (Departamentin adi)
        //Min iki herfden ibaret olmalidir
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
        #endregion

        #region NameCheck(Min 2 herf methodu)
        private bool NameCheck(string Name)
        {
            if (Name.Length < 2)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region WorkerLimit (Departmentdeki maximum isci sayi)
        //min 1 neffer ola biler
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
        #endregion

        #region SalaryLimit (Departmentdeki butun iscilere ayliq verilen max maas)
        //min 250 ola biler
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
                else
                {
                    Console.WriteLine("Iscilerin butun maasi minimum 250 ola biler");
                }
            }
        }
        #endregion

        #region Employees (Departamentdeki isci siyahisi)
        //departamente elave olunmus isci siyahisi
        private List<Employee> _employees { get; set; }
        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
        }
        #endregion        
        public Department() //Constructor 
        {
            _employees = new List<Employee>();
        }

        #region CalcSalaryAverage()
        //departmentdeki iscilerin ortalama maasini qaytaran method
        public double CalcSalaryAverage()
        {
            double sum = 0;
            double average = 0;

            foreach (var employee in Employees)
            {
                sum += employee.Salary;
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
        #endregion 
    }
}

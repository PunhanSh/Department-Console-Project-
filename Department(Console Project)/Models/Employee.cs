using System;
using System.Collections.Generic;
using System.Text;

namespace Department_Console_Project_.Models
{
    class Employee
    {
        #region No (iscinin nomresi)

        //Ilk iki herf departmentin ilk iki herfi, say ise 1000-den baslamalidir
        private static int _counter = 1000;
        public string No;
        public Employee()
        {
        }
        public Employee(string newdepartmentname) : this()
        {
            DepartmentName = newdepartmentname;
            _counter++;
            No = DepartmentName.Substring(0,2).ToUpper() + _counter;
        }
        #endregion

        #region Fullname (iscinin adi ve soyadi)
        public string Fullname;
        #endregion

        #region Position (iscinin vezifesi(min 2 herf ola biler))

        //Iscinin vezifesi en azi iki herfden ibaret olmalidir
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
        #endregion

        #region NameCheck Method
        //Iscinin vezifesin en azi iki herf olmasi ucun yazilan method
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
        #endregion

        #region Salary (iscinin maasi 250-den asagi ola bilmez)


        private int _salary;
        public int Salary 
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
        #endregion

        #region DepartmentName (iscinin elave olundugu department adi)
        public string DepartmentName;
        #endregion
        public override string ToString()//Override tostring methodu
        {
            return $"{No} {Fullname} {Position} {Salary} {DepartmentName}";
        }
    }
}

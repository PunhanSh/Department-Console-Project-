using System;
using System.Collections.Generic;
using System.Text;
using Department_Console_Project_.Models;

namespace Department_Console_Project_.Interfaces
{
    interface IHumanResourceManager 
    {
        //Departmentlerin siyahisini gosterir
        public List<Department> Departments { get;}

        //Department yaratmaq ucun method
        public void AddDepartment(Department department);

        //Sistemdeki butun departmentleri geriye qaytaran method 
        public List<Department> GetDepartments();        

        //Department uzerinde deyisiklik (departmentin adini deyisir) methodu
        public void  EditDepartments(string _name, Department department);

        //Isci yaratmaq ucun method(departmentin adi gonderilir)
        public void AddEmployee(Employee employee, string DepartmentName);

        //Iscinin nomresi ve department adini gondermekle silinmesi methodu
        public void RemoveEmployee(string no,string departmentName);

        //Iscinin parametrini deyismek methodu
        public void EditEmployee(string no, string fullName, int salary, string position, Employee employee);
    }
}

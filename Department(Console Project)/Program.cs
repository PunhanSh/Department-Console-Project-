using System;
using System.Collections;
using System.Text;
using Department_Console_Project_.Models;
using Department_Console_Project_.Services;
using Department_Console_Project_.Interfaces;


namespace Department_Console_Project_
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            Menu(humanResourceManager);
        }
        #region Menu
        static void Menu(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("Secim edin:\n~~~~~~~~~~");
                Console.WriteLine("1 - Departmentlerin siyahisini gostermek\n~~~~~~~~~~");
                Console.WriteLine("2 - Departament yaratmaq\n~~~~~~~~~~");
                Console.WriteLine("3 - Departamentde deyisiklik etmek\n~~~~~~~~~~");
                Console.WriteLine("4 - Iscilerin siyahisini gostermek\n~~~~~~~~~~");
                Console.WriteLine("5 - Departmentdeki iscilerin siyahisini gostermek\n~~~~~~~~~~");
                Console.WriteLine("6 - Isci elave etmek\n~~~~~~~~~~");
                Console.WriteLine("7 - Isci uzerinde deyisiklik etmek\n~~~~~~~~~~");
                Console.WriteLine("8 - Departamentden iscinin silinmesi\n~~~~~~~~~~");

                string choose1 = Console.ReadLine();
                int choose2;
                while (!int.TryParse(choose1, out choose2))
                {
                    Console.WriteLine("1-den 8-e qeder araliqda reqem secin");
                    choose1 = Console.ReadLine();
                    int.TryParse(choose1, out choose2);
                }
                switch (choose2)
                {
                    case 1:
                        ShowDepartmenstList(humanResourceManager);
                        break;
                    case 2:
                        CreateDepartment(humanResourceManager);
                        break;
                    case 3:
                        EditDepartment(humanResourceManager);
                        break;
                    case 4:
                        ShowEmployeesList(humanResourceManager);
                        break;
                    case 5:
                        ShowEmployeesListInDepartment(humanResourceManager);
                        break;
                    case 6:
                        AddEmployee(humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(humanResourceManager);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            while (true);
        }
        #endregion

        #region Departmentin siyahisini gostermek methodu
        static void ShowDepartmenstList(HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.Departments)
            {
              Console.WriteLine($"Departamentin Adi: {item.Name}\nDepartamentdeki iscinin sayi: {item.Employees.Count}\nDepartamentin ortalama maasi: {item.CalcSalaryAverage()}\n~~~~~~~~~~");                
            }        
             humanResourceManager.GetDepartments();
        }
        #endregion

        #region Departament yaratmaq methodu
        static void CreateDepartment(HumanResourceManager humanResourceManager)
        {
            Department department = new Department();
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Departmentin adini daxil edin...");
                string DepartName = Console.ReadLine();
                    while (!(DepartName.Length >= 2))
                    {
                    Console.WriteLine("Department adinda en azi iki herf olmalidir");
                    DepartName = Console.ReadLine();
                    }
                 Console.WriteLine("Departmentin isci limitini daxil edin...");
                string limit1 = Console.ReadLine();
                int workerlimit;

                while (!int.TryParse(limit1, out workerlimit) || workerlimit <= 0)
                {
                    Console.WriteLine("Departamentin isci limiti deyerini duzgun daxil edin (ISCI LIMITI 1-DEN AZ OLA BILMEZ)");
                    limit1 = Console.ReadLine();
                    int.TryParse(limit1, out workerlimit);
                }
                Console.WriteLine("Departamentin maas limitini daxil edin");

                string limit2 = Console.ReadLine();
                int salarylimit;

                while (!int.TryParse(limit2, out salarylimit) || salarylimit < 250) 
                {
                    Console.WriteLine("Departamentin maas limiti deyerini duzgun daxil edin(MAAS LIMITI 250-DEN ASAGI OLA BILMEZ)");
                    limit2 = Console.ReadLine();
                    int.TryParse(limit2, out salarylimit);
                }
                department.Name = DepartName;
                department.WorkerLimit = workerlimit;
                department.SalaryLimit = salarylimit;

                humanResourceManager.AddDepartment(department);
                Console.WriteLine("Departament elave edildi.\n~~~~~~~~~~");
                Console.WriteLine($"Departament Adi: {DepartName}\n~~~~~~~~~~\nDepartament Isci Limiti: {workerlimit}\n~~~~~~~~~~\nDepartament Maas Limiti: {salarylimit}\n~~~~~~~~~~\n");
                check = true;
            }
        }
        #endregion

        #region Department uzerinde deyisiklik etmek methodu

        static void EditDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Uzerinde deyisiklik etmek istediyiniz department adini daxil edin...");
            string name = Console.ReadLine();            

            Department department = humanResourceManager.Departments.Find(w => w.Name.ToUpper() == name.ToUpper());
            if (department == null)
            {
                Console.WriteLine("Daxil etdiyiniz adda department yoxdur...");
                Menu(humanResourceManager);
            }

            Console.WriteLine($"Departamentin adi: {department.Name}\nDepartamentin isci limiti: {department.WorkerLimit}\nDepartamentin maas limiti: {department.SalaryLimit}\n~~~~~~~~~~");
            Console.WriteLine("Departamentin yeni adini daxil edin:");
            string newname = Console.ReadLine();
            while (!(newname.Length >= 2))
            {
                Console.WriteLine("Department adinda en azi iki herf olmalidir");
                newname = Console.ReadLine();
            }

            Console.WriteLine("Departamentin yeni isci limitini daxil edin:");
            string newworkerlimit = Console.ReadLine();
            int newworkerlimit1;

            while (!int.TryParse(newworkerlimit, out newworkerlimit1) || newworkerlimit1 <= 0)
            {
                Console.WriteLine("Duzgun isci limiti deyeri daxil edin:");
                newworkerlimit = Console.ReadLine();
                int.TryParse(newworkerlimit, out newworkerlimit1);
            }

            Console.WriteLine("Departamentin yeni maas limitini daxil edin:");
            string newsalarylimit = Console.ReadLine();
            int newsalarylimit1;

            while (!int.TryParse(newsalarylimit, out newsalarylimit1) || newsalarylimit1 < 250)
            {
                Console.WriteLine("Duzgun maas limiti deyeri daxil edin:");
                newsalarylimit = Console.ReadLine();
                int.TryParse(newsalarylimit, out newsalarylimit1);
            }
            if (department.Name == newname && department.WorkerLimit == newworkerlimit1 && department.SalaryLimit == newsalarylimit1)
            {
                Console.WriteLine("Hec bir deyisiklik edilmedi.\n~~~~~~~~~~");
            }
            else
            {
                department.Name = newname;
                department.WorkerLimit = newworkerlimit1;
                department.SalaryLimit = newsalarylimit1;

                Console.WriteLine("Department parametrleri deyisdirildi.\n~~~~~~~~~~");
            }
            Console.WriteLine($"Departament Adi: { newname}\n~~~~~~~~~~\nDepartament Isci Limiti: { newworkerlimit1}\n~~~~~~~~~~\nDepartament Maas Limiti: { newsalarylimit1}\n~~~~~~~~~~\n");
        }
        #endregion

        #region Iscinin siyahisini gostermek methodu
        static void ShowEmployeesList(HumanResourceManager humanResourceManager)
        {
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                Department employeesindepartment = humanResourceManager.Departments[i];
                for (int j = 0; j < employeesindepartment.Employees.Count; j++)
                {
                    Console.WriteLine($"Isci nomresi: {employeesindepartment.Employees[j].No}\nIscinin adi ve soyadi: {employeesindepartment.Employees[j].Fullname}\nIscinin vezifesi: {employeesindepartment.Employees[j].Position}\nIscinin maasi: {employeesindepartment.Employees[j].Salary}");
                }
            }
        }
        #endregion

        #region Departmendeki iscilerin siyahisini gostermek methodu

        static void ShowEmployeesListInDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departmentin adini daxil edin");
            string departmentname = Console.ReadLine();

            Department departmentslist = humanResourceManager.Departments.Find(q => q.Name.ToUpper() == departmentname.ToUpper());

            if (departmentslist == null)
            {
                Console.WriteLine("Daxil etdiyiniz adda department adi yoxdur");
            }
            else
            {
                if (departmentslist.Employees.Count != 0)
                {
                    for (int i = 0; i < departmentslist.Employees.Count; i++)
                    {
                        Console.WriteLine($"Isci nomresi: {departmentslist.Employees[i].No}\nIscinin adi ve soyadi: {departmentslist.Employees[i].Fullname}\nIscinin vezifesi: {departmentslist.Employees[i].Position}\nIscinin maasi: {departmentslist.Employees[i].Salary}");
                    }
                }
                else
                {
                    Console.WriteLine($"{departmentname} departamentinde isci yoxdur");
                }
            }
        }
        #endregion

        #region Isci elave etmek methodu
        static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Iscinin nomresini daxil edin");
            string no = Console.ReadLine();
                       
            Console.WriteLine("Iscinin adi ve soyadini daxil edin");
            string fullname = Console.ReadLine();

            Console.WriteLine("Iscinin vezifesini daxil edin");
            string position = Console.ReadLine();

            Console.WriteLine("Iscinin maasini daxil edin");
            string salary = Console.ReadLine();
            int newsalary;
            while (!int.TryParse(salary, out newsalary) || newsalary < 250)
            {
                Console.WriteLine("Maasi duzgun daxil edin");
                salary = Console.ReadLine();
                int.TryParse(salary, out newsalary);
            }

            Console.WriteLine("Iscinin department adini daxil edin");
            string DepartmentName = Console.ReadLine();
            

            Department department = humanResourceManager.Departments.Find(w => w.Name.ToUpper() == DepartmentName.ToUpper());
            if (department == null)
            {
                Console.WriteLine("Daxil etdiyiniz adda department yoxdur...");
                Menu(humanResourceManager);
            }
            Employee newemployee = new Employee();
            newemployee.No = no;
            newemployee.Fullname = fullname;
            newemployee.Salary = newsalary;
            newemployee.Position = position;

            humanResourceManager.AddEmployee(newemployee, DepartmentName);
            Console.WriteLine("Isci elave edildi");
        }
        #endregion

        #region Isci uzerinde deyisiklikler etmek methodu
        static void EditEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Iscinin nomresini daxil edin");
            string employeeno = Console.ReadLine();
            bool check = false;
            string ename = " ";
            int esalary = 0;
            string eposition = " ";

            int x = 0;
            int y = 0;
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                for (int j = 0; j < humanResourceManager.Departments[i].Employees.Count; j++)
                {
                    if (employeeno == humanResourceManager.Departments[i].Employees[j].No)
                    {
                        check = true;
                        if (check)
                        {
                            ename = humanResourceManager.Departments[i].Employees[j].Fullname;
                            esalary = humanResourceManager.Departments[i].Employees[j].Salary;
                            eposition = humanResourceManager.Departments[i].Employees[j].Position;

                            x = i;
                            y = j;
                        }
                        else
                        {
                            Menu(humanResourceManager);
                        }
                    }
                }
            }
            if (check)
            {
                Console.WriteLine($"Iscinin adi ve soyadi: {ename}\nIscinin maasi:{esalary}\nIscinin vezifesi: {eposition} ");
                Console.WriteLine("Maasi daxil edin");
                string salary1 = Console.ReadLine();
                int salary2;
                while (!int.TryParse(salary1, out salary2))
                {
                    Console.WriteLine("Maasi DUZGUN daxil edin");
                    salary1 = Console.ReadLine();
                    int.TryParse(salary1, out salary2);
                }
                Console.WriteLine("Vezifeni daxil edin");
                string position1 = Console.ReadLine();

                humanResourceManager.Departments[x].Employees[y].Salary = salary2;
                humanResourceManager.Departments[x].Employees[y].Position = position1;
            }
            else
            {
                Menu(humanResourceManager);
            }
        }
        #endregion

        #region Isci silmek methodu
        static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Silmek istediyiniz iscinin departmentini daxil edin");
            string dname = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(p => p.Name == dname);

            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin");
            string eno = Console.ReadLine();
            if (department != null)
            {
                for (int i = 0; i < department.Employees.Count; i++)
                {
                    if (department.Employees[i].No == eno)
                    {
                        department.Employees.Remove(department.Employees[i]);
                        Console.WriteLine("Isci departmenden silindi");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz nomreli isci yoxdur");
                    }

                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz departament tapilmadi");
            }
        }
        #endregion
    }
}

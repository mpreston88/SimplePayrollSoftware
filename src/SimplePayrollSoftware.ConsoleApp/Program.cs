using System;
using SimplePayrollSoftware.ClassLib;
using System.Collections.Generic;


namespace SimplePayrollSoftware.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter the year as a number.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Please enter a month between 1 and 12.");
                        month = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter the month as a number.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
                {
                    Staff staff = myStaff[i];
                    try
                    {
                        Console.WriteLine("Enter hours worked for {0}: ", staff.NameOfStaff);
                        staff.HoursWorked = Convert.ToInt32(Console.ReadLine());

                        staff.CalculatePay();

                        Console.WriteLine(staff.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something went wrong.... Try entering hours worked as a number.");
                        Console.WriteLine(e.Message);
                        i--;
                    }
                }
            
            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }
}

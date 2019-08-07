using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SimplePayrollSoftware.ClassLib
{
    public class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear
        {
            JAN=1,
            FEB=2,
            MAR=3,
            APR=4,
            MAY=5,
            JUN=6,
            JUL=7,
            AUG=8,
            SEP=9,
            OCT=10,
            NOV=11,
            DEC=12
        }

        public PaySlip(int payMonth, int payYear){
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff){
            string path;

            foreach (Staff stf in myStaff)
            {
                path = stf.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path, false)){
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("===========================");
                    sw.WriteLine("Name of Staff: {0}", stf.NameOfStaff);
                    sw.WriteLine("Houra Worked: {0}", stf.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", stf.BasicPay);
                    if (sw.GetType() == typeof(Manager)){
                        sw.WriteLine("Allowance: {0}", ((Manager)stf).Allowance);
                    }
                    else if (sw.GetType() == typeof(Admin)){
                        sw.WriteLine(" Overtime Pay: {0}", ((Admin)stf).Overtime);
                    }
                    else {
                        continue;
                    }
                    sw.WriteLine("");
                    sw.WriteLine("===========================");
                    sw.WriteLine("Total Pay: {0}", stf.TotalPay);
                    sw.WriteLine("===========================");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff){
            var result = from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select staff ;

            string path = "summary.txt";
            using (StreamWriter sw=new StreamWriter(path, false)){
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach (Staff stf in result) {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", stf.NameOfStaff, stf.HoursWorked);
                }
                sw.Close();
            }
        }

        public override string ToString(){
            return "Month = " + month +
                   "Year = " + year;
        }
    }
}
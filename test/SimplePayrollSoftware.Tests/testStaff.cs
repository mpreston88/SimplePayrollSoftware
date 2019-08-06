using System;
using SimplePayrollSoftware.ClassLib; 
using Xunit;


namespace SimplePayrollSoftware.Tests
{
    public class TestStaff
    {
        [Fact]
        public void TestCalculatePayWithNoWorkedHours()
        {
            string name = "test";
            float rate = 8;
            Staff staff = new Staff(name, rate);

            staff.CalculatePay();

            Assert.Equal(0, staff.TotalPay);
        }

        [Fact]
        public void TestCalculatePayWithWorkedHours()
        {
            string name = "test";
            float rate = 8;
            Staff staff = new Staff(name, rate);
            staff.HoursWorked = 2;

            staff.CalculatePay();

            Assert.Equal(16, staff.TotalPay);
        }

        [Fact]
        public void TestToString()
        {
            string name = "test";
            float rate = 8;
            Staff staff = new Staff(name, rate);
            
            Assert.Contains("hourlyRate = 8", staff.ToString());
            Assert.Contains("NameOfStaff = test", staff.ToString());

        }

    }
}

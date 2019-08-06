using System;
using SimplePayrollSoftware.ClassLib; 
using Xunit;


namespace SimplePayrollSoftware.Tests
{
    public class TestAdmin
    {
        [Fact]
        public void TestCalculatePay()
        {
            string name = "test";
            Admin admin = new Admin(name);
            admin.HoursWorked = 161;

            admin.CalculatePay();

            Assert.Equal(4845.5F, admin.TotalPay);
        }

        [Fact]
        public void TestToString()
        {
            string name = "test";
            Admin admin = new Admin(name);

            Assert.Contains("Overtime = 0", admin.ToString());
        }

    }
}
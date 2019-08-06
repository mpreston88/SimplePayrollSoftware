using System;
using SimplePayrollSoftware.ClassLib; 
using Xunit;


namespace SimplePayrollSoftware.Tests
{
    public class TestManager
    {
        [Fact]
        public void TestCalculatePay()
        {
            string name = "test";
            Manager manager = new Manager(name);
            manager.HoursWorked = 161;

            manager.CalculatePay();

            Assert.Equal(9050, manager.TotalPay);
        }

        [Fact]
        public void TestToString()
        {
            string name = "test";
            Manager manager = new Manager(name );

            Assert.Contains("Allowance = 0", manager.ToString());
        }

    }
}

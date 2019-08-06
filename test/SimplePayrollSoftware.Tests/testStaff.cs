using System;
using SimplePayrollSoftware.ClassLib; 
using Xunit;


namespace SimplePayrollSoftware.Tests
{
    public class TestStaff
    {
        [Fact]
        public void TestCalculatePay()
        {
            string name = "test";
            float rate = 8;
            Staff staff = new Staff(name, rate);

            staff.CalculatePay();

            Assert.Equal(0, staff.BasicPay);
        }

        [Fact]
        public void TestToString()
        {
            string name = "test";
            float rate = 8;
            Staff staff = new Staff(name, rate);

            staff.CalculatePay();
            
            Assert.Contains("hourlyRate = 8", staff.ToString());
            Assert.Contains("NameOfStaff = test", staff.ToString());

        }

    }
}

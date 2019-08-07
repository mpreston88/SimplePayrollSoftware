namespace SimplePayrollSoftware.ClassLib
{
    public class Manager: Staff
    {
        private const float managerHourlyRate = 50;
        
        public int Allowance { get; private set; }
        
        public Manager(string name) : base(name, managerHourlyRate){
        }

        public override void CalculatePay(){
            base.CalculatePay();

            if (HoursWorked > 160){
                Allowance = 1000;
                TotalPay = TotalPay + Allowance;
            }
        }

        public override string ToString(){
            return 
            " TotalPay = " + TotalPay + 
            " BasicPay = " + BasicPay +
            " NameOfStaff = " + NameOfStaff +
            " Allowance = " + Allowance;
        }
    }
}
namespace SimplePayrollSoftware.ClassLib
{
    public class Admin : Staff
    {
        private const float adminHourlyRate = 30;
        private const float overtimeRate = 15.5F;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate){
        }

        public override void CalculatePay(){
            base.CalculatePay();
            if (HoursWorked > 160){
                Overtime = overtimeRate * (HoursWorked - 160);
                
                TotalPay = TotalPay + Overtime;
            }
        }

        public override string ToString(){
            return 
            " TotalPay = " + TotalPay + 
            " BasicPay = " + BasicPay +
            " NameOfStaff = " + NameOfStaff +
            " Overtime = " + Overtime;
        }

    }
}
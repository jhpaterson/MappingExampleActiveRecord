using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace MappingExample
{
    [ActiveRecord(DiscriminatorValue = "S         ")]
    public class SalariedEmployee : Employee
    {
        private int payGrade;

        [Property]
        public int PayGrade
        {
            get { return payGrade; }
            set { payGrade = value; }
        }

        public SalariedEmployee()
        {
        }

        public SalariedEmployee(string name,
                        string username,
                        string phoneNumber,
                        int payGrade) : 
                        base(name, username,phoneNumber)
        {
            this.payGrade = payGrade;
        }
    }
}

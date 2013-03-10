using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace MappingExample
{
    [ActiveRecord(DiscriminatorValue = "H         ")]
    public class HourlyPaidEmployee : Employee
    {
        public HourlyPaidEmployee()
        {
        }

        public HourlyPaidEmployee(string name,
                        string username,
                        string phoneNumber) : 
                        base(name, username,phoneNumber)
        {
        }
    }
}

using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using NHibernate.Criterion;


namespace MappingExample
{
    [ActiveRecord("Employees", 
        Lazy = true, 
        DiscriminatorColumn = "discriminator",
        DiscriminatorType = "String",
        DiscriminatorValue = "E         ")]                   // field is fixed length - should change the db!
    public class Employee : ActiveRecordBase<Employee>
    {
        protected int employeeID;
        protected string name;
        protected string username;
        protected string phoneNumber;
        protected Address address;

        [PrimaryKey]
        public virtual int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [Property]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Property]
        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Property]
        public virtual string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        [BelongsTo("addressID")]
        public virtual Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public Employee()
        {
        }

        public Employee(string name,
                        string username,
                        string phoneNumber)
        {
            this.name = name;
            this.username = username;
            this.phoneNumber = phoneNumber;
        }

        // additional query which uses base class method and Criterion
        public static Employee FindByUsername(string username)
        {
            return FindOne(Expression.Eq("Username", username));
        }

        // additional query which uses SimpleQuery to execute HQL
        public static Employee FindNewestEmployee()
        {
            SimpleQuery<Employee> q = new SimpleQuery<Employee>(
                @"from Employee e order by e.EmployeeID desc");

            return (Employee)q.Execute()[0];
        }
    }
}

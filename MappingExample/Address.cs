using System.Collections.Generic;
using Castle.ActiveRecord;

namespace MappingExample
{
    [ActiveRecord("Addresses",Lazy=true)]
    public class Address : ActiveRecordBase<Address>
    {
        private int addressID;
        private string propertyName;
        private int propertyNumber;
        private string postCode;
        private IList<Employee> employees;

        [PrimaryKey]
        public virtual int AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }
        
        [Property]
        public virtual string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        [Property]
        public virtual int PropertyNumber
        {
            get { return propertyNumber; }
            set { propertyNumber = value; }
        }

        [Property]
        public virtual string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        [HasMany(Table = "Employees", ColumnKey = "addressID", Inverse = true)]
        public virtual IList<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public Address()
        {
        }

        public Address(string propertyName,
                        int propertyNumber,
                        string postCode)
        {
            this.propertyName = propertyName;
            this.propertyNumber = propertyNumber;
            this.postCode = postCode;
        }
    }
}

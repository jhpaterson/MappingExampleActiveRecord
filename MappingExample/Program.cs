using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;


namespace MappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurationSource source = new XmlConfigurationSource("appconfig.xml");
            ActiveRecordStarter.Initialize(source, 
                typeof(Address),
                typeof(Employee),
                typeof(SalariedEmployee),
                typeof(HourlyPaidEmployee)
                );

            using (new SessionScope())     // need this for lazy loading to work
            {

                // query for Addresses
                Address add = Address.FindFirst();
                Console.WriteLine(add.AddressID);

                List<Address> addresses = Address.FindAll().ToList();

                foreach (Address ad in addresses)
                {
                    Console.WriteLine(ad.PropertyName);
                }

                // query for Employees
                Employee emp = Employee.FindByUsername("felipe");
                Console.WriteLine(emp.EmployeeID);

                Employee emp2 = Employee.FindNewestEmployee();
                Console.WriteLine(emp2.EmployeeID);

                List<Employee> employees = Employee.FindAll().ToList();

                foreach (Employee em in employees)
                {
                    Console.WriteLine(em.Name + ", " + em.Address.PropertyName);
                }
            }
            
            // wait for key press before ending
            Console.ReadLine();
        }
    }
}

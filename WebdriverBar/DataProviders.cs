using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzTests
{
    public class DataProviders
    {
        public static IEnumerable<Customer> ValidCustomers
        {
            get
            {
                yield return new Customer()
                {
                    login = "kotov2003@yahoo.com",
                    password = "529zM3"
                };
                //yield return new Customer()
                //{
                //    login = "kotov2005@yahoo.com",
                //    password = "529zM5"
                //};
            }
        }
    }
}

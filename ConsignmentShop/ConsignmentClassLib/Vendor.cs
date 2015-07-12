using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentClassLib
{
    public class Vendor
    {
        //(prop)
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public double Commission { get; set; }
        public decimal PaymentDue { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} - ${2}", FirstName, lastName, PaymentDue);
            }
        }

        //Constructor (ctor).  Runs when its first instantiated without parameters
        public Vendor()
        {
            Commission = .5;
        }

    }

}

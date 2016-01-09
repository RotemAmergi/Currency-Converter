using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject
{
    // Struct for currency
    class CurrencyStruct
    {
        private string name, currencyCode, country;
        private int unit;
        private double exRate, change;

        public CurrencyStruct(string Name, int Unit, string CurrencyCode, string Country, double Rate, double Change)
        {
            name = Name;
            unit = Unit;
            currencyCode = CurrencyCode;
            country = Country;
            exRate = Rate / Unit;
            change = Change;
        }

        public CurrencyStruct()
        {
            name = Name;
            unit = Unit;
            currencyCode = CurrencyCode;
            country = Country;
            exRate = Rate / Unit;
            change = Change;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public double Rate
        {
            get { return exRate; }
            set { exRate = value; }
        }

        public double Change
        {
            get { return change; }
            set { change = value; }
        }

        // implicit digit to byte conversion operator
        public static implicit operator double(CurrencyStruct cur)
        {
            return cur.exRate;
        }
        //Get all in to string 
        public string toString()
        {
            return "Currency: [Name=" + Name +
                ", Unit=" + Unit +
                ", CurrencyCode=" + CurrencyCode +
                ", Country=" + Country +
                ", Rate=" + Rate +
                ", Change=" + Change + '\n';
        }

    }
}

 

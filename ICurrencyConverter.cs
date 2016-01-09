using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;

namespace FinallProject
{
    interface ICurrencyConverter
    {
        // currency exchange rates from Bank Israeli REStful local xml file 
        void GetAllCurrencies(CurrenciesRequestHandler c);
        //Calculate the conversion from one currency to another
        double convert(CurrencyStruct a, CurrencyStruct b);
    }
}

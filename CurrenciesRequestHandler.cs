using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject
{
    //delegate 
     delegate void CurrenciesRequestHandler(CurrenciesRequestParams reqParams);
     class CurrenciesRequestParams
    {
        public Dictionary<string, CurrencyStruct> Currencies { get; private set; }
        //put the dictionary in Currencies
        public CurrenciesRequestParams(Dictionary<string, CurrencyStruct> dictionary) {
            Currencies = dictionary;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Windows;

namespace FinallProject
{
    class CurrencyConverter : ICurrencyConverter
    {
        public void GetAllCurrencies(CurrenciesRequestHandler currenciesRequestHandler)
        {
            //creat a new dictionary that get the Currency Struct
            Dictionary<String, CurrencyStruct> dictionary = new Dictionary<String, CurrencyStruct>();
            XDocument filexml = new XDocument();
            
            try
            {
                //
                filexml = XDocument.Load("D:\\visual works\\finallproject\\finallproject\\bin\\Debug\\currency.xml");
            }
            catch (IOException)
            {
                MessageBox.Show("File not found in the specified path" + '\n');
                
            }

            try
            {
                // Linq is being used to get attributes
                // Convert XML to LINQ
                XElement currenciesNode = filexml.Element("CURRENCIES");

                var allCurrenciesQuery = from currency in currenciesNode.Elements("CURRENCY")
                                         select currency;

                foreach (var currency in allCurrenciesQuery)
                {
                    // Create a curreny rates dictionary
                    CurrencyStruct c = new CurrencyStruct();
                    c.Name = currency.Element("NAME").Value;
                    c.Unit = int.Parse(currency.Element("UNIT").Value);
                    c.CurrencyCode = currency.Element("CURRENCYCODE").Value;
                    c.Country = currency.Element("COUNTRY").Value;
                    c.Rate = double.Parse(currency.Element("RATE").Value);
                    c.Change = double.Parse(currency.Element("CHANGE").Value);
                    //this the key that we use for search 
                    dictionary.Add(c.Country + c.Name, c);
                }
                CurrencyStruct isr=new  CurrencyStruct("NIS", 1, "ISR", "Israel", 1, 0);
                dictionary.Add(isr.Country+isr.Name,isr);
            }
            catch (Exception e)
            {
                Console.Write("Failed to parse XML file", e.ToString());
            }
            currenciesRequestHandler(new CurrenciesRequestParams(dictionary));
        }
  
        // Calculate the conversion from one currency to another
        public double convert(CurrencyStruct a, CurrencyStruct b)
        {
            return (a / b);
        }
    }
}
        


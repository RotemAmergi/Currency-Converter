using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Threading;



namespace FinallProject
{
    class Program
    {
        static Dictionary<String, CurrencyStruct> dictionary;
        // creat new Currency Converter 
        static CurrencyConverter cf = new CurrencyConverter();
        static double sum1, sum2;
        static void Main(string[] args)
        {
            int operation;
            int currency, currency2;
            double amount;
            
            double ConversionSumF;
            //creat Thread for ReadFromXml func  that read from the web file and save it local 
            Thread t1 = new Thread(new ThreadStart(ReadFromXml));
            t1.Start();
            Thread.Sleep(2000);
            //call for delegate 
            cf.GetAllCurrencies(new CurrenciesRequestHandler(RequestHander)); 
            for (; ;)//user consol gui
            {
                Console.Write("Hi and welcom for the currency calculator " + '\n');
                Console.Write("1.Print the Xml file from the local folder" + '\n');
                Console.Write("2.Examples of currency conversion" + '\n');
                Console.Write("3.Exchange between currency " + '\n');
                Console.Write("4.For exit" + '\n');
                operation = Int32.Parse(Console.ReadLine());
                switch (operation)//switch cases operation 
                {
                    case 1:
                        Console.Clear();//Clear the consol
                        //its print the all xml file
                        XElement currencyFromFile = XElement.Load("D:\\visual works\\finallproject\\finallproject\\bin\\Debug\\currency.xml");
                        Console.WriteLine(currencyFromFile);
                        break;
                    case 2:
                        Console.Clear();//Clear the consol
                        //Examples of currency conversion
                        Console.WriteLine("Examples of currency conversion :");
                        Console.WriteLine('\n' + "conversion rate between Dollar and Pound (GB): " + cf.convert(dictionary["USADollar"], dictionary["Great BritainPound"]) + '\n'
                        + "conversion rate between Yen and Euro : " + cf.convert(dictionary["JapanYen"], dictionary["EMUEuro"]) + '\n'
                        + "conversion rate between Krone and Rand : " + cf.convert(dictionary["NorwayKrone"], dictionary["South AfricaRand"]) + '\n');
                        break;
                    case 3:
                        {//Exchange between currency
                            Console.Clear();//Clear the consol
                            Console.Write("The first currency are : " + '\n');
                            Console.Write("1.Dollar - USD" + '\n' + "2.Pound" + '\n' + "3.Yen" + '\n' + "4.Euro" + '\n'
                                 + "5.Dollar-Australia" + '\n' + "6.Dollar - Canada" + '\n' + "7.krone -Denmark" + '\n' + "8.Krone - Norway" +
                                 '\n' + "9.Rand" + '\n' + "10.Krona - Sweden" + '\n' + "11.Franc" + '\n' + "12.Dinar" + '\n'
                                 + "13.Pound -Lebanon" + '\n' + "14.Pound -Egypt" + '\n' + "15.ISR" + '\n');
                            currency = Int32.Parse(Console.ReadLine());//get the first currency 
                            Console.Write("How much you would like to convert : " + '\n');
                            amount = float.Parse(Console.ReadLine());//get the amount 
                            Console.Write("The second currency are : " + '\n');
                            Console.Write("1.Dollar - USD" + '\n' + "2.Pound" + '\n' + "3.Yen" + '\n' + "4.Euro" + '\n'
                                + "5.Dollar-Australia" + '\n' + "6.Dollar - Canada" + '\n' + "7.krone -Denmark" + '\n' + "8.Krone - Norway" +
                                '\n' + "9.Rand" + '\n' + "10.Krona - Sweden" + '\n' + "11.Franc" + '\n' + "12.Dinar" + '\n'
                                + "13.Pound -Lebanon" + '\n' + "14.Pound -Egypt" + '\n' + "15.ISR" + '\n');
                            currency2 = Int32.Parse(Console.ReadLine());//get the second currency
                            switch (currency)//get the first currency 
                            {
                                case 1://USA Dollar currency
                                    sum1=cf.convert(dictionary["USADollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 2://Great Britain Pound currency
                                    sum1 = cf.convert(dictionary["Great BritainPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 3://Japan Yen currency
                                    sum1 = cf.convert(dictionary["JapanYen"], dictionary["IsraelNIS"]);
                                    break;
                                case 4://EMU Euro currency
                                    sum1 = cf.convert(dictionary["EMUEuro"], dictionary["IsraelNIS"]);
                                    break;
                                case 5://Australia Dollar currency
                                    sum1 = cf.convert(dictionary["AustraliaDollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 6://Canada Dollar currency
                                    sum1 = cf.convert(dictionary["CanadaDollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 7: //Denmark krone currency
                                    sum1 = cf.convert(dictionary["Denmarkkrone"], dictionary["IsraelNIS"]);
                                    break;
                                case 8://Norway Krone currency
                                    sum1 = cf.convert(dictionary["NorwayKrone"], dictionary["IsraelNIS"]);
                                    break;
                                case 9://South Africa Rand currency
                                    sum1 = cf.convert(dictionary["South AfricaRand"], dictionary["IsraelNIS"]);
                                    break;
                                case 10://Sweden Krona currency
                                    sum1 = cf.convert(dictionary["SwedenKrona"], dictionary["IsraelNIS"]);
                                    break;
                                case 11://Switzerland Franc currency
                                    sum1 = cf.convert(dictionary["SwitzerlandFranc"], dictionary["IsraelNIS"]);
                                    break;
                                case 12://Jordan Dinar currency
                                    sum1 = cf.convert(dictionary["JordanDinar"], dictionary["IsraelNIS"]);
                                    break;
                                case 13://Lebanon Pound currency
                                    sum1 = cf.convert(dictionary["LebanonPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 14://Egypt Pound currency
                                    sum1 = cf.convert(dictionary["EgyptPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 15://Israel NIS currency
                                    sum1 = cf.convert(dictionary["IsraelNIS"], dictionary["IsraelNIS"]);
                                    break;
                            }

                            switch (currency2)//get the second currency
                            {
                                case 1://USA Dollar currency
                                    sum2 = cf.convert(dictionary["USADollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 2://Great Britain Pound currency
                                    sum2 = cf.convert(dictionary["Great BritainPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 3://Japan Yen currency
                                    sum2 = cf.convert(dictionary["JapanYen"], dictionary["IsraelNIS"]);
                                    break;
                                case 4://EMU Euro currency
                                    sum2 = cf.convert(dictionary["EMUEuro"], dictionary["IsraelNIS"]);
                                    break;
                                case 5://Australia Dollar currency
                                    sum2 = cf.convert(dictionary["AustraliaDollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 6://Canada Dollar currency
                                    sum2 = cf.convert(dictionary["CanadaDollar"], dictionary["IsraelNIS"]);
                                    break;
                                case 7://Denmark krone currency
                                    sum2 = cf.convert(dictionary["Denmarkkrone"], dictionary["IsraelNIS"]);
                                    break;
                                case 8://Norway Krone currency
                                    sum2 = cf.convert(dictionary["NorwayKrone"], dictionary["IsraelNIS"]);
                                    break;
                                case 9://South Africa Rand currency
                                    sum2 = cf.convert(dictionary["South AfricaRand"], dictionary["IsraelNIS"]);
                                    break;
                                case 10://Sweden Krona currency
                                    sum2 = cf.convert(dictionary["SwedenKrona"], dictionary["IsraelNIS"]);
                                    break;
                                case 11://Switzerland Franc currency
                                    sum2 = cf.convert(dictionary["SwitzerlandFranc"], dictionary["IsraelNIS"]);
                                    break;
                                case 12://Jordan Dinar currency
                                    sum2 = cf.convert(dictionary["JordanDinar"], dictionary["IsraelNIS"]);
                                    break;
                                case 13://Lebanon Pound currency
                                    sum2 = cf.convert(dictionary["LebanonPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 14://Egypt Pound currency
                                    sum2 = cf.convert(dictionary["EgyptPound"], dictionary["IsraelNIS"]);
                                    break;
                                case 15://Israel NIS currency
                                    {
                                        sum2 = cf.convert(dictionary["IsraelNIS"], dictionary["IsraelNIS"]);
                                        break;
                                    }


                            }//call to Conversion beetwin currency that the user put in 
                            ConversionSumF = Conversion(sum1, sum2, amount);
                            Console.WriteLine("The Conversion Sum are : " + ConversionSumF + '\n');
                            break;
                        }
                     case 4://case for exit 
                        Console.Clear();
                        Console.WriteLine("Have a good day ");                 
                         return ;
                    
                        
                }
            
                
            }
            
            
        }

        public static void ReadFromXml()
        {
            XElement filexml;
            try
            {
                //  connects to the web and load the page 
                filexml = XElement.Load("http://www.boi.org.il/currency.xml");
                IEnumerable<XElement> CURRENCIES = filexml.Elements();

                // Read the entire XML and save it in a local specified path
                foreach (var CURRENCY in CURRENCIES)
                {
                  filexml.Save("currency.xml");

                }
            }
            // if we don't have a connection for internet
            catch (WebException)
            {
                Console.Write("Failed to load currency rates XML from web service - Communication problem with the internet - no connection." + '\n' + '\n');

            }
            
        }

        static void RequestHander(CurrenciesRequestParams reqParams)
        {   //The Dictionary of the currency
            Console.Write("The Dictionary of the currency is: " + '\n' + '\n');
            dictionary = reqParams.Currencies;
            foreach (CurrencyStruct c in dictionary.Values)
            {   //its print the all Dictionary
                Console.WriteLine(c.toString());
            }
            
        }
        //Func for Conversion beetwin currency that the user put in 
        static double Conversion (double cur1,double cur2, double amount)
        {
            double ConversionSum;
            ConversionSum = ((cur1 * amount) / cur2);
            //Console.WriteLine("we are in ConversionSum ");
            return ConversionSum;

        }
    }
}
 

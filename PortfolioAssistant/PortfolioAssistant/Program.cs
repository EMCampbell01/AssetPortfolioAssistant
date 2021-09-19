using System;
using System.Collections;
using HtmlAgilityPack;

namespace PortfolioAssistant
{
    class Program
    {
        static void Main(string[] args)
        {

            //User Menu
            Console.WriteLine(" *** Portfolio-Assistant : V1 *** ");
            Console.WriteLine("Select one of the following modes, ");
            Console.WriteLine("Growth Calculators - ");
            Console.WriteLine("1 - Investment Growth Calculator");
            Console.WriteLine("2 - Intrinsic Value Calculator");
            Console.WriteLine("3 - Portfolio");

            //User Mode Selection
            string input = Console.ReadLine();
            int mode = Int32.Parse(input);

            if(mode == 1)
            {
                Console.WriteLine(" *** Investment Growth Calculator *** ");

                //Set variables from user input
                Console.WriteLine("Enter Inital Value : ");                  //inital investment amount set on day 0
                double inital_value = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Anual Growth % : ");                //% growth of investment per year
                double anual_growth = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Duration (Years) : ");
                int duration = Int32.Parse(Console.ReadLine());              //number of years investment grows
                Console.WriteLine("Enter Anual Contribution : ");
                double anual_contribution = Int32.Parse(Console.ReadLine()); //yearly additional deposit amount

                //Generate & Display Results
                Console.WriteLine(" *** ANUAL GROWTH BREAKDOWN *** ");
                Console.WriteLine("   YEAR   | INVESTED |  TOTAL  |");
                CompoundCalc.Compound(inital_value, anual_growth, duration, anual_contribution);
            }

            if(mode == 2)
            {
                Console.WriteLine(" *** Intrinsic Value Calculator *** ");

                Console.WriteLine("Enter Asset Ticker : ");
                string ticker = Console.ReadLine();
                Console.WriteLine("Enter Asset Market : ");
                string market = Console.ReadLine();
                Console.WriteLine("Enter Growth Rate : ");
                double growth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Holding Period (Years) : ");
                int duration = Int32.Parse(Console.ReadLine());

                Asset asset = new Asset();
                asset.ticker = ticker;
                asset.market = market;
                asset.GetData();
                asset.GetFairValue(growth, duration);

            }

            ArrayList portfolio = new ArrayList();
            portfolio = BuildPortfolio(); 

            Console.WriteLine("Portfolio Holdings:");
            foreach(PortfolioAsset asset in portfolio)
            {
                Console.WriteLine(asset.quantity + " shares of " + asset.ticker);
            }
         
        }
    }
}

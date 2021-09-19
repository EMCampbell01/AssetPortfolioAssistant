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
            Console.WriteLine("3 - Portfolio Builder");

            //User Mode Selection
            string input = Console.ReadLine();
            int mode = Int32.Parse(input);

            /*
             * Mode 1 - Investment Growth Calculator
             * The investment growth calculator applys compunding anual growth to an investment
             * Optionally additional anual contributions can be added to the investment
             * Users specify a starting sum, the anual growth %, the duration of investment, and anual contribution amount
             * The Compound Method is used to return and display the yearly results of the investment
             */
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
            /*
             * Mode 2 - Intrinsic Value Calculator
             * The intrinsic value calculator generates an estimated fair value of an asset using live data and a growth estimate 
             * User specifies a asset, estimated anual growth %, and the holding duration 
             * Live data is scraped from Google Finance using the GetData method
             * The calculated fair value is returned and output using the GetFairValue Method
             */
            if(mode == 2)
            {
                Console.WriteLine(" *** Intrinsic Value Calculator *** ");

                //Take user input, stock identifiers + investment assumptions
                Console.WriteLine("Enter Asset Ticker : ");
                string ticker = Console.ReadLine();
                Console.WriteLine("Enter Asset Market : ");
                string market = Console.ReadLine();
                Console.WriteLine("Enter Growth Rate : ");
                double growth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Holding Period (Years) : ");
                int duration = Int32.Parse(Console.ReadLine());

                //Generate asset object, set identifers, scrape finacials, output result
                Asset asset = new Asset();
                asset.ticker = ticker;
                asset.market = market;
                asset.GetData();
                asset.GetFairValue(growth, duration);

            }
            /*
             * Mode 3 - Portfolio Builder
             * User can create a portfolio of assets
             * 
             * 
             * 
             * 
             */
            if(mode == 3)
            {
                Console.WriteLine(" *** Portfolio Builder *** ");
                Portfolio user_portfolio = new Portfolio();

                //Build Portfolio
                while(true)
                {
                    PortfolioAsset new_asset = new PortfolioAsset();

                    Console.WriteLine("Enter Asset ticker: ");
                    new_asset.ticker = Console.ReadLine();
                    if (String.IsNullOrEmpty(new_asset.ticker))
                    {
                        break;
                    }
                    Console.WriteLine("Enter Market: ");
                    new_asset.market = Console.ReadLine();
                    Console.WriteLine("Enter Quanity: ");
                    new_asset.quantity = Int32.Parse((Console.ReadLine()));

                    user_portfolio.holdings.Add(new_asset);
                }

                //Display Portfolio Data
                Console.WriteLine("Portfolio Holdings:");
                foreach (PortfolioAsset asset in user_portfolio.holdings)
                {
                    Console.WriteLine(asset.quantity + " shares of " + asset.ticker);
                }
            }      
        }
    }
}

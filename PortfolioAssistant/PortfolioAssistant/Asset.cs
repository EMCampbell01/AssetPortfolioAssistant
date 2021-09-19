using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace PortfolioAssistant
{
    //The asset class represents a financial asset
    //Contains asset financials 
    //Contains GetData method which webscrapes live data from Google Finance
    class Asset
    {
        public string ticker;
        public string market;
        public string share_price;
        public string pe;
        public string eps;

        public void GetData()
        {
            HtmlWeb web = new HtmlWeb();
            string url = ("https://www.google.com/finance/quote/" + ticker + ":" + market);
            HtmlDocument doc = web.Load(url);
            var div_nodes = doc.DocumentNode.Descendants("div");
            var td_nodes = doc.DocumentNode.Descendants("td");

            int i = 0;
            foreach (var div in div_nodes)
            {
                if (div.GetAttributeValue("class", "").Contains("YMlKec fxKbKc"))
                {
                    share_price = (div.InnerHtml);
                }


                if (div.GetAttributeValue("class", "").Contains("P6K39c"))
                {
                    if (i == 5)
                    {
                        pe = (div.InnerHtml);
                    }
                    i++;
                }
            }

            i = 0;
            foreach (var td in td_nodes)
            {
                if (td.GetAttributeValue("class", "").Contains("QXDnM"))
                {
                    if (i == 2)
                    {
                        eps = (td.InnerHtml);
                    }
                    i++;
                }
            }
        }

        public double GetFairValue(double growth, int duration)
        {
            double projected_eps = Convert.ToDouble(eps);

            Console.WriteLine(eps);
            Console.WriteLine(pe);

            int y = 0;
            while(y < duration - 1)
            {
                projected_eps = projected_eps * (1 + growth / 100);
                Console.WriteLine(projected_eps);
                y++;
            }

            double future_price = projected_eps * Convert.ToDouble(pe);
            Console.WriteLine(future_price);
            double fair_value = future_price;

            while(y > 0)
            {
                fair_value = fair_value * (1 - growth / 100);
                Console.WriteLine(fair_value);
                y = y -1;
            }

            Console.WriteLine("Intrinsic Value of " + ticker + " = " + fair_value);
            return fair_value;
        }
    }

    //PortfolioAsset represents a financial asset which is within a portfolio
    class PortfolioAsset : Asset
    {
        public int quantity;
        float value;
        float growth_est;
    }
}

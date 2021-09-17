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
    }

    //PortfolioAsset represents a financial asset which is within a portfolio
    class PortfolioAsset : Asset
    {
        public int quantity;
        float value;
        float growth_est;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAssistant
{
    public static class CompoundCalc
    {
        /*
         * Compund calculates, displays and returns the anual growth of an investment
         * Parametrs : 
         * inital       = starting value of investment at year 0
         * growth       = anual intrest earned on investment
         * duration     = lifespan of investment (years)
         * contribution = value of anual investment contribution added
         * Method raturns yearly value of investment
         */
        public static ArrayList Compound(double initial, double growth, int duration, double contribution)
        {
            ArrayList value_list = new ArrayList();

            int current_year = 0;
            double current_value = initial;

            double total_invested = initial; //total value of all investment deposits
            double total_gain = 0;           //total value of interest earned on investment

            while(current_year < duration)
            {
                current_value = current_value * (1 + growth / 100);

                current_year++;
        
                value_list.Add(current_value);

                Console.WriteLine("   " + current_year + "         " + total_invested + "         " + current_value);

                current_value += contribution;
                total_invested += contribution;
                total_gain = current_value - total_invested;

            }
            
            return value_list;
        }
    }
}

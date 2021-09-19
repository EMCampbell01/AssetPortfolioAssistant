using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAssistant
{
    public static class CompoundCalc
    {
        public static ArrayList Compound(double initial, double growth, int duration, double contribution)
        {
            ArrayList value_list = new ArrayList();

            int current_year = 0;
            double current_value = initial;

            double total_invested = initial;
            double total_gain = 0;

            while(current_year < duration)
            {
                current_value = current_value * (1 + growth / 100);

                current_year++;
        
                value_list.Add(current_value);

                Console.WriteLine("   " + current_year + "         " + total_invested + "         " + current_value);

                current_value += contribution;
                total_invested += contribution;

            }
            
            return value_list;
        }
    }
}

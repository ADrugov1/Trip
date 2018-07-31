﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            var trips = new List<Tour>()
            {
                new Tour("Melbourne","Cologne"),
                new Tour("Moscow","Paris"),
                new Tour("Cologne","Moscow")
  
            };
            var result = new Converter().TourListToChain(trips);

            Console.Write(result[0]);

            for (var i = 1; i < result.Count(); i++)
            { 
                Console.Write(" -> " + result[i]);
            }
            Console.ReadLine();
        }
    }
}

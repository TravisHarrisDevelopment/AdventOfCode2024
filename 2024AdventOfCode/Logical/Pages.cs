using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode.Logical
{
    public class Pages
    {
        public List<string> PagesToProduce { get; set; } = new List<string>();

        public Pages(string input) 
        {
            if(input == "" || input.Contains('|'))
            {
                throw new ArgumentException("input should be list of comma separated values.");
            }

            PagesToProduce = input.Split(',').ToList();
        }
    }
}

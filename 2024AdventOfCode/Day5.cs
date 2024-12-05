using _2024AdventOfCode.Logical;
using _2024AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode
{
    public class Day5 : IDay
    {
        private readonly string _input;

        public List<BasicOrderingRule> BasicRules { get; set; } = new List<BasicOrderingRule>();

        public List<Pages> PageGroups { get; set; } = new List<Pages>();
        //public string AssembledRule { get; set; } 

        public Day5(string input) {
            if (input == null || input == "")
            {
                throw new ArgumentNullException("input");
            }

            _input = input;
            var rawInput = InputHelper.GetInput(input);
            int split=0;
            for(int i = 0; i< rawInput.Length; i++)
            {
                if (rawInput[i] == "")
                {
                    split = i;
                    break;
                }
            }
            BasicRules = ExtractRules(rawInput.Take(split).ToArray());
            PageGroups = ExtractPages(rawInput.Skip(split).ToArray());
        }

        public List<Pages> ExtractPages(string[] strings)
        {
            throw new NotImplementedException();
        }

        public List<BasicOrderingRule> ExtractRules(string[] rawInput)
        {
            List<BasicOrderingRule> rules = new List<BasicOrderingRule>();
            int i = 0;
            while (rawInput[i] != "")
            {
                if (rawInput[i].Contains('|'))
                {
                    rules.Add(new BasicOrderingRule(rawInput[i]));
                }
                i++;
            }
            return rules;
        }

        public string RunFirst()
        {
            return BasicRules[0].ToString();

        }

        public string RunSecond()
        {
            throw new NotImplementedException();
        }
    }
}

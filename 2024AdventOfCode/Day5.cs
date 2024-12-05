using _2024AdventOfCode.Logical;
using _2024AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2024AdventOfCode
{
    public class Day5 : IDay
    {
        private readonly string _input;

        public List<BasicOrderingRule> BasicRules { get; set; } = new List<BasicOrderingRule>();

        public List<Pages> PageGroups { get; set; } = new List<Pages>();

        public List<Pages> ValidatedGroups { get; set; } = new List<Pages>();

        public List<Pages> BadGroups { get; set; } = new List<Pages>();
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
            PageGroups = ExtractPages(rawInput.Skip(split+1).ToArray());

            ValidatedGroups = ValidatePageGroups();

        }

        private int CenterSum(List<Pages> validatedGroups)
        {
            var sum = 0;

            foreach(var group in validatedGroups)
            {
                var count = group.PagesToProduce.Count();
                var middleIndex = (count / 2) ; //since this is zero-indexed it works out
                sum += int.Parse(group.PagesToProduce[middleIndex]);
            }
            return sum;
        }

        public List<Pages> ValidatePageGroups()
        {
            var validated = new List<Pages>();

            foreach (var group in PageGroups)
            {
                bool valid = true;
                foreach (var rule in BasicRules)
                {
                    int earlyIndex = group.PagesToProduce.IndexOf(rule.EarlyValue);
                    int laterIndex = group.PagesToProduce.IndexOf(rule.LaterValue);
                    if (earlyIndex != -1 && laterIndex != -1 && earlyIndex > laterIndex)
                    {
                        valid = false;
                        BadGroups.Add(group);
                        break;
                    }
                }
                if (valid)
                {
                    validated.Add(group);
                }
            }
            return validated;
        }

        public List<Pages> ExtractPages(string[] strings)
        {
            List<Pages> pages = new List<Pages>();
            foreach (string s in strings)
            {
                pages.Add(new Pages(s));
            }

            return pages;
        }

        public List<BasicOrderingRule> ExtractRules(string[] rawInput)
        {
            List<BasicOrderingRule> rules = new List<BasicOrderingRule>();

            foreach(string s in rawInput) 
            {

                rules.Add(new BasicOrderingRule(s));
            }
            return rules;
        }

        public string RunFirst()
        {
            int sum = CenterSum(ValidatedGroups);
            return $"Sum of middle page numbers is {sum}.";

        }

        public string RunSecond()
        {
            BadGroups = ApplyRules(BadGroups);
            int sum = CenterSum(BadGroups);
            return $"Sum of middle page numbers is {sum}.";
        }

        private List<Pages> ApplyRules(List<Pages> badGroups)
        {
            Debug.Write($"first group of pages presub: {string.Join(",", badGroups[0].PagesToProduce)}\n");
            foreach (var group in badGroups)
            {
                var p = group.PagesToProduce;
                var touched = false;
                
                do
                {
                    touched = false;
                    foreach (var rule in BasicRules)
                    {
                        
                        int earlyIndex = p.IndexOf(rule.EarlyValue);
                        int laterIndex = p.IndexOf(rule.LaterValue);
                        if (earlyIndex >= 0 && laterIndex >= 0 && earlyIndex > laterIndex)
                        {
                            p = ApplyRule(p, earlyIndex, laterIndex);
                            touched = true;
                        }
                    }
                } while (touched);
            }
            Debug.Write($"first group of pages postsub: {string.Join(",", badGroups[0].PagesToProduce)}\n");
            return badGroups;
        }

        private List<string> ApplyRule(List<string> pages, int early, int late)
        {
            var move = pages[early];
            pages.RemoveAt(early);
            pages.Insert(late, move);
            return pages;
        }
    }
}

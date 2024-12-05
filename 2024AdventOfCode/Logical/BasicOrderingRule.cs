using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode.Logical
{
    public class BasicOrderingRule
    {
        public string EarlyValue { get; set; }
        public string LaterValue { get; set; }
        public BasicOrderingRule(string rule) 
        {
            if (!(rule.Contains('|')))
            {
                throw new ArgumentException("must contain '|'");
            }

            EarlyValue = rule.Substring(0, rule.IndexOf('|'));
            LaterValue = rule.Substring(rule.IndexOf('|') + 1);
        }

        public override string ToString()
        {
            return $"{EarlyValue} before {LaterValue}";
        }
    }
}

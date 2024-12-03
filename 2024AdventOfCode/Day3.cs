using _2024AdventOfCode.Logical;
using _2024AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2024AdventOfCode
{
    public class Day3 : IDay
    {
        private readonly string _input;

        public List<string> CorrputedInstructions { get; set; }
        public List<Mul> ValidInstructions { get; set; } = new List<Mul>();

        public Day3(string input) {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            _input = input;

            CorrputedInstructions = InputHelper.GetInput(_input).ToList();
        }
        //input example:  xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
        //is actually:  mul(2,4) mul(5,5) mul(11,8) mul(8,5)
        // max instruction is 12 chars mul(111,111)
        //                             012345678901  
        public string RunFirst()
        {
            foreach (var instr in CorrputedInstructions)
            {
                ExtractUsingRegex(instr);
            }
            //foreach (var instr in CorrputedInstructions)
            //{
            //    ExtractValidInstructions(instr);
            //}
            
            long sum = 0;
            foreach (var mul in ValidInstructions)
            {
                sum += mul.Product;
            }
            return $"Result = {sum}.";
        }

        public void ExtractUsingRegex(string instruction)
        {
            var regex = @"mul\(\d{1,3},\d{1,3}\)";
            Regex rg = new Regex(regex);
            MatchCollection matches = rg.Matches(instruction);
            foreach(var match in matches)
            {
                var text = match.ToString();
                int commaIndex = text.IndexOf(',');
                int num1 = int.Parse(text.Substring(4, commaIndex-4));
                int num2 = int.Parse(text.Substring(text.IndexOf(',') + 1, (text.Length - 1)-(commaIndex+1)));
                ValidInstructions.Add(new Mul(num1, num2));
            }
        }

        private void ExtractValidInstructions(string instruction)
        {
            if (instruction.Contains(',') && instruction.Contains(')') && instruction.Contains("mul("))
            {
                var start = instruction.IndexOf("mul(");
                instruction = instruction.Substring(start);
                start = instruction.IndexOf("mul(");
                var comma = instruction.IndexOf(',');
                var paren = instruction.IndexOf(')');
                if (comma == 4 || comma > 7 || comma > paren)
                {
                    instruction = instruction.Substring(comma);
                    ExtractValidInstructions(instruction);
                }
                else if (paren - comma > 4)
                {
                    instruction = instruction.Substring(start+4);
                    ExtractValidInstructions(instruction);
                }
                else
                {
                    int op1, op2;

                    bool success1 = int.TryParse(instruction.Substring(4, comma - 4), out op1);
                    bool success2 = int.TryParse(instruction.Substring(comma + 1, paren - (comma+1)), out op2);
                    if (success1 && success2)
                    {
                        ValidInstructions.Add(new Mul(op1, op2));

                        instruction = instruction.Substring(paren+1);
                        ExtractValidInstructions(instruction);
                    }

                }
            }
        }

        public string RunSecond()
        {
            throw new NotImplementedException();
        }
    }
}

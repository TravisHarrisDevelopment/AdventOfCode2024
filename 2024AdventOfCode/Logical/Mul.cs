using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode.Logical
{
    public class Mul
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int Product { get; set; }

        public Mul(int operandOne, int operandTwo)
        {
            Operand1 = operandOne; 
            Operand2 = operandTwo;
            Product = operandOne * operandTwo;
        }

        public override string ToString()
        {
            return $"Mul({Operand1},{Operand2})";
        }
    }
}

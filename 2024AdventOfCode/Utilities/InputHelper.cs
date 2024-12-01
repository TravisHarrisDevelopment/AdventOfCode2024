using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode.Utilities
{
    internal static class InputHelper
    {
        internal static string[] GetInput(string fileName)
        {
            return File.ReadAllLines("C:\\Users\\travi\\source\\repos\\2024AdventOfCode\\2024AdventOfCode\\RawInput\\" + fileName);

            
        }
        
    }
}

using _2024AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024AdventOfCode
{
    public class Day4 : IDay
    {
        private readonly string _input;

        public string[] WordSearch { get; set; }

        public Day4(string input)
        {
            if (input == null || input=="")
            {
                throw new ArgumentNullException("input");
            }

            _input = input;
            InputHelper.GetInput(input);
        }


        public string RunFirst()
        {
            //word can be horizontal, vertical, diagonal, written backwards
            //check horizontal for XMAS and SAMX
            int horizontalCount = CheckHorizontal("XMAS");
            int backwardsCount = CheckHorizontal("SAMX");
            //check vertical (up and down)
            int verticalCountDown = CheckVertical("XMAS");
            int verticalCountUp = CheckVertical("SAMX");
            //check diagonal (up , down for both 'XMAS' and 'SAMX'
            return "stub";
        }

        private int CheckVertical(string v)
        {
            throw new NotImplementedException();
        }

        private int CheckHorizontal(string v)
        {
            throw new NotImplementedException();
        }

        public string RunSecond()
        {
            throw new NotImplementedException();
        }
    }
}

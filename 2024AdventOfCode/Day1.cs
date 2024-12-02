
using _2024AdventOfCode.Utilities;
using System.Linq;

public class Day1 : IDay
{
    private string _inputName;
    public List<int> FirstList { get; set; }

    public List<int> SecondList { get; set; }

    public Day1(string inputName)
    {
        if(inputName == "" || inputName == null)
        {
            throw new ArgumentNullException("inputName");
        }

        _inputName = inputName;

        var input = InputHelper.GetInput(_inputName);
        
        ExtractLists(input);
    }

    private void ExtractLists(string[] list)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in list)
        {
            var separator = line.IndexOf("   ");

            int val1 = (int.Parse(line.Substring(0, separator)));
            int val2 = (int.Parse(line.Substring(separator)));
            
            list1.Add(val1);
            list2.Add(val2);
        }
        FirstList = list1;
        SecondList = list2;
    }

    public string RunFirst()
    {
        var localList1 = FirstList.OrderByDescending(n => n).ToArray();
        var localList2 = SecondList.OrderByDescending(n => n).ToArray();

        long totalDistance = 0;

        for (int i = 0; i < localList1.Count(); i++)
        {
            var num1 = localList1[i];
            var num2 = localList2[i];
            totalDistance += Math.Abs(num1 - num2);
        }

        var result = $"The total distance is {totalDistance}.";
        return result;
    }

    public string RunSecond()
    {
        long similarityScore = 0;
        var localList1 = FirstList.OrderByDescending(n => n).ToList();

        foreach(var val in localList1)
        {
            int occurrences = GetOccurrenceCount(val);
            similarityScore += (val * occurrences);
        }
        var result = $"The similarity score is {similarityScore}.";

        return result;
    }

    private int GetOccurrenceCount(int val)
    {
        var localList2 = SecondList.OrderByDescending(n => n).ToList();

        return localList2.FindAll(n=> n == val).Count();
        
    }
}
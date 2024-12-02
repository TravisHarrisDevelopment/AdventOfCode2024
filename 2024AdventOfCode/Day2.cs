using _2024AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Day2 : IDay
{
    private readonly string _inputFile;
    public List<List<int>> Reports { get; set; }

    public Day2(string inputFile)
    {
        if(inputFile == null || inputFile == "")
        {
            throw new ArgumentNullException("inputFile");
        }

        _inputFile = inputFile;

        var input = InputHelper.GetInput(inputFile);

        Reports = new List<List<int>>();
        LoadReports(input);
    }

    private void LoadReports(string[] input)
    {
        foreach(var rawData in input)
        {
            Reports.Add(GenerateReport(rawData));
        }
    }

    private List<int> GenerateReport(string rawData)
    {
        var returnList = new List<int>();
        var interim = rawData.Split(' ');
        for (int i = 0; i < interim.Length; i++)
        {
            returnList.Add(int.Parse(interim[i]));
        }
        return returnList;
    }

    public string RunFirst()
    {
        var safeReportCounter = 0;
        foreach (var report in Reports)
        {
            if (ReportDescends(report) || ReportAscends(report))
            {
                if (DeltaAcceptable(report))
                {
                    safeReportCounter++;
                }
            }
        }

        return $"Input includes {safeReportCounter} safe reports";
    }

    public bool DeltaAcceptable(List<int> report)
    {
        bool skipFirst = true;
        int test = 0;
        foreach(var val in report)
        {
            if (skipFirst)
            {
                test = val;
                skipFirst = false;
                continue;
            }
            if (!(Math.Abs(val-test) > 0 && Math.Abs(val-test) < 4))
            {
                return false;
            }
            else
            {
                test = val;
            }
        }
        return true;
    }

    public bool ReportAscends(List<int> report)
    {
        bool skipFirst = true;
        int test = 0;
        foreach(var val in report)
        {
            if (skipFirst)
            {
                test = val;
                skipFirst = false;
                continue;
            }
            
            if(val <= test)
            {
                return false;
            }
            else
            {
                test = val;
            }
        }
        return true;
    }

    public bool ReportDescends(List<int> report)
    {
        bool skipFirst = true;
        int test = 0;
        foreach (var val in report)
        {
            if (skipFirst)
            {
                test = val;
                skipFirst = false;
                continue;
            }

            if (val >= test)
            {
                return false;
            }
            else
            {
                test = val;
            }
        }
        return true;
    }

    public string RunSecond()
    {
        var safeReportCounter = 0;

        foreach (var report in Reports)
        {
            if (DampenedReports(report))
            {
                
                safeReportCounter++;
            }
            
        }
        return $"Thanks to the Problem Dampener, {safeReportCounter} reports are actually safe!";
    }


    public bool DampenedReports(List<int> report)
    {
        if ((ReportAscends(report) || ReportDescends(report)) && DeltaAcceptable(report))
        {
            return true;
        }
        else
        {
            for (int i = 0; i < report.Count; i++)
            {
                var reportCopy = new List<int>(report);
                reportCopy.RemoveAt(i);
                if ((ReportAscends(reportCopy) || ReportDescends(reportCopy)) && DeltaAcceptable(reportCopy))
                {
                    return true;
                }
            }
        }
        return false;
    }

}

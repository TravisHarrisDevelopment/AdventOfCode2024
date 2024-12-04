// See https://aka.ms/new-console-template for more information
using _2024AdventOfCode;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Merry Advent of Code 2024!");

Console.WriteLine("What day would you like to run?");

var input = int.Parse(Console.ReadLine());


var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<Day1>(provider => new Day1("day1Input.txt"));
serviceCollection.AddTransient<Day2>(provider => new Day2("day2Input.txt"));
serviceCollection.AddTransient<Day3>(provider => new Day3("day3Input.txt"));
serviceCollection.AddTransient<Day4>(provider => new Day4("day4Input.txt"));

var serviceProvider = serviceCollection.BuildServiceProvider();

switch (input)
{
	case 1:
		var day1 = serviceProvider.GetRequiredService<Day1>();
		Console.WriteLine(day1.RunFirst());
		Console.WriteLine(day1.RunSecond());
		break;
	case 2:
		var day2 = serviceProvider.GetRequiredService<Day2>();
		Console.WriteLine(day2.RunFirst());
		Console.WriteLine(day2.RunSecond());
		break;
	case 3:
		var day3 = serviceProvider.GetRequiredService<Day3>();
		Console.WriteLine(day3.RunFirst());
		Console.WriteLine(day3.RunSecond());
		break;
	case 4:
		var day4 = serviceProvider.GetRequiredService<Day4>();
		Console.WriteLine(day4.RunFirst()); 
		Console.WriteLine(day4.RunSecond());
		break;
	default:
		break;
}


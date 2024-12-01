// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Merry Advent of Code 2024!");

Console.WriteLine("What day would you like to run?");

var input = int.Parse(Console.ReadLine());


var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<Day1>(provider => new Day1("day1Input.txt"));
//serviceCollection.AddTransient<Day2>(provider => new Day2("day2Input.txt"));

var serviceProvider = serviceCollection.BuildServiceProvider();

switch (input)
{
	case 1:
		var day1 = serviceProvider.GetRequiredService<Day1>();
		Console.WriteLine(day1.RunFirst());
		Console.WriteLine(day1.RunSecond());
		break;
	default:
		break;
}


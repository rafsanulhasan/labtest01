using System;

namespace LabTest
{
	public static class Program
	{
		private static int CalculateNumberOfPulses(
			DateTime startDate,
			DateTime endDate
		)
		{
			var duration = endDate - startDate;
			return int.Parse(Math.Ceiling(duration.TotalSeconds / 20).ToString());
		}
		private static float CalculateRate(
				DateTime startTime,
				DateTime endTime
			)
				=> startTime.Hour >= 9 && endTime.Hour < 12
				? 0.30f
				: 0.20f;

		private static double CalculateBill(
			DateTime startDate,
			DateTime endDate
		)
		{
			var duration = CalculateNumberOfPulses(startDate, endDate);
			var rate = CalculateRate(startDate, endDate);
			return duration * rate;
		}

		public static void Main(string[] args)
		{
			Console.Write("\nStart Date: ");
			var startDateString = Console.ReadLine();

			Console.Write("\nEnd Date: ");
			var endDateString = Console.ReadLine();

			if (!string.IsNullOrEmpty(startDateString) &&
			    !string.IsNullOrEmpty(endDateString) &&
			    DateTime.TryParse(startDateString.Trim(), out var startDate) &&
			    DateTime.TryParse(endDateString.Trim(), out var endDate) &&
			    endDate > startDate)
			{
				var bill = CalculateBill(startDate, endDate);
				Console.WriteLine($"{bill:N}");
			}
			else
			{
				Console.WriteLine("invalid input");
			}
			Console.ReadKey();
		}
	}
}

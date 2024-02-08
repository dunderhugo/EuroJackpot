using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System;
using System.Globalization;

namespace EuroJackpot
{
	internal class Program
	{
		static string FormatOutput(double value)
		{
			return value.ToString("N0");
		}
		public static (double[], double[]) RandomJackpotNum()
		{
			double[] arrayOne = new double[5];
			double[] arrayTwo = new double[2];
			Random random = new Random();
			for (int i = 0; i < arrayOne.Length; i++)
			{
				double randomNum = random.Next(1, 50);
				if (!arrayOne.Contains(randomNum))
				{
					arrayOne[i] = randomNum;
				}
				else i--;

			}
			for (int i = 0; i < arrayTwo.Length; i++)
			{
				double randomNum = random.Next(1, 12);
				if (!arrayTwo.Contains(randomNum))
				{
					arrayTwo[i] = randomNum;
				}
				else i--;
			}
			return (arrayOne, arrayTwo);
		}
		static void Main(string[] args)
		{
			int[] winnings = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			Console.WriteLine("Welocme to the Euro Jackpot simulator!");
			(double[] myNum1, double[] myNum2) = RandomJackpotNum();
			Console.Write("This is your winning number: ");
			foreach (int num in myNum1)
			{
				Console.Write(num + " ");
			}
			Console.Write(", ");
			foreach (int num in myNum2) Console.Write(num + " ");
			Console.WriteLine();
			int commando;
			do
			{
                Console.WriteLine("Type the amount of times you want to try your luck in Euro Jackpot!");
				Console.WriteLine("Type '0' if you want to se how long it takes to win the jackpot");
				Console.Write("> ");
				commando = int.Parse(Console.ReadLine());
				if (commando == 0)
				{
					double timesRolled = 0;
					do
					{
						int correct = 0;
						(double[] winningArrOne, double[] winningArrTwo) = RandomJackpotNum();
						for (int check = 0; check < winningArrOne.Length; check++)
						{
							if (winningArrOne.Contains(myNum1[check])) correct++;
						}
						for (int check = 0; check < winningArrTwo.Length; check++)
						{
							if (winningArrTwo.Contains(myNum2[check])) correct++;
						}
						timesRolled++;
						if (correct == 7)
						{
                            Console.WriteLine($"it took you {timesRolled} to find the jackpot!");
							break;
                        }
					}
					while (true);
				}
				if (commando > 0)
				{
					for (int i = 0; i < commando; i++)
					{
						int correctArrOne = 0;
						int correctArrTwo = 0;
						(double[] winningArrOne, double[] winningArrTwo) = RandomJackpotNum();
						// Checks if correct numbers from lottery
						for (int check = 0; check < winningArrOne.Length; check++)
						{
							if (winningArrOne.Contains(myNum1[check])) correctArrOne++;
						}
						for (int check = 0; check < winningArrTwo.Length; check++)
						{
							if (winningArrTwo.Contains(myNum2[check])) correctArrTwo++;
						}
						if ((correctArrTwo + correctArrOne) == 3)
						{
							// 3 + 0 
							if (correctArrOne == 3) winnings[0]++;
							// 2 + 1
							if (correctArrOne == 2) winnings[1]++;
							// 1 + 2
							else winnings[2]++;
						}
						if ((correctArrTwo + correctArrOne) == 4)
						{
							// 4 + 0
							if (correctArrOne == 4) winnings[3]++;
							// 3 + 1
							else if (correctArrOne == 3) winnings[4]++;
							// 2 + 2
							else winnings[5]++;
						}
						if ((correctArrTwo + correctArrOne) == 5)
						{
							// 5 + 0
							if (correctArrOne == 5) winnings[6]++;
							// 4 + 1
							else if (correctArrOne == 4) winnings[7]++;
							// 3 + 2
							else winnings[8]++;
						}
						if ((correctArrTwo + correctArrOne) == 6)
						{
							// 5 + 1
							if (correctArrOne == 5) winnings[9]++;
							// 4 + 1
							else winnings[10]++;
						}
						if ((correctArrTwo + correctArrOne) == 7)
						{
							// 5 + 2
							winnings[11]++;
						}
					}
				}
				double[] moneyToWin = { 199, 156, 112, 237, 309, 3300, 4475, 10025, 59230, 8630449, 8630449, 707000000 };

				double sumWon = 0;
				for (int i = 0;i < moneyToWin.Length; i++)
				{
					sumWon = sumWon + moneyToWin[i] * winnings[i];
				}
				double timesWon = 0;
				foreach (double i in winnings)
				{
					timesWon += i;
				}
				double cost = 25;
				string formattedTimesWon = FormatOutput(timesWon);
				string formattedCommando = FormatOutput(commando);
				string formattedSumWon = FormatOutput(sumWon);
				string formatWinnings= FormatOutput(timesWon/commando*100);
				string formatMoneySpent = FormatOutput(commando * cost);
				Console.WriteLine($"Amount of times won with {formattedCommando} spins");
				Console.WriteLine($"Total times won: {formattedTimesWon}");

				for (int i = 0; i < moneyToWin.Length; i++)
				{
					string[] winningGuesses = { "3 + 0", "2 + 1", "1 + 2", "4 + 0", "3 + 1", "2 + 2", "5 + 0", "4 + 1", "3 + 2", "5 + 1", "4 + 2", "5 + 2" };
					Console.WriteLine($"{winningGuesses[i]}\t{winnings[i]}\tMoney won = {winnings[i]* moneyToWin[i]}");
				}
				Console.WriteLine($"You won {formatWinnings}% of the rolls");
				Console.WriteLine($"You spent {formatMoneySpent}kr on euro jackpot");
				Console.WriteLine($"Amount won with {formattedCommando} spins = {formattedSumWon}kr" );
			}
			while (true);
		}
	}
}

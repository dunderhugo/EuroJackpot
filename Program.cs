using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace EuroJackpot
{
	internal class Program
	{

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
				double one = 199;
				double two = 156;
				double three = 112;
				double four = 237;
				double five = 309;
				double six = 3300;
				double seven = 4475;
				double eight = 10025;
				double nine = 59230;
				double ten = 8630449;
				double eleven = 8630449;
				double twelve = 707000000;
				double sumWon = winnings[0] * one + winnings[1] * two + winnings[2] * three + winnings[3] * four + winnings[4] * five + winnings[5] * six + winnings[6] * seven + winnings[7] * eight + winnings[8] * nine + winnings[9] * ten + winnings[10] * eleven + winnings[11] * twelve;
				double timesWon = 0;
				foreach (double i in winnings)
				{
					timesWon += i;
				}

				double cost = 25;
				Console.WriteLine($"Amount of times won with {commando} spins");
				Console.WriteLine($"Total times won: {timesWon}");
				Console.WriteLine($"You won {timesWon/commando*100}% of the rolls");
				Console.WriteLine($"3 + 0	{winnings[0]}		Money won = {winnings[0] * one}kr");
				Console.WriteLine($"2 + 1	{winnings[1]}		Money won = {winnings[1] * two}kr");
				Console.WriteLine($"1 + 2	{winnings[2]}		Money won = {winnings[2] * three}kr");
				Console.WriteLine($"4 + 0	{winnings[3]}		Money won = {winnings[3] * four}kr");
				Console.WriteLine($"3 + 1	{winnings[4]}		Money won = {winnings[4] * five}kr");
				Console.WriteLine($"2 + 2	{winnings[5]}		Money won = {winnings[5] * six}kr");
				Console.WriteLine($"5 + 0	{winnings[6]}		Money won = {winnings[6] * seven}kr");
				Console.WriteLine($"4 + 1	{winnings[7]}		Money won = {winnings[7] * eight}kr");
				Console.WriteLine($"3 + 2	{winnings[8]}		Money won = {winnings[8] * nine}kr");
				Console.WriteLine($"5 + 1	{winnings[9]}		Money won = {winnings[9] * ten}kr");
				Console.WriteLine($"4 + 2	{winnings[10]}		Money won = {winnings[10] * eleven}kr");
				Console.WriteLine($"JACKPOT! {winnings[11]}		Money won = {winnings[11] * twelve}kr");
				Console.WriteLine($"You spent {commando * cost}kr on euro jackpot");
				Console.WriteLine($"Amount won with {commando} spins = {sumWon}kr" );
				

			}
			while (true);


		}
	}
}

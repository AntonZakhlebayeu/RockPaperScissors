using System;
using System.Text;

namespace RockPaperScissors 
{
    internal class HelpTable 
    {
		public static void Print(string[] moves) 
        {
			foreach (var move in moves) 
				Console.Write("{0, 15}", move);
			Console.WriteLine();
		
			int counter = 0;
			foreach (var move in moves) 
            {
				Console.Write("{0, -11}", move);
				for (int i = 0; i < moves.Length; i++) 
                {
					if (i == counter)
						Console.Write("{0, -15}", "Dead heat...");
					else if (Rules.IsWon(moves, i, counter))
						Console.Write("{0, -15}", "Won");
					else
						Console.Write("{0, -15}", "Lose");
				}
					
				counter += 1;
				Console.WriteLine();
			}
		}
    }
}

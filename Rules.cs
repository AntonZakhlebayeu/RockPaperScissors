using System;

namespace RockPaperScissors 
{
    internal static class Rules 
    {
        internal static bool IsWon(string[] moves, int userChoice, int computerChoice) 
        {
            if (userChoice < computerChoice) 
            {
                int leftSide = computerChoice - userChoice;
                int rightSide = userChoice + (moves.Length - computerChoice);

                return (leftSide > rightSide) ? true : false;

            } 
            else if (userChoice > computerChoice) 
            {
                int leftSide = computerChoice + (moves.Length - userChoice);
                int rightSide = userChoice - computerChoice;

                return (leftSide > rightSide) ? true : false;
            }

            return false;
        }

        internal static int[] GetBeatList(int movesSize, int current) 
        {
            int[] beatList = new int[movesSize / 2];
            int counter = 0;

            while (counter < movesSize / 2) 
            {     
                if (current - 1 - counter < 0)
                    beatList[counter] = movesSize + current - counter;
                else
                    beatList[counter] = current - counter;

                counter += 1;
            }
            return beatList;
        }
    }
}

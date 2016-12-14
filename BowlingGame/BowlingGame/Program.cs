using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int current;

        public void Roll(int nbr)
        {
            rolls[current++] = nbr;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int round = 0; round < 10; round++)
            {
                if (IsStrike(roll)) //STRIKE
                {
                    score += 10 + rolls[roll + 1] + rolls[roll + 2];
                    roll++;
                }
                else if (IsSpare(roll)) //SPARE
                {
                    score += 10 + rolls[roll + 2];
                    roll += 2;
                }
                else //NORMAL
                {
                    score += rolls[roll] + rolls[roll + 1];
                    roll += 2;
                }
            }
            return score;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        static void Main(string[] args)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library
{
    public static class Two_Up_Game
    {
        private static Coin coin1, coin2;
        private static int playersScore;
        private static int computersScore;

        public static void SetUpGame()
        {
            coin1 = new Coin();
            coin2 = new Coin();

            playersScore = 0;
            computersScore = 0;
        }

        public static void TossCoins()
        {
            coin1.Flip();
            coin2.Flip();
        }

        public static string TossOutCome()
        {
            if (coin1.IsHeads() && coin2.IsHeads())
            {
                playersScore += 1;
                return "Heads";
            }
            else if (!coin1.IsHeads() && coin2.IsHeads())
            {
                computersScore += 1;
                return "Tails";
            }
            return "Odds";
        }

        public static bool IsHeads(int whichCoin)
        {
            if (whichCoin == 1)
            {
                return coin1.IsHeads();
            }
            else if (whichCoin == 2)
            {
                return coin2.IsHeads();
            }
            return false;    
        }

        public static int GetPlayersScore()
        {
            return playersScore;
        }

        public static int GetComputersScore()
        {
            return computersScore;
        }
    }
}

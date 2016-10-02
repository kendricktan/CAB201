using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library
{
    public static class Snake_Eyes_Game
    {
        private static int rollTotal;
        private static int playerTotal;
        private static int houseTotal;
        private static int possiblePoints;
        private static Die[] dice;

        // Constructor
        public static void SetUpGame()
        {
            // Initialize two dice
            dice = new Die[2];
            dice[0] = new Die();
            dice[1] = new Die();

            playerTotal = 0;
            houseTotal = 0;
            possiblePoints = -1;
            rollTotal = -1;
        }
        
        public static bool FirstRoll()
        {
            // To get roll outcome...
            possiblePoints = -1;

            // Roll dice
            dice[0].RollDie();
            dice[1].RollDie();

            int total = dice[0].GetFaceValue() + dice[1].GetFaceValue();
            rollTotal = total;

            // Based off rules
            if ((total >=4 && total <=6) || (total >= 8 && total <= 10))
            {
                possiblePoints = total;                
                return true;
            }

            if (total == 2)
            {
                playerTotal += 2;
                return false;
            }

            if (total == 7 || total == 11)
            {
                playerTotal += 1;
                return false;
            }

            if (total == 3 || total == 12)
            {                
                houseTotal += 2;
                return false;
            }            

            return false;
        }

        public static bool AnotherRoll()
        {
            // Roll dice again
            dice[0].RollDie();
            dice[1].RollDie();

            int total = dice[0].GetFaceValue() + dice[1].GetFaceValue();
            rollTotal = total;

            // Roll 7 = end of game
            if (total == 7)
            {                
                houseTotal += 2;
                return false;
            }

            // Roll previous number = end of game
            if (total == possiblePoints)
            {
                playerTotal += possiblePoints;
                return false;
            }

            return true;
        }

        public static int GetDiceFaceValue(int whichDice)
        {
            return dice[whichDice].GetFaceValue();
        }

        public static int GetPlayersPoints()
        {
            return playerTotal;
        }

        public static int GetHousePoints()
        {
            return houseTotal;
        }

        public static int GetPossiblePoints()
        {
            return possiblePoints;
        }

        public static int GetRollTotal()
        {
            return rollTotal;
        }

        public static string GetRollOutcome()
        {
            if (rollTotal >= 0) {
                if (possiblePoints >= 0) {
                    if (rollTotal == possiblePoints)
                    {
                        return "Congratulations you won!";
                    }
                    if (rollTotal == 7)
                    {
                        return "Sorry you lost!";
                    }
                }
                if (rollTotal == 2 || rollTotal == 7 || rollTotal == 11)
                {
                    return "Congratulations you won!";
                }
                if (rollTotal == 3 || rollTotal == 12)
                {
                    return "Sorry you lost!";
                }
            }

            return "Roll dice again";
        }
    }
}

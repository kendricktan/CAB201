using System;

namespace TrainTimetable {

    enum Stations { Central, Roma_Street, Milton, Auchenflower, Toowong, Taringa, Indooroopilly };

    class Program {

        public const int NUMBER_OF_TRAINS = 76;
        public const int NUMBER_OF_STATIONS = 7;
        static int[,] timeTable = new int[NUMBER_OF_STATIONS, NUMBER_OF_TRAINS];

        static string departFrom = "\n Which station are you leaving from?\n"
                              + "\n1) Central"
                              + "\n2) Roma Street"
                              + "\n3) Milton"
                              + "\n4) Auchenflower"
                              + "\n5) Toowong"
                              + "\n6) Taringa"
                              + "\n\nEnter your option(1-6 or 0 to exit): ";

        static string arriveAt = "\n Which station are you going to?\n"
                           + "\n1) Roma Street"
                           + "\n2) Milton"
                           + "\n3) Auchenflower"
                           + "\n4) Toowong"
                           + "\n5) Taringa"
                           + "\n6) Indooroopilly"
                           + "\n\nEnter your option(1-6 or 0 to exit): ";

        static int GetTrain(int[,] t, int GOING_TO_STATION, int TIME_TO_ARRIVE)
        {
            for (int aTrain = 0; aTrain < NUMBER_OF_TRAINS; aTrain++)
            {
                if (timeTable[GOING_TO_STATION, aTrain] > TIME_TO_ARRIVE)
                {
                    return aTrain-1;
                }
            }
            return -1;
        }

        static string GetFormatTime(int RAW_TIME)
        {
            string TIME_FORMAT = "a.m.";
            int MINUTES = RAW_TIME % 100;
            string sMINUTES = "";
            int HOUR = RAW_TIME / 100;

            if (HOUR > 12)
            {
                HOUR -= 12;
                TIME_FORMAT = "p.m.";
            }

            if (MINUTES < 10)
            {
                sMINUTES = String.Format("0{0}", MINUTES);
            }
            else
            {
                sMINUTES = String.Format("{0}", MINUTES);
            }

            return String.Format("{0}:{1}{2}", HOUR, sMINUTES, TIME_FORMAT);
        }

        static void Main() {


            // ********** Do not remove the following statement ******************
            timeTable = Timetables.CreateTimeTable();
            
            // Delete the following line once you are convinced that the timetable has been created as per specification
            //and remove the breakpoint
            Console.WriteLine("\n\tTimetable created!\n\n");
            //*********** Start your code for Main below this line  ******************

            // Leaving
            Console.WriteLine(" Which station are you leaving from?\n");

            for (Stations station = Stations.Central; station < Stations.Indooroopilly; station++)
            {
                Console.WriteLine("{0}) {1}", (int)station+1, station);
            }

            // Which station u leaving from
            Console.Write("\nEnter your option (1-6 or 0 to exit): ");
            int LEAVING_FROM_STATION;
            bool isNumeric = int.TryParse(Console.ReadLine(), out LEAVING_FROM_STATION);

            while (!isNumeric)
            {
                Console.Write("\nPlease enter numbers only: ");
                isNumeric = int.TryParse(Console.ReadLine(), out LEAVING_FROM_STATION);
            }

            // Starts from, so -1
            LEAVING_FROM_STATION -= 1;

            // Which station you going to?
            Console.WriteLine("\nWhat station are you going to?\n");

            for (Stations station = Stations.Roma_Street; station <= Stations.Indooroopilly; station++)
            {
                Console.WriteLine("{0}) {1}", (int)station, station);
            }


            Console.Write("\nEnter your option (1-6 or 0 to exit): ");
            int GOING_TO_STATION;
            isNumeric = int.TryParse(Console.ReadLine(), out GOING_TO_STATION);

            while (!isNumeric)
            {
                Console.Write("\nPlease enter numbers only: ");
                isNumeric = int.TryParse(Console.ReadLine(), out GOING_TO_STATION);
            }

            string STR_START_STATION = Enum.GetName(typeof(Stations), LEAVING_FROM_STATION);
            string STR_END_STATION = Enum.GetName(typeof(Stations), GOING_TO_STATION);          

            // Can't have same arrival and departure place n00b
            if (GOING_TO_STATION == LEAVING_FROM_STATION)
            {
                Console.WriteLine("\nYou have selected {0} as both your departure and arrival station, \n\tthis enquiry is cancelled", STR_START_STATION);
                ExitProgram();
                return;         
            }

            else if (GOING_TO_STATION < LEAVING_FROM_STATION)
            {
                Console.WriteLine("\nYou cannot travel from {0} to {1}, \n\tthis enquiry is cancelled", STR_START_STATION, STR_END_STATION);
                ExitProgram();
                return;
            }

            // Which time u wanna be at your end place
            Console.Write("\nEnter the time you wish to be at {0} in 24 hour format (hh:mm): ", STR_END_STATION);
            int TIME_TO_ARRIVE;
            isNumeric = int.TryParse(Console.ReadLine().Replace(":", ""), out TIME_TO_ARRIVE);            
            
            while (!isNumeric)
            {
                Console.Write("\nPlease enter 24 hour time format in (hh:mm): ");
                isNumeric = int.TryParse(Console.ReadLine().Replace(":", ""), out TIME_TO_ARRIVE);
            }

            // Train checker choo choo
            int GOOD_TRAIN = GetTrain(timeTable, GOING_TO_STATION, TIME_TO_ARRIVE);

            while(GOOD_TRAIN == -1)
            {                
                Console.WriteLine("You cannot catch any train to arrive by {0} {1}\n", GetFormatTime(TIME_TO_ARRIVE), STR_END_STATION);
                Console.WriteLine("\tYou will need to enter a later time\n");
                Console.Write("\nEnter the time you wish to be at {0} in 24 hour format (hh:mm): ", STR_END_STATION);
                isNumeric = int.TryParse(Console.ReadLine().Replace(":", ""), out TIME_TO_ARRIVE);

                // Nested while loops top kek
                while (!isNumeric)
                {
                    Console.Write("\nPlease enter 24 hour time format in (hh:mm): ");
                    isNumeric = int.TryParse(Console.ReadLine().Replace(":", ""), out TIME_TO_ARRIVE);
                }

                GOOD_TRAIN = GetTrain(timeTable, GOING_TO_STATION, TIME_TO_ARRIVE);
            }
            

            Console.WriteLine("\nTo arrive at {0} {1}", STR_END_STATION, GetFormatTime(TIME_TO_ARRIVE));

            // Getting train from relative station
            int RAW_TIME = timeTable[LEAVING_FROM_STATION, GOOD_TRAIN];                         
            Console.WriteLine("\nyou need to catch the train from {0} at {1}", STR_START_STATION, GetFormatTime(RAW_TIME));
                       
            ExitProgram();
        }// end Main        



        /// <summary>
        /// Will exit the project once the user has pressed any key
        /// </summary>
        static void ExitProgram() {
            Console.Write("\n\n\t Press any key to terminate program ...");
            Console.ReadKey();
        }//end ExitProgram





    }//end class
}//end nameSpace

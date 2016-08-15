using System;

/* Fuel Calculator class
*  Has all functions necessary to calculate
*  fuel efficiency in the class
*/
class FuelCalculator
{
    private double FuelUsed, KilometersTravelled;

    // Calculation for fuel used in 100km
    public double GetLitresPerHundredKilometer()
    {
        // Formula = Fuel/Kilometers * 100
        // Double cause its gonna have decimal places
        return Math.Round((this.FuelUsed / this.KilometersTravelled) * 100.0, 2);
    }

    // Convert l/100km to mpg
    public double GetMPG()
    {
        // Top kek formula :) 
        return Math.Round(282.48 / this.GetLitresPerHundredKilometer(), 2);
    }

    // Get Fuel used
    public bool GetFuelUsed()
    {
        Console.Write("Enter amount of fuel used in litres: ");

        try
        {
            this.FuelUsed = double.Parse(Console.ReadLine());

            while (this.FuelUsed < 20)
            {
                Console.WriteLine("{0} is below the minimum value of 20\n", this.FuelUsed);
                Console.Write("Please re-enter a number greater than 20: ");

                try { this.FuelUsed = double.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("\t\tNumber machine only accept numbers...\n"); }
            }

            return true;
        }
        catch
        {
            Console.WriteLine("\t\tNumber machine only accept numbers...\n");
            return false;
        }
    }

    // Get Kilometers travelled
    public bool GetKiloMetersTravelled()
    {
        Console.Write("Enter distance travelled in kilometers: ");

        try
        {
            this.KilometersTravelled = double.Parse(Console.ReadLine());

            while (this.KilometersTravelled < 200)
            {
                Console.WriteLine("{0} is below the minimum value of 200\n", this.KilometersTravelled);
                Console.Write("Please re-enter a number greater than 200: ");

                try { this.KilometersTravelled = double.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("\t\tNumber machine only accept numbers...\n"); }
            }

            return true;
        }
        catch
        {
            Console.WriteLine("\t\tNumber machine only accept numbers...\n");
            return false;
        }
    }

    // Print muh welcome stuff
    public void PrintMuhWelcome()
    {
        Console.WriteLine("\t\tWelcome to Fuel Consumption Calculator!\n");
    }

    // Print calculation stuff
    public void PrintMuhCalculations()
    {
        Console.WriteLine("\nYour fuel consumption is {0}l/100km\n", this.GetLitresPerHundredKilometer());
        Console.WriteLine(" which is equivalent to {0}mpg\n\n", this.GetMPG());
    }

    // Yum yum i like to eat console inputs
    public void GetConsoleInputs()
    {
        while (!this.GetFuelUsed()) { }
        while (!this.GetKiloMetersTravelled()) { }
    }

    // Do i do this again???
    public bool DoAgainYeah()
    {
        while (true)
        {
            Console.Write("Another calculation (Y/N)? ");
            string s = Console.ReadLine();
            Console.WriteLine();


            if (s.ToLower().Equals("y"))
            {
                return true;
            }
            else if (s.ToLower().Equals("n"))
            {
                return false;
            }

            Console.WriteLine("I don't understand: {0}, please enter either Y/N to continue or quit...\n", s);
        }
    }

    // Do i really need this????
    public void ExitGracefulAF()
    {
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
}


namespace FuelConsumption
{
    /*
     * Calculates fuel consumption in l/100km and the equivalent mpg,
     * input units of measurement are litres (l) for the fuel used and
     * kilometres (km) for the distance travelled
     *
     * Author Kendrick Tan, 9701583
     * Date: August 2016
     *
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciate our fuel calculator
            FuelCalculator fc = new FuelCalculator();

            do
            {
                // Print top kek welcome screen!
                fc.PrintMuhWelcome();

                // Get User Inputs hahahaha
                fc.GetConsoleInputs();

                // Print calculations!
                fc.PrintMuhCalculations();

            } while (fc.DoAgainYeah()); // Keep doing calculations ya numnut

            // Exit Gracefully
            fc.ExitGracefulAF();
        }
    }
}

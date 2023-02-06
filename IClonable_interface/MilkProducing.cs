using System;


namespace IClonable_interface
{
    class Milk : ICloneable
    {
        //List of available animals
        string[] milkGivers = {
            "Cow",
            "Sheep",
            "Goat",
            "Camel",
            "Buffalo" };
        //Private fields with default values
        string whoseMilk = "Cow";
        double volumeOfBottle = 1;

        //Class constructor
        public Milk(double volumeOfBottle, string whoseMilk)
        {
            this.volumeOfBottle = volumeOfBottle;
            WhoseMilk = whoseMilk;
            Console.WriteLine($"{volumeOfBottle} liters of {whoseMilk} milk");

        }

        //Private property, which is used to make sure that animal is in milkGivers list
        string WhoseMilk
        {
            get { return whoseMilk; }

            set
            {
                foreach (var item in milkGivers)
                {
                    if (item == value)
                        whoseMilk = value;
                }
            }
        }

        //Implementation of Clone method of IClonable interface
        public object Clone() => new Milk(volumeOfBottle, whoseMilk);

    }

    class MilkProducing
    {
        static void Main(string[] args)
        {
            int numberOfBottles;
            double volumeOfBottle;
            string animal;
            while (true)
            {
                Console.WriteLine("Enter how many bottles of milk do you need");
                try
                {
                    numberOfBottles = Convert.ToInt32(Console.ReadLine());
                    if (numberOfBottles <= 0)
                        throw new Exception("Number of bottles can not be less or equal to zero");
                    Console.WriteLine("Enter the volume of the bottle");
                    volumeOfBottle = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter what animal milk it should be");
                    animal = Console.ReadLine();
                    break;
                }
                catch (Exception e)
                {
                    //Output the reason what caused exception
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            //Creating a sample
            Milk milk = new Milk(volumeOfBottle, animal);

            //Producing milk 
            for (int i = 1; i < numberOfBottles; i++)
            {
                Milk newMilk = (Milk)milk.Clone();
            }
            Console.ReadLine();
        }
    }
}

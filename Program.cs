namespace breakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code for calculating app duration.
            var watch = new System.Diagnostics.Stopwatch();

            // Introduction.
            Console.WriteLine("Good morning! Let's have some breakfast");

            // False meal trap.
            Console.WriteLine("What would you like to have?");
            Console.ReadLine();
            Console.WriteLine("----");
            Console.WriteLine("EGGS with BACON? Excelent choice!");
            Console.WriteLine("----");

            // First input (out of 2).
            Console.WriteLine("How many eggs:");
            int eggQty;

            // First input accepts only numbers.
            while (!int.TryParse(Console.ReadLine(), out eggQty))
            {
                Console.WriteLine("Please enter a number!");
            }

            // Start calculating app duration.
            watch.Start();

            // Second chance to have an order or cancel order.
            if (eggQty == 0)
            {
                Kitchen.Warning("eggs");
                while (!int.TryParse(Console.ReadLine(), out eggQty))
                {
                    Console.WriteLine("How about a number?;)");
                }
            }

            //  If 0 Cancel order.
            if (eggQty == 0)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            // Second input (out of 2).
            Console.WriteLine("How many slices of bacon:");
            int baconQty;

            // Second input accepts only numbers.
            while (!int.TryParse(Console.ReadLine(), out baconQty))
            {
                Console.WriteLine("Please enter a number!");
            }

            // Second chance to choose bacon quantity or cancel order.
            if (baconQty == 0)
            {
                Kitchen.Warning("bacon");
                while (!int.TryParse(Console.ReadLine(), out baconQty))
                {
                    Console.WriteLine("How about a number?");
                }
            }

            //  If 0 Cancel order.
            if (baconQty == 0)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            // Order was placed.
            Console.WriteLine("----");
            Console.WriteLine($"Your order: Omlet with {eggQty} eggs and {baconQty} bacon slices. Coming right up!");
            Console.WriteLine("----");

            // Cooking code. Let's say coffee first and then the meal.
            Console.WriteLine("----1. Preparing meal");
            Coffee.BoilWater();
            Coffee.PourInCup();
            Coffee.ServeToCustomer();
            Eggs.PreparePan();
            Eggs.PutInPan(eggQty);
            Eggs.FryEggs();
            Bacon.SlicesToPan(baconQty);
            Bacon.FryBacon();
            Toasts.PutInToaster();
            Toasts.PutButterOn();
            Toasts.PutOnPlate();
            Console.WriteLine("----2. Serving meal");
            Kitchen.ServeMeal();

            // Stop calculating app duration.
            watch.Stop();

            // App duration info.
            Console.WriteLine("----");
            Kitchen.Time(watch.ElapsedMilliseconds);

            // The end.
            Console.WriteLine("----");
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        public static class Coffee
        {
            public static void BoilWater()
            {
                Console.WriteLine("Boiling water...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Hot water prepared for coffee.");
            }
            public static void PourInCup()
            {
                Console.WriteLine("Pouring coffee into cup.");
                Task.Delay(1500).Wait();
            }
            public static void ServeToCustomer()
            {
                Console.WriteLine("Serve coffee to customer.");
                Task.Delay(2000).Wait();
            }
        }

        public static class Toasts
        {
            public static void PutInToaster()
            {
                Console.WriteLine("Put  bread in toaster...");
                Task.Delay(3000);
                Console.WriteLine("Toust was baked!");
            }
            public static void PutButterOn()
            {
                Console.WriteLine("Appling butter on toust.");
                Task.Delay(2000).Wait();
            }
            public static void PutOnPlate()
            {
                Console.WriteLine("Toast on plate!");
                Task.Delay(2000).Wait();
            }
        }

        public static class Eggs
        {
            public static void PreparePan()
            {
                Console.WriteLine("Preparing pan for cooking...");
                Task.Delay(2000).Wait();
                Console.WriteLine("Pan is ready for action");
            }
            public static void PutInPan(int qty)
            {
                Console.WriteLine($"Crashing {qty} eggs in pan");
                Task.Delay(2000).Wait();
            }
            public static void FryEggs()
            {
                Console.WriteLine("Frying eggs...");
                Task.Delay(6000).Wait();
                Console.WriteLine("Put eggs on the plate!");
            }
        }

        public static class Bacon
        {
            public static void SlicesToPan(int qty)
            {
                Console.WriteLine($"Putting {qty}  slices of bacon in pan");
                Task.Delay(2500).Wait();
            }
            public static void FryBacon()
            {
                Console.WriteLine("Frying bacon...");
                Task.Delay(5000).Wait();
                Console.WriteLine("Put bacon in plate");
            }
        }

        public static class Kitchen
        {
            public static void ServeMeal()
            {
                Console.WriteLine("Breakfast is ready and it was served to customer! Enjoy");
                Task.Delay(2000).Wait();
            }
            public static void Warning(string ingredient)
            {
                Console.WriteLine($"Sorry, no {ingredient} no meal.\nChoose another number, or type 0 again to cancel order:(");
            }
            public static void Time(double time)
            {
                Console.WriteLine($"Time needed for prepareing breakfast: {time / 1000} seconds");
            }
        }
    }
}
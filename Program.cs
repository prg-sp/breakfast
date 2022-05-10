namespace breakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Code for calculating app duration
            var watch = new System.Diagnostics.Stopwatch();

            // Introduction
            Console.WriteLine("Good morning! Let's have some breakfast");

            // False meal trap
            Console.WriteLine("What would you like to have?");
            Console.ReadLine();
            Console.WriteLine("----");
            Console.WriteLine("EGGS with BACON? Excelent choice!");
            Console.WriteLine("----");

            // First input (out of 2)
            Console.WriteLine("How many eggs:");
            int eggQty;

            // First input accepts only numbers
            while (!int.TryParse(Console.ReadLine(), out eggQty))
            {
                Console.WriteLine("Please enter a number!");
            }

            // Start calculating app duration
            watch.Start();

            // Second chance to have an order or cancel order
            if (eggQty == 0)
            {
                Kitchen.Warning("eggs");
                while (!int.TryParse(Console.ReadLine(), out eggQty))
                {
                    Console.WriteLine("How about a number?;)");
                }
            }

            //  If 0 Cancel order
            if (eggQty == 0)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            // Second input (out of 2)
            Console.WriteLine("How many slices of bacon:");
            int baconQty;

            // Second input accepts only numbers
            while (!int.TryParse(Console.ReadLine(), out baconQty))
            {
                Console.WriteLine("Please enter a number!");
            }

            // Second chance to choose bacon quantity or cancel order
            if (baconQty == 0)
            {
                Kitchen.Warning("bacon");
                while (!int.TryParse(Console.ReadLine(), out baconQty))
                {
                    Console.WriteLine("How about a number?");
                }
            }

            //  If 0 Cancel order
            if (baconQty == 0)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            // Order was placed
            Console.WriteLine("----");
            Console.WriteLine($"Your order: Omlet with {eggQty} eggs and {baconQty} bacon slices. Coming right up!");
            Console.WriteLine("----");

            // Cooking code. Let's say coffee first and then the meal
            Console.WriteLine("----1.Cooking");

            // Putting grouped actions in tasks
            var coffeeTask = PrepareCoffeeAndServeAsync();
            var eggsTask = PrepareEggsAsync(eggQty);
            var baconTask = PrepareBaconAsync(baconQty);
            var toastsTask = PrepareToastWithButterAsync();

            // Checks if any task in a list is finished executing.
            var breakfastTasks = new List<Task> { eggsTask, coffeeTask, toastsTask, baconTask };
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == coffeeTask)
                {
                    Console.WriteLine("-- Coffee was prepared and served! --");
                }
                else if (finishedTask == eggsTask)
                {
                    Console.WriteLine("-- Eggs is ready! --");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("-- Bacon is ready! --");
                }
                else if (finishedTask == toastsTask)
                {
                    Console.WriteLine("-- Toast is ready! --");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Console.WriteLine("----2.Serving");
            Kitchen.ServeMeal();

            // Stop calculating app duration
            watch.Stop();

            // App duration info
            Console.WriteLine("----");
            Kitchen.Time(watch.ElapsedMilliseconds);

            // The end
            Console.WriteLine("----");
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        // Putting actions in "groups" to avoid mistakes.
        // For egz. pours coffee only after water finishes to boil not vice versa.
        public static async Task PrepareCoffeeAndServeAsync()
        {
            await Coffee.BoilWaterAsync();
            Coffee.PourInCup();
            Coffee.ServeToCustomer();
        }

        public static async Task PrepareToastWithButterAsync()
        {
            await Toasts.PutInToasterAsync();
            Toasts.PutButterOn();
            Toasts.PutOnPlate();
        }

        public static async Task PrepareEggsAsync(int eggQty)
        {
            Eggs.PreparePan();
            Eggs.PutInPan(eggQty);
            await Eggs.FryEggsAsync();
        }

        public static async Task PrepareBaconAsync(int baconQty)
        {
            Bacon.SlicesToPan(baconQty);
            await Bacon.FryBaconAsync();
        }

        // Static classes with static methods(actions).
        public static class Coffee
        {
            public static async Task BoilWaterAsync()
            {
                Console.WriteLine("Boiling water...");
                await Task.Delay(6000);
                Console.WriteLine("Hot water prepared for coffee.");
            }
            public static void PourInCup()
            {
                Console.WriteLine("Pouring coffee into cup.");
                Task.Delay(2000).Wait();
            }
            public static void ServeToCustomer()
            {
                Console.WriteLine("Serve coffee to customer.");
                Task.Delay(2500).Wait();
            }
        }

        public static class Toasts
        {
            public static async Task PutInToasterAsync()
            {
                Console.WriteLine("Put  bread in toaster...");
                await Task.Delay(5000);
                Console.WriteLine("Toust was baked!");
            }
            public static void PutButterOn()
            {
                Console.WriteLine("Appling butter on toust.");
                Task.Delay(2800).Wait();
            }
            public static void PutOnPlate()
            {
                Console.WriteLine("Toast on plate!");
                Task.Delay(1000).Wait();
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
                Task.Delay(2300).Wait();
            }
            public static async Task FryEggsAsync()
            {
                Console.WriteLine("Frying eggs...");
                await Task.Delay(8000);
                Console.WriteLine("Put eggs on the plate!");
            }
        }

        public static class Bacon
        {
            public static void SlicesToPan(int qty)
            {
                Console.WriteLine($"Putting {qty}  slices of bacon in pan");
                Task.Delay(1800).Wait();
            }
            public static async Task FryBaconAsync()
            {
                Console.WriteLine("Frying bacon...");
                await Task.Delay(7000);
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
namespace breakfast
{
    class Program
    {
        static void Main(string[] args)
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
            Coffee.BoilWater();
            Coffee.PourInCup();
            Eggs.Fry(eggQty);
            Bacon.Fry(baconQty);
            Toasts.PutInToaster();
            Toasts.PutButterOn();

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

        public static class Coffee
        {
            public static void BoilWater()
            {
                Console.WriteLine("Boiling water...");
                Task.Delay(4000).Wait();
                Console.WriteLine("Hot water prepared for coffee!");
                Task.Delay(1000).Wait();
            }

            public static void PourInCup()
            {
                Console.WriteLine("Pouring coffee into cup...");
                Task.Delay(2000).Wait();
                Console.WriteLine("Coffee was served to customer!");
                Task.Delay(1000).Wait();
            }

            // public static async Task ServeToCustomer()
            // {
            // await Task.Delay(2000);
            // }
        }

        public static class Toasts
        {
            public static void PutInToaster()
            {
                Console.WriteLine("Put  toast in toaster...");
                Task.Delay(3000).Wait();
                Console.WriteLine("Toust was baked!");
                Task.Delay(1000).Wait();
            }

            public static void PutButterOn()
            {
                Console.WriteLine("Putting butter on toust...");
                Task.Delay(2000).Wait();
                Console.WriteLine("Put toast with butter on plate!");
                Task.Delay(3000).Wait();
            }

            // public static async Task PrepareToServe()
            // {
            // Console.WriteLine("Toast was put on plate and its ready to be served!");
            // await Task.Delay(2000);
            // }
        }

        public static class Eggs
        {
            public static void Fry(int qty)
            {

                Console.WriteLine($"Preparing pan...");
                Task.Delay(2000).Wait();
                Console.WriteLine($"Crashing {qty} eggs in pan");
                Task.Delay(1000).Wait();
                // }

                // public static async Task Fry()
                // {
                Console.WriteLine("Frying eggs...");
                Task.Delay(4000).Wait();
                Console.WriteLine("Put eggs on the plate!");
                Task.Delay(1000).Wait();
            }

            // public static async Task PrepareToServe()
            // {
            // Console.WriteLine("Eggs were put on plate and its ready to be served!");
            // await Task.Delay(2000);
            // }
        }

        public static class Bacon
        {
            // public static async Task SlicesToPan(int qty)
            // {
            // Console.WriteLine($"Putting {qty}  slices of bacon in pan");
            // await Task.Delay(2500);
            // }

            public static void Fry(int qty)
            {
                Console.WriteLine($"Putting {qty}  slices of bacon in pan");
                Console.WriteLine("Frying bacon...");
                Task.Delay(6000).Wait();
                Console.WriteLine("Put bacon in plate");
                Task.Delay(1000).Wait();
            }

            // public static async Task PrepareToServe()
            // {
            // Console.WriteLine("Bacon was put on plate and its ready to be served!");
            // await Task.Delay(2000);
            // }
        }

        public static class Kitchen
        {
            // public static void PreparePan()
            // {
            // Console.WriteLine("Preparing pan for cooking...");
            // Task.Delay(2000).Wait();
            // }

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
// Code for calculating app duration
var watch = new System.Diagnostics.Stopwatch();

Console.WriteLine("Good morning! Let's have some breakfast");

// False meal trap
Console.WriteLine("What would you like to have?");
Console.WriteLine("----");
Console.ReadLine();
Console.WriteLine("----");
Console.WriteLine("EGGS with BACON? Excelent choice!");

// First input (out of 2)
Console.WriteLine("How many eggs:");
int eggQty;

// Accepts only numbers
while (!int.TryParse(Console.ReadLine(), out eggQty))
{
    Console.WriteLine("Please enter a number!");
}

// Start app calculating duration
watch.Start();

// Second chance to have an order
if (eggQty == 0)
{
    Cook.Warning();

    while (!int.TryParse(Console.ReadLine(), out eggQty))
    {
        Console.WriteLine("How about a number?;)");
    }
}

//  Cancel order
if (eggQty == 0)
{
    Console.WriteLine("Goodbye!");
    return;
}

// Second input
Console.WriteLine("How many slices of bacon:");
int baconQty;

// Input accepts only numbers 
while (!int.TryParse(Console.ReadLine(), out baconQty))
{
    Console.WriteLine("Please enter a number!");
}

// Types a word insted of zero 
string bacon = baconQty != 0 ? baconQty.ToString() : "NO";

// Cooking code
Console.WriteLine($"Your order: Omlet with {eggQty} eggs and {bacon} bacon slices. Coming right up!");
Console.WriteLine("----");

if (baconQty != 0)
{
    // Meal with bacon
    Cook.PreparePan();
    Eggs.CrashingToPan(eggQty);
    Eggs.Fry();
    Bacon.SlicesToPan(baconQty);
    Bacon.Fry();
    Toasts.PutInToaster();
    Coffee.BoilWater();

    // Serving meal
    Eggs.PutOnPlate();
    Bacon.PutOnPlate();
    Toasts.PutButterOn();
    Toasts.PutOnPlate();
    Coffee.PourInCup();
}
else
{
    // Meal without bacon
    Cook.PreparePan();
    Eggs.CrashingToPan(eggQty);
    Eggs.Fry();
    Toasts.PutInToaster();
    Coffee.BoilWater();

    // Searving meal
    Eggs.PutOnPlate();
    Toasts.PutButterOn();
    Toasts.PutOnPlate();
    Coffee.PourInCup();

}

Console.WriteLine("----");
Cook.Finish();

// Stop calculating app duration
watch.Stop();

Cook.Time(watch.ElapsedMilliseconds);

Console.WriteLine("----");
Console.WriteLine("Press any key to exit!");
Console.ReadKey();

public static class Coffee
{
    public static void BoilWater()
    {
        Console.WriteLine("Boiling water...");
        Thread.Sleep(4000);
    }

    public static void PourInCup()
    {
        Console.WriteLine("Pouring coffee into cup");
        Thread.Sleep(2400);
    }
}

public static class Toasts
{
    public static void PutInToaster()
    {
        Console.WriteLine("Tousting tousts");
        Thread.Sleep(4300);
    }

    public static void PutButterOn()
    {
        Console.WriteLine("Putting butter on toust");
        Thread.Sleep(2000);
    }

    public static void PutOnPlate()
    {
        Console.WriteLine("Putting toast with butter on plate");
        Thread.Sleep(1500);
    }
}

public static class Eggs
{
    public static void CrashingToPan(int qty)
    {
        Console.WriteLine($"Crashing {qty} eggs in pan");
    }

    public static void Fry()
    {
        Console.WriteLine("Frying eggs");
        Thread.Sleep(3000);
    }

    public static void PutOnPlate()
    {
        Console.WriteLine("Putting eggs on plate");
        Thread.Sleep(1200);
    }
}

public static class Bacon
{
    public static void SlicesToPan(int qty)
    {
        Console.WriteLine($"Putting {qty}  slices of bacon in pan");
        Thread.Sleep(2200);
    }

    public static void Fry()
    {
        Console.WriteLine("Frying bacon");
        Thread.Sleep(4000);
    }

    public static void PutOnPlate()
    {
        Console.WriteLine("Putting bacon on plate");
        Thread.Sleep(1400);
    }
}

public static class Cook
{
    public static void PreparePan()
    {
        Console.WriteLine("Prepareing pan for cooking...");
        Thread.Sleep(2100);
    }

    public static void Finish()
    {
        Console.WriteLine("Breakfast is ready! Enjoy");

    }

    public static void Warning()
    {
        Console.WriteLine("Sorry, but we can't prepare this meal without eggs.\nChoose another number, or type 0 again to cancel order:(");
    }

    public static void Time(double time)
    {
        Console.WriteLine($"Time needed for prepareing breakfast: {time / 1000} seconds");
    }
}


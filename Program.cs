//Console.WriteLine("labas, pasauli");


//1. kiausiniai su sonine
  //- iskepti kiauiniu;
  //- isikepti sonines;
  //- paskrudinti skrebuti;
  //- ant skrebucio uztepti sviesto
  //serviravimas:  
   //- kiausini, skrebuti, sonine ideeti i lekste; 

//2. kava arba arbata
   //- isvirti kavos
   //serviravimas: 
   //- kava ipilti i puodeli;
   //  -- is virdulio uzpili maltas kavo pupeles ;
   
   //* kiekvienas veiksmas uztruka laiko pvz 5s kiausiniai, virdulys 3s uzverda ;
   //* turi console isspausdinti kiekvieno veiksmo teksta; 
        //-- "warming thepan";
        //-- "cracking x eggs";
        //-- "putting y slices of bacon into the pan";
        //-- "breakfast is ready" - baigus darba;
    //* turi parodyti kiek laiko veike programa po input ivedimo;
    //* programa turi priimti du imputus
      //-- kiek kiausiniu kepsi ;
      //-- kiek sonines riekeliu kepsi;
      //-- jei nera inputo, tai turi irgi ivertinti;
         /// -- jein 0, tai nereikia net pradeti  warming pan;
  
  
  //TECHNINIAI NIUANSAI;
  //* reikia naudoti statines klases kiekvienam objektui;
     //--kavai;
     //--srekbuciui;
     //--kiausiniui;
     //--soninei;
  //* ir tureti tose klasese metodus(funkcijas), kurios uztrunka, kazkiek laiko;
    //--PourCoffee();
    //  --- atspausdina:"Pouring coffee into cup" ir uztrunka .5s;
    //-- clase turi tik metodus kurie spausdina teksta ir uztrunka kazkiek laiko ir viskas; 
    


    //GITHUB
    //* 2 branches;
    //* main -> isprestas uzdavinys;
    //* kitam branch-> tas pats uzdavinys tik su asinchronine implementacija
    //* conding convesions;

var watch = new System.Diagnostics.Stopwatch();

Console.WriteLine("Good morning! Let's have some breakfast");
Console.WriteLine("What would you like to have?");
Console.WriteLine("----");

//false meal trap
Console.ReadLine();

Console.WriteLine("----");
Console.WriteLine("EGGS with BACON? Excelent choice!");

Console.WriteLine("How many eggs:");
int eggQty;

while(!int.TryParse(Console.ReadLine(), out eggQty)){
  Console.WriteLine("Please enter a number!");
}

watch.Start();

if(eggQty == 0  ){
  Cook.Abort();
  return;
}

Console.WriteLine("How many slices of bacon:");
int baconQty;
while(!int.TryParse(Console.ReadLine(), out baconQty)){
  Console.WriteLine("Please enter a number!");
}


Console.WriteLine($"Meal with {eggQty} eggs and {baconQty}bacon slices commig up!");
Console.WriteLine("----");

if(baconQty != 0){
  //meal with bacon
  Cook.PreparePan();
  Eggs.CrashingToPan(eggQty);
  Eggs.Fry();
  Bacon.SlicesToPan(baconQty);
  Bacon.Fry();
  Toasts.PutInToaster();
  Coffee.BoilWater();

  //serving meal
  Eggs.PutOnPlate();
  Bacon.PutOnPlate();
  Toasts.PutButterOn();
  Toasts.PutOnPlate();
  Coffee.PourInCup();
} else {
  //meal without bacon
  Cook.PreparePan();
  Eggs.CrashingToPan(eggQty);
  Eggs.Fry();
  Toasts.PutInToaster();
  Coffee.BoilWater();

  //searving meal
  Eggs.PutOnPlate();
  Toasts.PutButterOn();
  Toasts.PutOnPlate();
  Coffee.PourInCup();

}

Console.WriteLine("----");
Cook.Finish();

watch.Stop();

Cook.Time(watch.ElapsedMilliseconds);

Console.WriteLine("Press any key to exit!");
Console.ReadKey();

public static class Coffee {
  public static void BoilWater(){
// Task.Delay(2000).ContinueWith(async (t)=>{
    Console.WriteLine("Boiling water...");
    Thread.Sleep(4000);
 //   });
  }

  public static void PourInCup(){
    Console.WriteLine("Pouring coffee into cup");
    Thread.Sleep(2400);
  }
}

class Toasts {
  public static void PutInToaster(){
    Console.WriteLine("Tousting tousts");
    Thread.Sleep(4300);
  }

  public static void PutButterOn(){
    Console.WriteLine("Putting butter on toust");
    Thread.Sleep(2000);
  }

  public static void PutOnPlate(){
    Console.WriteLine("Putting toast with butter on plate");
    Thread.Sleep(1500);
  }
}

class Eggs {
  public static void CrashingToPan(int qty){
    Console.WriteLine($"Crashing {qty} eggs in pan");
  }

  public static void Fry(){
    Console.WriteLine("Frying eggs");
    Thread.Sleep(3000);
  }

  public static void PutOnPlate(){
    Console.WriteLine("Puting eggs on plate");
    Thread.Sleep(1200);
  }
}

class Bacon{
    public static void SlicesToPan(int qty){
    Console.WriteLine($"Putting {qty}  slices of bacon in pan");
    Thread.Sleep(2200);
  }

  public static void Fry(){
    Console.WriteLine("Frying bacon");
    Thread.Sleep(4000);
  }

  public static void PutOnPlate(){
    Console.WriteLine("Putting bacon on plate");
    Thread.Sleep(1400);
  }
}

class Cook{
  public static void PreparePan(){
    Console.WriteLine("Prepareing pan for cooking..");
    Thread.Sleep(2100);
  }

  public static void Finish(){
    Console.WriteLine("Breakfast is ready! Enjoy");

  }
  
  public static void Abort(){
    Console.WriteLine("Sorry, but we can not prepare this meal without eggs!");
  }

  public static void Time(double time){
    Console.WriteLine($"Time needed for prepareing breakfast: {time/1000} seconds");
  }
}


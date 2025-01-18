using System;

namespace SimpleChallenges{
public class MathProblems{

  public enum MathMethods{
    Fibonacci,
    RomanToArabic
    }
    // contructor
    public MathProblems(){
       Console.WriteLine("Do you want to solve few math problems?");
    Console.WriteLine("We have few to choose from:");
    foreach (MathMethods method in Enum.GetValues(typeof(MathMethods))){
    Console.WriteLine((int)method + ". " + method);  
    }

    Console.WriteLine("Choose from above by number");

    string line = Console.ReadLine();

    //todo: add idiot proof reading

    int number = Int32.Parse(line);

      switch ((MathMethods)number){
      case  MathMethods.Fibonacci:
        ShowFibonacci();
        break;
      case MathMethods.RomanToArabic:
        ShowRomanToArabic();
        break;
      }
    }

    public void ShowFibonacci(){
      Fibonacci fibonacci = new Fibonacci();
     
  Console.WriteLine("Let's do Fibonacci Sequence!");  
      fibonacci.ShowFibonacciSequence(10);
    Console.WriteLine();
Console.WriteLine("Interactice way !10: "+ fibonacci.Iteractive(10));
      
  Console.WriteLine("Recursive way !10: " +fibonacci.Recursive(10));

    } // end ShowFibonnaci
public void ShowRomanToArabic(){
  Console.Write("Roman number to convert:");
  string line = Console.ReadLine();

    //todo: add idiot proof reading, for now we assume roman number is correct

   
  RomanToArabic converter = new RomanToArabic(line);
Console.WriteLine(converter.GetRomanNumber());
  Console.WriteLine(converter.ConvertToArabic());
} // end ShowRomanToArabic

  private class Fibonacci{

    //get value iteractice way
  public int Iteractive(int length){
    int previousNumber = 0;
    int currentNumber = 0;

    for (int i = 0; i < length; i++ ){
// we need to make sure first number (index 0) is set correctly
      if (i < 1) {
        previousNumber = 0;
        currentNumber = 1;
        continue;
      }
        
      int temp = previousNumber;
       previousNumber = currentNumber;
      currentNumber +=temp;
    }
    return currentNumber;
  }

    //get value recursive way
  public int Recursive(int length){
      return getRecursiveNumber(length); 
}

  public void ShowFibonacciSequence(int length, bool recursive = true){

    Console.WriteLine("Show fibonacci sequence !"+length + ": ");
  if (recursive){
      for (int i = 0;i <= length;i++){
        Console.Write(getRecursiveNumber(i)+" ");
      } 
    }
    else{
      for (int i = 0; i<= length; i++){
        Console.Write(Iteractive(i)+" ");  
      }
    } 
   } // end ShowFibonacciSequence
  
  private int getRecursiveNumber(int place) {
    if (place == 0)
      return 0;

    if (place == 1)
      return 1;

    return getRecursiveNumber(place-1) + getRecursiveNumber(place-2);
      
  } 
  
} //end Class Fibonacci 
}

  public class RomanToArabic
  {
    private enum RomanNumerals
    {
      I = 1,
      V = 5,
      X = 10,
      L = 50,
      C = 100,
      D = 500,
      M = 1000
    }

private string romanNumber = "";

    public string GetRomanNumber()
    {return romanNumber;}

    
    public RomanToArabic(string romanNumber){
      this.romanNumber = romanNumber;
    }

    public int ConvertToArabic(){
      return ConvertToArabic(this.romanNumber);
    }
    
    public int ConvertToArabic(string roman){
     int arabic = 0;
      
     for (int i = 0; i < roman.Length; i++){
    RomanNumerals currentNumeral = (RomanNumerals)Enum.Parse(typeof(RomanNumerals), roman[i].ToString());
       
    switch (currentNumeral) {
      case RomanNumerals.M:
    //   Console.WriteLine("M");
       int howManyM = roman.LastIndexOf("M")+1; //+1 because index starts at 0

      arabic += howManyM*1000; 
       i+=howManyM-1; //move counter to next numerals
      break;
     
    case RomanNumerals.D:
   //    Console.WriteLine("D");
       if (i>=1 && roman[i-1] == 'C') 
        arabic += 400;
      else if (i < 1 || (i >= 1 && roman[i-1] != 'C'))
        arabic += 500;
      break;
    case RomanNumerals.C:
   //    Console.WriteLine("C");
      if (i == 0 || (i< roman.Length && roman[i+1] != 'D')) 
      {
      int howManyC = roman.LastIndexOf("C")-roman.IndexOf("C")+1; 

      arabic += howManyC*100; 
       i+=howManyC-1; //move counter to next numberls
        }
      break;
    case RomanNumerals.L:
   //    Console.WriteLine("L");
       if (i>=1 && roman[i-1] == 'X') 
        arabic += 40;
      else if (i < 1 || (i >= 1 && roman[i-1] != 'X'))
        arabic += 50;
      break;
    case RomanNumerals.X:
   //    Console.WriteLine("X");
      // XL case already covered with RomanNumerals.L case
      if (i == 0 || (i< roman.Length && roman[i+1] != 'L')) {
      int howManyX = roman.LastIndexOf("X")-roman.IndexOf("X")+1; 
 
      arabic += howManyX*10; 
       i+=howManyX-1; //move counter to next numberls
        }
      break;
    case RomanNumerals.V:
   //    Console.WriteLine("V");
       if (i>=1 && roman[i-1] == 'I') 
        arabic += 4;
      else if (i < 1 || (i >= 1 && roman[i-1] != 'I'))
        arabic += 5;
      break;
    case RomanNumerals.I:
   //    Console.WriteLine("I");
      // IV case already covered with RomanNumerals.V case
if (i == 0 || (i< roman.Length && roman[i+1] != 'V')) 
      {
      int howManyI = roman.LastIndexOf("I")-roman.IndexOf("I")+1;

      arabic += howManyI*1; 
       i +=howManyI-1; //move counter to next numberls
        }
      break;
        } // end switch
          
      } // end for i
            
      return arabic;
      } 
  } // end class RomanToArabic
  
} //end namespace Simple Challenges
using System;

namespace SimpleChallenges{
public class MathProblems{

  public enum MathMethods{
    Fibonacci
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
  
} //end namespace Simple Challenges
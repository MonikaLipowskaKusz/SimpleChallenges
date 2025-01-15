using System;
using System.Linq;

namespace SimpleChallenges{
public class Sorting{
  public enum SortingMethods{
    InsertSort,
    BubbleSort,
    BucketSort,
    ShellSort1,
    ShellSort2
  }

  private int[] values = { 3, 4, 5, 2, 1, 6, 9, 8, 7};

  private int[] sortedValues = {};

  public Sorting(){
    Console.WriteLine("Welcome to Sorting methods");
    Console.WriteLine("We have few to choose from:");
    foreach (SortingMethods method in Enum.GetValues(typeof(SortingMethods))){
    Console.WriteLine((int)method + ". " + method);  
    }

    Console.WriteLine("Choose from above by number");

    string line = Console.ReadLine();

    //todo: add idiot proof reading

    int number = Int32.Parse(line);

 Console.WriteLine("Unsorted: "+string.Join(",", this.values));
        
    switch ((SortingMethods)number)
    {
      case SortingMethods.BubbleSort:
      sortedValues = BubbleSort(values);
        break;
      case SortingMethods.InsertSort:
      sortedValues = InsertSort(values);
        break;
      case SortingMethods.BucketSort:
      sortedValues = BucketSort(values, 1, 9);
        break;
      case SortingMethods.ShellSort1:
      sortedValues = ShellSort(values);
      break;
      case SortingMethods.ShellSort2:
      sortedValues = ShellSort2(values);
        break;
    }

    Console.WriteLine("Sorted: "+string.Join(",", sortedValues));
  } // end constructor

  public int[] BubbleSort(int[]values){
  
    int length = values.Length;
 for (int i = 0;i < length-1;i++)
    {
      for (int j = 0; j < length-i-1; j++){
         if (values[j] > values[j+1])
           values = swap(values, j,j+1);
        } // end for j
    } //end for i
    return values;
  } //end method BubbleSort
  
  public int[] InsertSort(int[]values){
    int length = values.Length;
    
    for (int i = 0; i < length-1; i++)
    {
      for (int j = i+1; j > 0; j--){
         if (values[j] < values[j-1])
           values = swap(values, j,j-1);
        } // end for j
    } //end for i
    
    return values;
    } // end method InsertSort

  public int[] BucketSort(int[] values, int min, int max){
    int length = values.Length;
    int[] sorted = {}; 
    int[] buckets = new int[max-min+1];

    // create buckets and count how many times value felt into it
    for (int i = 0; i < length; i++){
      buckets[values[i]]++;
    }

    // go throught buckets to create sorted values
    for (int i = 0; i < buckets. Length-1; i++){
      // if bucket is empty,values like this doesnt exist, move on
      if (buckets[i] == 0){
        continue;
      }

      //add each value in current bucket to sorted valued 
      for (int j = 0; j < buckets[i]; j++){
          sorted.Append(i);
      }
      
    }
    
    return sorted;
  } //end method BucketSort

  public int[] ShellSort(int[] values){

    int interval = shellSortIntervalbyShell(values.Length);

    for (int i = interval; i > 0; i = shellSortIntervalbyShell(i)){
      for(int j = 0; j<i; j++){  
        // create subset
        int[] subset = new int[values.Length/i];
        for(int k = 0; k < subset.Length; k++){
          subset[k] = values[i*k+j];
        }
      //sort it
      subset = InsertSort(subset);

      //put it back      
      for(int k = 0; k < subset.Length; k++){
          values[i*k+j] = subset[k];
          }
       
      }
    }
    return values;
  } // end method ShellSort

  // algoritm from description from site:
//https://eduinf.waw.pl/inf/alg/003_sort/0012.php
  // author: Jerzy Walaszek
  public int[] ShellSort2(int[] values){

    int interval = shellSortIntervalbyKnuth(values.Length);

    // it works while interval is bigger then 0; we will change interval after each loop pass
    while(interval > 0)
   {
    // j - index needed to check all valurs in interval
    // x - last value to swap in the end
    // i - index of sorted list 
    for(int j = values.Length- interval - 1; j >= 0; j--)
   {
      int x = values[j];
      int i = j + interval;
      while((i < values.Length) && (x > values[i]))
      {
        values[i - interval] = values[i];
        i += interval;
      }
      values[i - interval] = x;
    }
    interval = shellSortIntervalbyKnuth(interval);
  }
    return values;
    } // end method ShellSort2
  
  // ShellSort: intervals can be created in different ways, Shell proposed just to divide by 2
  private int 
shellSortIntervalbyShell(int length){
    return length/2;
  }

  // ShellSort: intervals can be created in different ways, Donald Knuth proposed this way
  private int 
shellSortIntervalbyKnuth(int length, bool initialInterval = false){
    if (initialInterval == true){
      int h = 0;
      for (int i = 1; i < length;i++){
         h = 3*i+1;
      }
      h = h/9;
      if (h == 0)
        h = 1;
      return h;
    } else
       return length/3;
  }

  
  private int[] swap(int[] values, int index1, int index2){
    try{
    
    int temp = values[index1];
    values[index1] = values[index2];
    values[index2] = temp;
      //Console.WriteLine("Swapped: "+values[index1]+ values[index2]);
      return values;
    }
    catch(IndexOutOfRangeException e){
      Console.WriteLine("Exception:  "+e.Message);
      return values;
    }
  }
    } //end class Sorting
  } // end namespace
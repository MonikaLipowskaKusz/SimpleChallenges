using System;

namespace SimpleChallenges{
public class Sorting{
  public int[] BubbleSort(int[]values){

    int length = values.Length;

    for (int i = 0; i < length-1; i++)
    {
      for (int j = 0; j < length-i-1; j++){
         if (values[j] > values[j+1])
           values = swap(values, j,j+1);
        } // end for j
    } //end for i
    return values;
  }
  
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
    }
  
  
  private int[] swap(int[] values, int index1, int index2){
    try{
    
    int temp = values[index1];
    values[index1] = values[index2];
    values[index2] = temp;
      return values;
    }
    catch(IndexOutOfRangeException e){
      Console.WriteLine("Index out of range: "+e.Message);
      return values;
    }
    
  }
} // end class Sorting
  } // end namespace
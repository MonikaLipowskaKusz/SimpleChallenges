using System;
using System.Linq;

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

    int interval = shellSortInterval(values.Length);

    for (int i = interval; i > 0; i = shellSortInterval(i)){
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

  // intervals can be created in different ways, Shell propose just to divide by 2
  private int 
shellSortInterval(int length){
    return length/2;
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
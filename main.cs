using System;

class Program
{
  public static void Main(string[] args){
  Console.WriteLine("Hello World");

    //1: BinaryTree
   /* {
    int[] values = { 3, 4, 5, 2, 1, 6, 9, 8, 7 };
    
    BinaryTree tree = new BinaryTree(values);
    tree.ShowMeTree();
    } // end 1: BinaryTree
*/
    //2: Fibonacci
    /*
    Fibonacci fibonacci = new Fibonacci();
    fibonacci.Iteractive(5);
    fibonacci.Recursive(5);
    fibonacci.ShowNumber(10);
      */

    //3: Sorting
    Sorting sorting = new Sorting();

    int[] values = { 3, 4, 5, 2, 1, 6, 9, 8, 7 };

    int[] sortedValues = {};

    //sortedValues = sorting.BubbleSort(values);
    sortedValues = sorting.InsertSort(values);
    
    Console.WriteLine("Sorted: "+string.Join(",", sortedValues));
    
  }
  
    public class BinaryTree{
  public class Node{
    public int value;
    public Node left;
    public Node right;

    // constructor
    public Node(int value)
    {
        this.value = value;
        this.left = null;
        this.right = null;
    }
  }

  public Node root = null;

  //constructor to make sure new BinaryTree has empty root
  public BinaryTree()
  {
    this.root = null;
  }

  // contructor with array of ints, to create BinaryTree from them
  public BinaryTree(int[] values){
    if (values.Length == 0) {
      return;
    }

    for (int i = 0; i < values.Length; i++)
    {
      this.root = this.Insert(this.root, values[i]);
    }
  }


  public void ShowMeTree(){
    if (this.root == null){
      Console.WriteLine("Tree is empty ");
      return;
    }
    
    Console.WriteLine("Root value is: " + root.value);
    Traverse(this.root);
  }

  // go through tree (traverse) and show values, from left to right (so in numeric order)
  public void Traverse(Node node){
    if (node != null){
      Traverse(node.left);
    Console.WriteLine(node.value);        Traverse(node.right);
    }
  }
  
  public Node Insert(Node root, int value){
    if (root == null){
      root = new Node(value);
    } else if (value < root.value){
      root.left = Insert(root.left, value);
    } else {
      root.right = Insert(root.right, value);
    }

    return root;
  }
} // end class BinaryTree

public class Fibonacci{
  public void Iteractive(int length){
    int previousNumber = 0;
    int currentNumber = 0;

    for (int i = 0; i < length; i++ ){
 Console.WriteLine(currentNumber);
      // we need to make sure first number (index 0) is set corectly
      if (i < 1) {
        previousNumber = 0;
        currentNumber = 1;
        continue;
      }
        
      int temp = previousNumber;
        previousNumber = currentNumber;
        currentNumber +=temp;
    }
  }
  public void Recursive(int length){
    for (int i = 0; i < length;i++){
    Console.WriteLine(getRecursiveNumber(i));
      }
}

  public void ShowNumber(int place){
    Console.WriteLine( getRecursiveNumber(place));
  }
  
  private int getRecursiveNumber(int place) {
    if (place == 0)
      return 0;

    if (place == 1)
      return 1;

    return getRecursiveNumber(place-1) + getRecursiveNumber(place-2);
      
  } 
  
} //end Class Fibonacci

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
}  

} //end Program



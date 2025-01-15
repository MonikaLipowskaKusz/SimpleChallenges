using System;

namespace SimpleChallenges{
public class DataStructures{

  public enum DataStructuresType{
    BinaryTree
    }

    // contructor
    public DataStructures(){

      Console.WriteLine("Welcome to wonderful world of DataStructures!");
    Console.WriteLine("We have few to choose from:");
    foreach (DataStructuresType method in Enum.GetValues(typeof(DataStructuresType))){
    Console.WriteLine((int)method + ". " + method);  
    }

    Console.WriteLine("Choose from above by number");

    string line = Console.ReadLine();

    //todo: add idiot proof reading

    int number = Int32.Parse(line);
      
switch ((DataStructuresType)number){
      case  DataStructuresType.BinaryTree:
        int[] values = { 3, 4, 5, 2, 1, 6, 9, 8, 7 };
         Console.WriteLine("Values to add to tree: "+string.Join(",", values));
        BinaryTree tree = new BinaryTree(values);
        tree.ShowMeTree();
    
        break;
  }
      
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
      return;
    }
    Console.WriteLine("Values in tree from left to right: ");
    Traverse(this.root);
  }

  // go through tree (traverse) and show values, from left to right (so in numeric order)
  public void Traverse(Node node){
    if (node != null){
      Traverse(node.left); 
      Console.Write(node.value +" ");        
      Traverse(node.right);
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
}
  
} //end namespace Simple Challenges
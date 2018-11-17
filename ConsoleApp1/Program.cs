using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      BinaryTree bt = new BinaryTree();  //Create a Binary Tree
      bt.Root = new Node(1);
      bt.Root.Left = new Node(2);
      bt.Root.Right = new Node(3);
      bt.Root.Left.Left = new Node(4);
      bt.Root.Left.Right = new Node(5);
      bt.Root.Right.Left = new Node(6);
      bt.Root.Right.Right = new Node(7);

      Console.WriteLine("Zigjag BFS traversal of  binary tree  is ");
      bt.PrintBFSOrder(bt.Root);   //Print BFS Mode and reverse at each level while printing 
      Console.ReadKey();
    }
  }

  class Node
  {
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int item)
    {
      this.Data = item;
      this.Left = this.Right = null;
    }
  }

  class BinaryTree
  {
    public Node Root { get; set; }
    public BinaryTree()
    {
      this.Root = null;
    }


    int HeightOfTree(Node current)
    {
      
      if (current == null)
         return 0;
      else
      {

        int lhight = HeightOfTree(current.Left);
        int rhight = HeightOfTree(current.Right);
        return lhight > rhight ? lhight + 1 : rhight + 1;
      }      
    }
    ArrayList DatatoPrint = new ArrayList();
    void StoreLevel(Node current, int level)
    {
      if (current == null) return;
      if (level == 1)
      {
        DatatoPrint.Add(current.Data);       
        //Console.Write(current.Data + ",");
      }
      else
      {
        StoreLevel(current.Left, level - 1);
        StoreLevel(current.Right, level - 1);
       }
    }

    void ZigjagPrint(ArrayList Information, int Level)
    {
      if (Level % 2 == 1)
      {
        for (int i = 0; i< Information.Count;i++)
        {
          Console.Write(Information[i]);
        }
      }
      else
      {
        for (int i = Information.Count - 1; i >= 0; i--)
        {
          Console.Write(Information[i]);
        }
      }
    }
    public void PrintBFSOrder(Node tree)
    {
      this.Root = tree;
      int h = HeightOfTree(this.Root);
      for (int i = 1; i <= h; i++)
      {
        StoreLevel(this.Root, i);        
        ZigjagPrint(DatatoPrint, i);
        DatatoPrint.Clear();
      }
    }
  }
}

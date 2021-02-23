using System;
using List = ListTreeSort.List<int>;
using Tree = ListTreeSort.Tree<int>;
using static System.Console;

namespace Web_d_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Creating List...");
            List MyList = new List();
            for (int i = 1; i <= 10; i++)
            {
                MyList.Add(i);
            }
            Write("\nThe list is generated: ");
            MyList.GetList();
            
            WriteLine("\nDeleting the 5th element...");
            MyList.Remove(5);
            Write("The item was deleted, the current list: ");
            MyList.GetList();
            
            WriteLine("\nAdding element 21...");
            MyList.Add(21);
            Write("The item was added, the current list: ");
            MyList.GetList();
            
            WriteLine("\nInverting the list...");
            MyList.Reverse();
            Write("List was inverted, the current list: ");
            MyList.GetList();
            
            //------------------
            
            WriteLine("\nCreating Tree...");
            Tree MyTree = new Tree();
            MyTree.Generate(4);
            Write("Tree was created, current tree: ");
            MyTree.GetTree();
            
            WriteLine("\nSearching item with id 18...");
            
        }
    }
}
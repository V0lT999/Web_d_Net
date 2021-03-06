﻿using System;
using ListTreeSort;
using List = ListTreeSort.List<int>;
using Tree = ListTreeSort.Tree<int>;
using SL = ListTreeSort.SortArray;
// using Array = ListTreeSort.SortList;
using static System.Console;

namespace Web_d_Net
{
    class Program
    {
        static void Task1()
        {
            WriteLine("Creating List...");
            List MyList = new List();
            for (int i = 1; i <= 10; i++)
            {
                MyList.Add(i);
            }
            Write("The list was generated: ");
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
            WriteLine();
            //------------------
            
            WriteLine("\nCreating Tree...");
            Tree MyTree = new Tree();
            MyTree.Generate(4);
            Write("Tree was created, current tree: ");
            MyTree.GetTree();
            
            WriteLine("\nSearching item with id 18...");
            NodeTree<int> elem = MyTree.Search(18);
            WriteLine("Id of found element: " + elem.Id);
            WriteLine("Removing this element...");
            MyTree.Remove(elem);
            WriteLine("Current tree:");
            MyTree.GetTree();
            
            //------------------
            WriteLine();
            //------------------
            
            WriteLine("\nCreating array...");
            SL MySortArray = new SL();
            MySortArray.Generate(10);
            Write("The array was generated: ");
            MySortArray.GetArray();
            WriteLine("Sorting array...");
            MySortArray.Sort();
            Write("The array was sorted: ");
            MySortArray.GetArray();
        }
        
        static void Main(string[] args)
        {
           Task1();
        }
    }
}
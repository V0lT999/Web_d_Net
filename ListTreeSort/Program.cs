using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using static System.Console;

namespace ListTreeSort
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    
    
    public class List<T>: IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
 
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
 
            count++;
        }
        
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }
 
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Reverse()
        {
            
            Node<T> current = head;
            Node<T> previous = null;
            Node<T> next = current.Next;
            
            while (next != null)
            {
                current.Next = previous;
                previous = current;
                current = next;
                next = current.Next;
            }

            current.Next = previous;

            current = tail;
            tail = head;
            head = current;
        }
        
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        public void GetList()
        {
            Node<T> current = head;
            
            while (current != null)
            {
                Write(current.Data + " ");
                current = current.Next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    //---------------------------------------------------

    
    public class NodeTree<T>
    {
        public NodeTree(int id, T data)
        {
            Data = data;
            Id = id;
        }

        public NodeTree(int id)
        {
            Id = id;
        }

        public T Data { get; set; }
        public int Depth { get; set; }
        public int Id { get; set; }
        public NodeTree<T> Left { get; set; }
        public NodeTree<T> Right { get; set; }
    }
    
    public class Tree<T>
    {
        NodeTree<T> root;
        int n;
        public void Generate(int depth)
        {
            this.n = 0;
            NodeTree<T> root = new NodeTree<T>(this.n);
            this.root = root;
            CLR(this.root, 0, depth);
        }

        private void CLR(NodeTree<T> node, int depth, int ldepth)
        {
            node.Depth = depth;
            if(depth != ldepth)
            {
                this.n++;
                NodeTree<T> left_node = new NodeTree<T>(this.n);
                node.Left = left_node;
                CLR(left_node, depth + 1, ldepth);
                
                this.n++;
                NodeTree<T> right_node = new NodeTree<T>(this.n);
                node.Right = right_node;
                CLR(right_node, depth + 1, ldepth);
            }
            else
            {
                node.Left = null;
                node.Right = null;
            }
        }
        
        public void GetTree()
        {
            var queue = new Queue<NodeTree<T>>();
            queue.Enqueue(this.root);
            int current_depth = root.Depth;
            bool flag = true;
            while(flag)
            {
                try
                {
                    var current = queue.Dequeue();
                    if (current.Depth == current_depth)
                    {
                        Write(current.Id + " ");
                    }
                    else
                    {
                        Write("\n" + current.Id + " ");
                        current_depth = current.Depth;
                    }

                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);   
                    }

                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }
                }
                catch
                {
                    flag = false;
                    queue.Clear();
                }
            }
        }

        public NodeTree<T> Search(int id)
        {
            NodeTree<T> result = root;

            while (true)
            {
                if (result.Id == id)
                {
                    return result;
                }
                else
                {
                    if (result.Right.Id > id)
                    {
                        result = result.Left;
                    }
                    else result = result.Right;
                }
            }
        }
        
        private NodeTree<T> SearchParent(int id)
        {
            NodeTree<T> child = this.root;
            NodeTree<T> parent = null;
            
            while (true)
            {
                if (child.Id == id)
                {
                    return parent;
                } else if (child.Right.Id > id)
                {
                    parent = child;
                    child = child.Left;
                }
                else
                {
                    parent = child;
                    child = child.Right;
                }
            }
        }

        private void ChangeDepth(NodeTree<T> elem, int depth)
        {
            if (elem != null)
            {
                elem.Depth = depth;
                ChangeDepth(elem.Left, depth +  1);
                ChangeDepth(elem.Right, depth + 1);
            }
        }

        public void Remove(NodeTree<T> elem)
        {
            NodeTree<T> parent = SearchParent(elem.Id);
            if (elem.Right != null)
            {
                if (elem.Left != null)
                {
                    NodeTree<T> buf = elem.Left;
                    while (buf.Right != null)
                    {
                        buf = buf.Right;
                    }

                    buf.Right = elem.Right;
                }
                else
                {
                    elem.Left = elem.Right;
                }
            }

            if (parent != null)
            {
                if (parent.Left.Id == elem.Id)
                {
                    parent.Left = elem.Left;
                }
                else
                {
                    parent.Right = elem.Left;
                }
            }
            else
            {
                root = root.Left;
            }
            ChangeDepth(root, 0);
        }
    }
}
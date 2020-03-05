using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BFS
{   
    // Summary:
    //      Includes search algorithms.
    class Searches<T> 
    {
       public List<Node<T>> AStar(PriorityQueue<Node<T>,int> openList, Node<T> goal)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (openList.Any())
            {
                Node<T> current = openList.Dequeue();
                PathArrange(stack,current);
                current.IsVisited = true;
                if (current == goal)
                {
                    return StackToList(stack);
                }
                foreach (var temp in current.Neighbors)
                {
                    if (temp.neighbor.IsVisited == true)
                    {
                        break;
                    }
                    else
                    {
                        temp.neighbor.HandG[0, 1] = current.HandG[0, 1] + temp.DistanceToNeighbor;
                        //heuristic value is already defined at the beginning of declaration.
                        temp.neighbor.Depth = current.Depth + 1;
                        openList.Enqueue(temp.neighbor);
                    }
                }
            }
            return StackToList(stack);
            
            
        }

        private void PathArrange(Stack<Node<T>> stack, Node<T> current)
        {
            if (!stack.Any())
            {
                stack.Push(current);
                return;
            }
            while (stack.Peek().Depth >= current.Depth)
            {
                stack.Pop();
            }
            stack.Push(current);
            
        }

        private List<Node<T>> StackToList(Stack<Node<T>> stack)
        {
            List<Node<T>> temp = stack.ToList();
            temp.Reverse();
            return temp;
        }
        // Summary:
        //          Applies Breadth First Search algorithms using Queue Class and arranges distance variable of Node.
        // Parameters:
        //          root is used as the beginning node.
        //          richTextBox is RichTextBox reference that shows searched node's datas.
        public List<Node<T>> BreadthFirstSearch(Node<T> root, Node<T> goal)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                Node<T> current = queue.Dequeue();
                if (!current.IsVisited) {
                    PathArrange(stack,current);
                    current.IsVisited = true;

                    if (current == goal)
                    {
                        return StackToList(stack);
                    }
                    foreach (var temp in current.Neighbors)
                    {
                        temp.neighbor.Depth = current.Depth + 1;
                        queue.Enqueue(temp.neighbor);
                    }
                }
            }
            return StackToList(stack);
        }
    }
}

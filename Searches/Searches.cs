using System.Collections.Generic;
using System.Linq;


namespace Searches
{
    // Summary:
    //      Includes search algorithms.
    class Searches<T> 
    {
        public List<Node<T>> SimulatedAnnealing(PriorityQueue<Node<T>, int> openList, int temperature)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();

            Node<T> current = openList.Dequeue();
            Node<T> best = current;
            PathArrange(stack, current);
            current.IsVisited = true;

            do
            {
                foreach (var temp in current.Neighbors)
                {

                    if (temp.neighbor.IsVisited == true)
                    {
                        break;
                    }
                    else
                    {
                        temp.neighbor.Depth = current.Depth + 1;
                        openList.Enqueue(temp.neighbor);
                    }

                }
                current.IsVisited = true;
                Node<T> Si = openList.Dequeue();
                if (Si.F <= current.F)
                {
                    current = Si;
                    PathArrange(stack, current);
                    current.IsVisited = true;
                }
                else if (Si.F <= (current.F + temperature - current.Depth))
                {
                    current = Si;
                    PathArrange(stack, current);
                    current.IsVisited = true;
                }
                temperature = temperature - 1;

            } while (openList.Any());
            return StackToList(stack);
        }
        // Summary:
        //      Applies A Star Search algorithms using PriorityQueue Class, arranges f function and Depth of Node .
        // Parameters:
        //      openList:The given list it must include the initialized node.
        //      goal:search for the goal node.
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
        //      Applies Breadth First Search algorithms using Queue Class and arranges Depth of Node.
        // Parameters:
        //      root:used as the beginning node.
        //      goal:search for the goal node.
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

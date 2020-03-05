using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueAndStack;

namespace BFS
{   
    // Summary:
    //          Includes search algorithms.
    // Variables:
    //          queue is used for search algorithms.
    class Searches<T>
    {
        Queue queue;
        // Summary:
        //          Initializes the Searches Class. 
        public Searches()
        {
            queue = new Queue();
        }
        // Summary:
        //          Applies Breadth First Search algorithms using Queue Class and arranges distance variable of Vertex.
        // Parameters:
        //          root is used as the beginning node.
        //          richTextBox is RichTextBox reference that shows searched node's datas.
        public void BreadthFirstSearch(Vertex<T> root, RichTextBox richTextBox)
        {
            queue.Enqueue(root);
            while (!queue.isEmpty())
            {
                Vertex<T> temp = (Vertex<T>)queue.Dequeue();
                if (!temp.IsVisited) {
                    temp.IsVisited = true;
                    TextBoxWriter(temp, richTextBox);
                    foreach (var vertex in temp.Neighbors)
                    {
                        vertex.Distance = temp.Distance + 1;
                        queue.Enqueue(vertex);
                    }
                }
            }
        }
        private void TextBoxWriter(Vertex<T> temp,RichTextBox richTextBox)
        {
            richTextBox.Text += temp.Distance.ToString()+"  "+temp.ToString()+Environment.NewLine;
        }
    }
}

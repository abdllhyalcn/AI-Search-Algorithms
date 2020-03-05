using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Go()
        {
            Node<string> S = new Node<string>("S", 4);
            Node<string> A = new Node<string>("A", 2);
            Node<string> B = new Node<string>("B", 6);
            Node<string> C = new Node<string>("C", 2);
            Node<string> D = new Node<string>("D", 3);
            Node<string> G = new Node<string>("G", 0);

            Graph<string> graph = new Graph<string>();

            graph.Add(S, G, 12);
            graph.Add(S, A, 1);
            graph.Add(A, B, 3);
            graph.Add(A, C, 1);
            graph.Add(B, D, 3);
            graph.Add(C, D, 1);
            graph.Add(C, G, 2);
            graph.Add(D, G, 3);

            Func<Node<string>, int> func = delegate (Node<string> item) { return item.F; };
            PriorityQueue<Node<string>, int> priorityQueue = new PriorityQueue<Node<string>, int>(func);
            priorityQueue.Enqueue(S);


            Searches<string> searches = new Searches<string>();
            List<Node<string>> list=searches.AStar(priorityQueue,G);
            TextBoxWriter(list);
            graph.UnvisitAll();
        }

        private void TextBoxWriter(List<Node<string>> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                richTextBox.Text += list.ElementAt(i).Depth.ToString() + "  " + list.ElementAt(i).ToString() + Environment.NewLine;
            }
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "Depth    Searched(F) : Neighbors"+Environment.NewLine;
            Go();
        }
    }
}

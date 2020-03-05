using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searches
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Go()
        {
            Node<string> a = new Node<string>("a", 10);
            Node<string> b = new Node<string>("b", 10);
            Node<string> j = new Node<string>("j", 8);
            Node<string> f = new Node<string>("f", 7);
            Node<string> e = new Node<string>("e", 5);
            Node<string> g = new Node<string>("g", 3);
            Node<string> k = new Node<string>("k", 0);
            Node<string> i = new Node<string>("i", 6);


            Graph<string> graph=new Graph<string>();

            graph.Add(a, b, 0);
            graph.Add(a, j, 0);
            graph.Add(a, f, 0);
            graph.Add(j, k, 0);
            graph.Add(f, e, 0);
            graph.Add(f, g, 0);
            graph.Add(e, i, 0);
            graph.Add(i, k, 0);


            Func<Node<string>, int> func = delegate (Node<string> item) { return item.F; };
            PriorityQueue<Node<string>, int> priorityQueue = new PriorityQueue<Node<string>, int>(func);
            priorityQueue.Enqueue(a);


            Searches<string> searches = new Searches<string>();
            List<Node<string>> list = searches.SimulatedAnnealing(priorityQueue, 6);
            TextBoxWriter(list);
            graph.UnvisitAll();
        }

        private void TextBoxWriter(List<Node<string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                richTextBox.Text += list.ElementAt(i).Depth.ToString() + "  " + list.ElementAt(i).ToString() + Environment.NewLine;
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            richTextBox.Text = null;
            richTextBox.Text = "Depth    Searched(F) : Neighbors" + Environment.NewLine;
            Go();
        }

  
    }
}

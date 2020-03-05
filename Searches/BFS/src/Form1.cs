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
            Vertex<string> a = new Vertex<string>("A");
            Vertex<string> b = new Vertex<string>("B");
            Vertex<string> c = new Vertex<string>("C");
            Vertex<string> d = new Vertex<string>("D");
            Vertex<string> e = new Vertex<string>("E");
            Vertex<string> f = new Vertex<string>("F");
            Graph<string> genericGraph = new Graph<string>();

            genericGraph.Add(a, b);
            genericGraph.Add(a, e);
            genericGraph.Add(e, f);
            genericGraph.AddPair(b, c);
            genericGraph.AddPair(b, d);
            genericGraph.AddPair(d, c);

            Searches<string> searches = new Searches<string>();
            searches.BreadthFirstSearch(genericGraph.Vertices[0],richTextBox);
            genericGraph.UnvisitAll();
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "Distance    Searched : Neighbors"+Environment.NewLine;
            Go();
        }
    }
}

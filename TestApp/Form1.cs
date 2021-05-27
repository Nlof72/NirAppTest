using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatplotLibCLR;

namespace TestApp
{
    public partial class MarkType : Form
    {
        Graph gr;
        public MarkType()
        {
            InitializeComponent();
            gr = new Graph();
        }

        private void Plot_Click(object sender, EventArgs e)
        {

            string LineType = TypeLine.Text != "" ? TypeLine.Text : "-o";
            string[] Xtext = InputX.Text.Split(" ");
            double[] x = new double[Xtext.Length];
            for(int i = 0; i < Xtext.Length; i++)
            {
                if(Xtext[i] == "")
                {
                    continue;
                }
                x[i] = double.Parse(Xtext[i]);
            }

            if (InputY.Text != "")
            {
                string[] Ytext = InputY.Text.Split(" ");
                double[] y = new double[Ytext.Length];
                for (int i = 0; i < Xtext.Length; i++)
                {
                    if (Ytext[i] == "")
                    {
                        continue;
                    }
                    y[i] = double.Parse(Ytext[i]);
                }
                gr.Plot(x, y, "-o");
            }else
            {
                gr.Plot(x, "-o");
            }

        }
    }
}

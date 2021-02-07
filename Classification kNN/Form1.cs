using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classification_kNN
{
    public partial class Form1 : Form
    {
        kNN knn;
        public Form1()
        {
            InitializeComponent();
            knn = new kNN();
            knn.LoadData();
        }
        private void Lern_Click(object sender, EventArgs e)
        {
            knn.StartLerning();
        }

        private void getClass_Click(object sender, EventArgs e)
        {
            string[] rt = textBox1.Text.Split('\t');
            double[] unknown = new double[7];
            int i = 0;
            foreach(string t in rt)
            {
                if (i == 7)
                    break;
                unknown[i] = Convert.ToDouble(t);
                i++;
            }
            var classnumber=knn.StartGettingClass(unknown);
            label2.Text = classnumber.ToString();
            label2.Visible = true;
        }
    }
}

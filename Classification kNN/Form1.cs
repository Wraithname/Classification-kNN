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
        string filePath;
        kNN knn;
        public Form1()
        {
            InitializeComponent();
            knn = new kNN();
        }

        private void chooseFolder_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd=new OpenFileDialog())
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }
        }

        private void Lern_Click(object sender, EventArgs e)
        {
            double[,] prepere = new double[7, 2020];
            if (File.Exists(filePath))
            {
                string readText = File.ReadAllText(filePath);
                string[] ment = readText.Split('\n');
                int i = 0;
                foreach(string k in ment)
                {
                    string[] l = k.Split('\t');
                    if(i<2020)
                    for(int j=0;j<7;j++)
                    {
                        prepere[j, i] = Convert.ToDouble(l[j]);
                    }
                    i++;
                }
            }
            knn.StartLerning(prepere);
        }

        private void getClass_Click(object sender, EventArgs e)
        {

        }
    }
}

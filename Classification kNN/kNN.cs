using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_kNN
{
    class kNN
    {
        int[] classyfied;
        string workpath;
        Dictionary<int, double[,]> lerningEtalon = new Dictionary<int, double[,]>();
        public void StartLerning(double[,] znach, int k = 5)
        {
           
           
        }

        public int StartGettingClass(double[] unknown)
        {
            int findedclass = 1;


            return findedclass;
        }
        private static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
        {
            double d = 0.0;

            for (int i = 0; i < sampleOne.Length; i++)
            {
                double temp = sampleOne[i] - sampleTwo[i];
                d += temp * temp;
            }
            return Math.Sqrt(d);
        }
        public void LoadData()
        {
            workpath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(workpath + @"\Classes"))
            {
                Directory.CreateDirectory(workpath + @"\Classes");
            }
            var classes = Directory.GetFiles(workpath + @"\Classes");
            classyfied = new int[classes.Length];
            for (int i = 0; i < classes.Length; i++)
            {
                classyfied[i] = Convert.ToInt32((classes[i].Split('\\').Last()).Split('.').First());
            }
        }
    }
}

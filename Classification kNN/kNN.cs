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
        string workpath;
        List<double[]> lerningEtalon1 = new List<double[]>();
        List<double[]> lerningEtalon2 = new List<double[]>();
        List<double[]> etalonClass1 = new List<double[]>();
        List<double[]> etalonClass2 = new List<double[]>();
        List<double[]> all = new List<double[]>();

        public kNN()
        {
            LoadData();
        }

        public void StartLerning()
        {
            double[] etalVect;
            etalVect = lerningEtalon1.First();
            lerningEtalon1.Remove(etalVect);
            all.Remove(etalVect);
            Dictionary<int, double> distance = new Dictionary<int, double>();
            bool flag = true;
            while (lerningEtalon1.Count != 0)
            {
                if (!flag)
                {
                    etalVect = lerningEtalon1.First();
                    lerningEtalon1.Remove(etalVect);
                    all.Remove(etalVect);
                }
                for (int i = 0; i < all.Count; i++)
                {
                    double[] vect = all.ElementAt(i);
                    distance[i] = EuclideanDistance(etalVect, vect);
                }
                distance = distance.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                var vl = distance.Keys.First();
                double[] kt = all.ElementAt(vl);
                if (kt[7] == 1)
                {
                    all.Remove(kt);
                    distance.Clear();
                    flag = true;
                }
                if (kt[7] == 2)
                {
                    if (flag)
                    {
                        etalonClass1.Add(etalVect);
                        all.Clear();
                        RefreshAll();
                    }
                    distance.Clear();
                    flag = false;
                }
            }
            WriteToFile(etalonClass1, "Class 1");
            all.Clear();
            RefreshAll();
            etalVect = lerningEtalon2.First();
            lerningEtalon2.Remove(etalVect);
            all.Remove(etalVect);
            flag = true;
            while (lerningEtalon2.Count != 0)
            {
                if (!flag)
                {
                    etalVect = lerningEtalon2.First();
                    lerningEtalon2.Remove(etalVect);
                    all.Remove(etalVect);
                }
                for (int i = 0; i < all.Count; i++)
                {
                    double[] vect = all.ElementAt(i);
                    distance[i] = EuclideanDistance(etalVect, vect);
                }
                distance = distance.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                var vl = distance.Keys.First();
                double[] kt = all.ElementAt(vl);
                if (kt[7] == 2)
                {
                    all.Remove(kt);
                    distance.Clear();
                    flag = true;
                }
                if (kt[7] == 1)
                {
                    if (flag)
                    {
                        etalonClass2.Add(etalVect);
                        all.Clear();
                        RefreshAll();
                    }
                    distance.Clear();
                    flag = false;
                }
            }
            WriteToFile(etalonClass1, "Class 2");
        }

        public int StartGettingClass(double[] unknown)
        {
            int findedclass = 1;


            return findedclass;
        }
        private static double EuclideanDistance(double[] sampleOne, double[] sampleTwo)
        {
            double d = 0.0;
            for (int i = 0; i < 7; i++)
            {
                d += (sampleOne[i] - sampleTwo[i]) * (sampleOne[i] - sampleTwo[i]);
            }
            return Math.Sqrt(d);
        }
        private void LoadData()
        {
            workpath = Directory.GetCurrentDirectory();
            if (Directory.Exists(workpath + @"\Classes"))
            {
                var classes = Directory.GetFiles(workpath + @"\Classes");
                int cl = 1;
                List<double[]> temp = new List<double[]>();
                double[] vect = new double[8];
                double[] vectnorm = new double[7];
                foreach (string path in classes)
                {
                    string readText = File.ReadAllText(path);
                    string[] ment = readText.Split('\n');
                    temp.Clear();
                    foreach (string k in ment)
                    {
                        string[] l = k.Split('\t');
                        for (int j = 0; j < 7; j++)
                        {
                            vect[j] = Convert.ToDouble(l[j]);
                            vectnorm[j] = Convert.ToDouble(l[j]);
                        }

                        vect[7] = cl;
                        all.Add(vect);
                        if (cl == 1)
                            lerningEtalon1.Add(vectnorm);
                        else
                            lerningEtalon2.Add(vectnorm);
                        vect = new double[8];
                        vectnorm = new double[7];
                    }
                    cl++;
                }
            }
        }
        private void RefreshAll()
        {
            workpath = Directory.GetCurrentDirectory();
            if (Directory.Exists(workpath + @"\Classes"))
            {
                var classes = Directory.GetFiles(workpath + @"\Classes");
                int cl = 1;
                List<double[]> temp = new List<double[]>();
                double[] vect = new double[8];
                double[] vectnorm = new double[7];
                foreach (string path in classes)
                {
                    string readText = File.ReadAllText(path);
                    string[] ment = readText.Split('\n');
                    temp.Clear();
                    foreach (string k in ment)
                    {
                        string[] l = k.Split('\t');
                        for (int j = 0; j < 7; j++)
                        {
                            vect[j] = Convert.ToDouble(l[j]);
                        }

                        vect[7] = cl;
                        all.Add(vect);
                        vect = new double[8];
                    }
                    cl++;
                }
            }
        }
        private void WriteToFile(List<double[]> result, string name)
        {
            workpath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(workpath+@"\Etalon"))
                Directory.CreateDirectory(workpath + @"\Etalon");

            string pathCsvFile = workpath + @"\Etalon\"+name+".csv";
            string delimiter = ";";
            StringBuilder sb = new StringBuilder();
            int j = 0;
            foreach (double[] t in result)
            {
                    sb.AppendLine(string.Join(delimiter, result[j]));
                j++;
            }
            File.WriteAllText(pathCsvFile, sb.ToString());
        }
    }
}

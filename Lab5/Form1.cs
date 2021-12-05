using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        double[,] Incomes;
        double[] Probabs;
        double[] Bcriteries;
        public Form1()
        {
            InitializeComponent();
            Incomes = new double[4, 5];
            Probabs = new double[5];
            Bcriteries = new double[4];
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string filepath = "";
            DataTable a = new DataTable();
            DataRow r;
            a.Columns.Add("θ1");
            a.Columns.Add("θ2");
            a.Columns.Add("θ3");
            a.Columns.Add("θ4");
            a.Columns.Add("θ5");
            int i = 0;
            string[] oneX = new string[5] { "=", "=", "=", "=", "=" };
            string l = new string(" ");
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Text files(*.txt)|*.txt";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                filepath = openfile.FileName;

                Stream fileStream = openfile.OpenFile();

                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (l != null)
                    {
                        l = reader.ReadLine();
                        if (l == null)
                        {
                            break;
                        }
                        oneX = l.Split(" ");
                        r = a.NewRow();
                        r["θ1"] = oneX[0];
                        r["θ2"] = oneX[1];
                        r["θ3"] = oneX[2];
                        r["θ4"] = oneX[3];
                        r["θ5"] = oneX[4];
                        a.Rows.Add(r);
                        if (i < 4)
                        {
                            Incomes[i, 0] = Convert.ToDouble(oneX[0]);
                            Incomes[i, 1] = Convert.ToDouble(oneX[1]);
                            Incomes[i, 2] = Convert.ToDouble(oneX[2]);
                            Incomes[i, 3] = Convert.ToDouble(oneX[3]);
                            Incomes[i, 4] = Convert.ToDouble(oneX[4]);
                            i++;
                        }
                        else {
                            Probabs[0] = Convert.ToDouble(oneX[0]);
                            Probabs[1] = Convert.ToDouble(oneX[1]);
                            Probabs[2] = Convert.ToDouble(oneX[2]);
                            Probabs[3] = Convert.ToDouble(oneX[3]);
                            Probabs[4] = Convert.ToDouble(oneX[4]);
                        }
                    }
                }
                dgvIncome.DataSource = a;
                fileStream.Close();
                btnBayes.Enabled = true;
            }
        }

        private void btnBayes_Click(object sender, EventArgs e)
        {
            double[] criteries = new double[4];
            for(int i = 0; i < 4; i++)
            {
                criteries[i] = Incomes[i, 0] * Probabs[0] + Incomes[i, 1] * Probabs[1] + Incomes[i, 2] * Probabs[2] + Incomes[i, 3] * Probabs[3] + Incomes[i, 4] * Probabs[4];
            }
            criteries.CopyTo(Bcriteries,0);
            lblBayes.Visible = true;
            lblBayes.Text = "c1 = " + criteries[0] + "\nc2 = " + criteries[1] + "\nc3 = " + criteries[2] + "\nc4 = " + criteries[3] 
                + "\nIndex of best choose: " + (Array.IndexOf(criteries, criteries.Max())+1);
            btnSV.Enabled = true;
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            double[,] alphaCoefs = FindAlpha();
            double[] probabCoefs = SumProbabCoefs(alphaCoefs);
            double[] semivarCoefs = new double[4] { 0.0, 0.0, 0.0, 0.0 };
            for (int i = 0; i < Incomes.GetUpperBound(0)+1; i++)
            {
                for(int j=0;j < Incomes.GetUpperBound(1)+1; j++)
                {
                    semivarCoefs[i] += alphaCoefs[i, j] * Probabs[j] * Math.Pow(Incomes[i, j] - Math.Round(Bcriteries[i],3), 2.0);
                }
                semivarCoefs[i] *= (1 / Math.Round(probabCoefs[i], 3));
            }
            lblSV.Visible = true;
            lblSV.Text = "c1 = " + semivarCoefs[0] + "\nc2 = " + semivarCoefs[1] + "\nc3 = " + semivarCoefs[2] + "\nc4 = " + semivarCoefs[3]
    + "\nIndex of best choose: " + (Array.IndexOf(semivarCoefs, semivarCoefs.Min()) + 1);

        }

        public double[,] FindAlpha()
        {
            double[,] alphas = new double[Incomes.GetUpperBound(0)+1, Incomes.GetUpperBound(1)+1];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (Bcriteries[i] > Incomes[i, j])
                    {
                        alphas[i, j] = 1;
                    }
                    else alphas[i, j] = 0;
                }
            }
            return alphas;
        }

        public double[] SumProbabCoefs(double[,] alphas)
        {
            double[] sums = new double[alphas.GetUpperBound(0)+1];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    sums[i] += Probabs[j] * alphas[i, j];
                }
            }
            return sums;
        }
    }
}

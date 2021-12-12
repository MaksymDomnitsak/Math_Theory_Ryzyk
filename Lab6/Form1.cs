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

namespace Lab6
{
    public partial class Form1 : Form
    {
        double[,] Incomes;
        double[] Probabs;
        double[] Bcriteries;
        public Form1()
        {
            InitializeComponent();
            Incomes = new double[4, 3];
            Probabs = new double[3];
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
            int i = 0;
            string[] oneX = new string[3] { "=", "=", "=" };
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
                        a.Rows.Add(r);
                        if (i < 4)
                        {
                            Incomes[i, 0] = Convert.ToDouble(oneX[0]);
                            Incomes[i, 1] = Convert.ToDouble(oneX[1]);
                            Incomes[i, 2] = Convert.ToDouble(oneX[2]);
                            i++;
                        }
                        else {
                            Probabs[0] = Convert.ToDouble(oneX[0]);
                            Probabs[1] = Convert.ToDouble(oneX[1]);
                            Probabs[2] = Convert.ToDouble(oneX[2]);
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
            double[,] riskmatrix = EvalRiskMatrix();
            double[] criteries = new double[4];
            for(int i = 0; i < 4; i++)
            {
                criteries[i] = riskmatrix[i, 0] * Probabs[0] + riskmatrix[i, 1] * Probabs[1] + riskmatrix[i, 2] * Probabs[2];
            }
            criteries.CopyTo(Bcriteries,0);
            lblBayes.Visible = true;
            lblBayes.Text = "c1 = " + criteries[0] + "\nc2 = " + criteries[1] + "\nc3 = " + criteries[2] + "\nc4 = " + criteries[3] 
                + "\nIndex of best choose: " + (Array.IndexOf(criteries, criteries.Max())+1);
            btnGurvits.Enabled = true;
        }

        private void btnGurvits_Click(object sender, EventArgs e)
        {
            double lambda = 0.2;
            double[] maxs = FindMaxs();
            double[] mins = FindMins();
            double[] Gurvitscriterias = new double[4];
            for(int i = 0; i < 4; i++)
            {
                Gurvitscriterias[i] = -Bcriteries[i] * 0.5 + ((1 - lambda) * maxs[i] + lambda * mins[i]) * 0.5;
            }
            lblSV.Visible = true;
            lblSV.Text = "c1 = " + Gurvitscriterias[0] + "\nc2 = " + Gurvitscriterias[1] + "\nc3 = " + Gurvitscriterias[2] + "\nc4 = " + Gurvitscriterias[3]
    + "\nIndex of best choose: " + (Array.IndexOf(Gurvitscriterias, Gurvitscriterias.Max()) + 1);

        }

        public double[,] EvalRiskMatrix()
        {
            double[,] risks = new double[ Incomes.GetUpperBound(0) + 1, Incomes.GetUpperBound(1) + 1];
            double max;
            for (int i = 0; i < Incomes.GetUpperBound(1) + 1; i++)
            {
                max = 0.0;
                for (int j = 0; j < Incomes.GetUpperBound(0) + 1; j++)
                {
                    if (Incomes[j, i] > max)
                    {
                        max = Incomes[j, i];
                    }
                }
                for (int j = 0; j < Incomes.GetUpperBound(0) + 1; j++)
                {
                    risks[j, i] = max - Incomes[j, i];
                }
            }
            return risks;
        }

        public double[] FindMaxs()
        {
            double[] maxs = new double[4] { 0.0, 0.0, 0.0, 0.0 };
            for (int i = 0; i < Incomes.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Incomes.GetUpperBound(1) + 1; j++)
                {
                    if (Incomes[i, j] > maxs[i])
                    {
                        maxs[i] = Incomes[i, j];
                    }

                }
            }
            return maxs;
        }

        public double[] FindMins()
        {
            double[] mins = new double[4] { 1000, 1000, 1000, 1000 };
            for (int i = 0; i < Incomes.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Incomes.GetUpperBound(1) + 1; j++)
                {
                    if (Incomes[i, j] < mins[i])
                    {
                        mins[i] = Incomes[i, j];
                    }
                }
            }
            return mins;
        }
    }
}

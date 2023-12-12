using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.MenshikovEA.Sprint6.TaskReview.V30.Lib;
using SortRow;

namespace Tyuiu.MenshikovEA.Sprint6.TaskReview.V30
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        Random rn = new Random();
        DataService ds = new DataService();
        public void buttonGenerate_MEA_Click(object sender, EventArgs e)
        {


            int stroke = Convert.ToInt32(textBoxStrokeGet_MEA.Text);
            int columns = Convert.ToInt32(textBoxColumnsGet_MEA.Text);

            int StartStep = Convert.ToInt32(textBoxStartGet_MEA.Text);
            int StopStep = Convert.ToInt32(textBoxEndGet_MEA.Text);


            dataGridViewRes_MEA.RowCount = stroke;
            dataGridViewRes_MEA.ColumnCount = columns;

            int[,] mtrx = new int[dataGridViewRes_MEA.RowCount, dataGridViewRes_MEA.ColumnCount];
            int[] array = new int[] { };
            for (int i = 0; i < dataGridViewRes_MEA.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewRes_MEA.ColumnCount; j++)
                {
                    int r = rn.Next(StartStep, StopStep);
                    mtrx[j, i] = r;
                }
            }

            for (int r = 0; r < mtrx.GetLength(0); r++)
            {
                for (int i = 0; i < mtrx.GetLength(1); i++)
                {
                    for (int j = i + 1; j < mtrx.GetLength(1); j++)
                    {
                        if (mtrx[r, i] < mtrx[r, j])
                        {
                            int tmp = mtrx[r, i];
                            mtrx[r, i] = mtrx[r, j];
                            mtrx[r, j] = tmp;
                        }
                    }
                }
            }

            int w = mtrx.GetLength(0);
            int h = mtrx.GetLength(1);

            int[,] mtrxT = new int[h, w];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    mtrxT[j, i] = mtrx[i, j];
                }
            }


            try
            {
                

                for (int i = 0; i < stroke; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewRes_MEA.Rows[j].Cells[i].Value = Convert.ToString(mtrxT[j, i]);
                    }
                }

                int StrokeNum = Convert.ToInt32(textBoxChooseStrokeInput_MEA.Text);
                int FirstCol = Convert.ToInt32(textBox3.Text);
                int LastCol = Convert.ToInt32(textBox1.Text);

                textBoxResOutput_MEA.Text = Convert.ToString(ds.GetMatrix(mtrxT, StrokeNum, FirstCol, LastCol));

            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonDone_MEA_Click(object sender, EventArgs e)
        {
            try
            {
                int stroke = Convert.ToInt32(textBoxStrokeGet_MEA.Text);
                int columns = Convert.ToInt32(textBoxColumnsGet_MEA.Text);

                int StartStep = Convert.ToInt32(textBoxStartGet_MEA.Text);
                int StopStep = Convert.ToInt32(textBoxEndGet_MEA.Text);


                dataGridViewRes_MEA.RowCount = stroke;
                dataGridViewRes_MEA.ColumnCount = columns;

                int[,] mtrx = new int[dataGridViewRes_MEA.RowCount, dataGridViewRes_MEA.ColumnCount];
                int[] array = new int[] { };
                for (int i = 0; i < dataGridViewRes_MEA.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewRes_MEA.ColumnCount; j++)
                    {
                        int r = rn.Next(StartStep, StopStep);
                        mtrx[j, i] = r;
                    }
                }

                for (int r = 0; r < mtrx.GetLength(0); r++)
                {
                    for (int i = 0; i < mtrx.GetLength(1); i++)
                    {
                        for (int j = i + 1; j < mtrx.GetLength(1); j++)
                        {
                            if (mtrx[r, i] < mtrx[r, j])
                            {
                                int tmp = mtrx[r, i];
                                mtrx[r, i] = mtrx[r, j];
                                mtrx[r, j] = tmp;
                            }
                        }
                    }
                }

                int w = mtrx.GetLength(0);
                int h = mtrx.GetLength(1);

                int[,] mtrxT = new int[h, w];
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        mtrxT[j, i] = mtrx[i, j];
                    }
                }

                for (int i = 0; i < stroke; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewRes_MEA.Rows[j].Cells[i].Value = Convert.ToString(mtrxT[j, i]);
                    }
                }

                int StrokeNum = Convert.ToInt32(textBoxChooseStrokeInput_MEA.Text);
                int FirstCol = Convert.ToInt32(textBox3.Text);
                int LastCol = Convert.ToInt32(textBox1.Text);

                textBoxResOutput_MEA.Text = Convert.ToString(ds.GetMatrix(mtrx, StrokeNum, FirstCol, LastCol));

            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pomodoro_Keep_Focus
{
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }
        
        public void setArrayOfSeries(ArrayList listOfSeries, ArrayList listOfPoints)
        {
            int sizeSeries = listOfSeries.Count;
            int sizePoints = listOfPoints.Count;
            if(sizeSeries == sizePoints && sizeSeries > 0 && sizePoints > 0)
            {
                chart1.Palette = ChartColorPalette.BrightPastel;
                chart1.Series.Clear();
                chart1.Titles.Add("Veriler");
                for(int i = 0; i < sizeSeries; i++)
                {
                    if(!chart1.Series.Contains(new Series(listOfPoints[i].ToString())))
                    {
                        Series mySeries = chart1.Series.Add(listOfPoints[i].ToString());
                        mySeries.Points.Add(Convert.ToDouble(listOfPoints[i]));
                    } else
                    {
                    }
                }
            }
        }
        
        private void BarExample()
        {
            chart1.Series.Clear();

            string[] series = { "cat", "dog", "nima", "test" };
            int[] points = { 1, 2, 3, 4 };

            chart1.Palette = ChartColorPalette.EarthTones;
            chart1.Titles.Add("Animals");

            for (int i = 0; i < series.Length; i++)
            {
                Series series1 = chart1.Series.Add(series[i]);
                series1.Points.Add(points[i]);
            }
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            //BarExample();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro_Keep_Focus
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }
        private DatabaseConnection connection;
        
        // Returns total rows
        private int readFromTable(Dictionary<int, ArrayList> outRows = null, 
            bool dateFiltering = false, string date = null,
            bool fillDataGrid = true, string customSQL = null)
        {
            SQLiteCommand command = connection.GetCommand;
            int countOfRows = 0;
            command.CommandText = "SELECT * FROM Statistics";
            if(dateFiltering && date != null)
            {
                command.CommandText += string.Format(" WHERE Tarih = '{0}'", date); 
            }
            if(customSQL != null && customSQL.Length > 0)
            {
                command.CommandText = customSQL;
            }
            try
            {
                using (SQLiteDataReader dataReader = command.ExecuteReader())
                {
                
                    if(dataReader.HasRows)
                    {
                        while(dataReader.Read())
                        {
                            string row1 = dataReader.GetString(1); //Tarih
                            int row2 = dataReader.GetInt32(2); //Pomodoro sayısı
                            int row3 = dataReader.GetInt32(3); //Pomodoro dakika
                            int row4 = dataReader.GetInt32(4); //Verilen mola
                            int row5 = dataReader.GetInt32(5); //Verilen mola dakika
                            int row6 = dataReader.GetInt32(6); //Dinlenme 
                            int row7 = dataReader.GetInt32(7); //Dinlenme dakika
                            if(outRows != null)
                            {
                                outRows.Add(countOfRows, new ArrayList() { row1, row2, row3, row4, row5, row6, row7 }); 
                            }
                            countOfRows++;

                            if (fillDataGrid)
                                dataGridView1.Rows.Add(row1, row2, row3, row4, row5, row6, row7); 
                        }
                    } 
                }
            } catch (SQLiteException ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return countOfRows;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            connection = new DatabaseConnection("stats.db");
            int totalCounts = readFromTable(null);
            label2.Text = string.Format("Toplam: {0}", totalCounts);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string dateTimeValue = dateTimePicker1.Value.ToShortDateString();
            dataGridView1.Rows.Clear();
            readFromTable(dateFiltering: true, date: dateTimeValue);
        }

        private void showGraphs_Click(object sender, EventArgs e)
        {
        /*    ArrayList pomodoroArrayList = new ArrayList();
            ArrayList dateList = new ArrayList();
            SQLiteCommand command = connection.GetCommand;
            command.CommandText = "SELECT YapilanPomodoro,Tarih FROM Statistics";
            try
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            pomodoroArrayList.Add(reader.GetInt32(0));
                            dateList.Add(reader.GetString(1));
                        }
                    }
                }

            } catch(SQLiteException ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;     
            }
            Graphs graphsForm = new Graphs();
            graphsForm.setArrayOfSeries(pomodoroArrayList, dateList);
             

            graphsForm.Show();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show("Bütün istatistikleri silmek istediğinize emin misiniz ?", "İstatistikler siliniyor",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                SQLiteCommand command = connection.GetCommand;
                command.CommandText = "DELETE FROM Statistics";
                command.ExecuteNonQuery();
                dataGridView1.Rows.Clear();
                label2.Text = "Toplam: 0";
            }
        }
    }
}

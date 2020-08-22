using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro_Keep_Focus
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Properties.Settings.Default.pWorkTime;
            numericUpDown2.Value = Properties.Settings.Default.pMolaTime;
            numericUpDown3.Value = Properties.Settings.Default.pRestTime;

            //this.DialogResult = DialogResult.No;
        }

             private void Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(numericUpDown1.Value != Properties.Settings.Default.pWorkTime ||
               numericUpDown2.Value != Properties.Settings.Default.pMolaTime ||
               numericUpDown3.Value != Properties.Settings.Default.pRestTime)
            {
                DialogResult dr = 
                    MessageBox.Show("Çıkmak istediğinize eminmisiniz: Ayarlar kaydedilmedi ?", "Ayarlar",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    e.Cancel = true;
            } 
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ayarları kaydet
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.pWorkTime = (int)numericUpDown1.Value;
            Properties.Settings.Default.pMolaTime = (int)numericUpDown2.Value;
            Properties.Settings.Default.pRestTime = (int)numericUpDown3.Value;
            MessageBox.Show("Ayarlarınız kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 25;
            numericUpDown2.Value = 5;
            numericUpDown3.Value = 25;
        }
    }
}

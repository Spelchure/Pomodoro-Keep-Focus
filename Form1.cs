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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Pomodoro tekniğine göre çalışma mola ve dinlenme aşamaları
         */
        public enum PomodoroModes
        {
            Work, // Çalışma 
            Mola, // Mola 
            Rest // Dinlenme ( 4 Pomodoro sonrası )
        }

        // Şuanki Aşama ( Çalışma , Mola, Dinlenme)
        public PomodoroModes currentMode = PomodoroModes.Work;
        public int remainMinutes = 25; // Kalan dakika
        public int remainSeconds = 0;  // Kalan saniye

        private bool isCounting = false; // Sayaç çalışıyor mu ?


        /*
         * Verilen sayıyı resim kutusuna atama işlemi
         */
        private void numberToPicture(int number, PictureBox pictureBox)
        {
            switch(number)
            {
                // Burada C++ ## operatörü özleniyor :)
                case 0:
                    pictureBox.Image = Properties.Resources._0;
                    break;
                case 1:
                    pictureBox.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox.Image = Properties.Resources._6;
                    break;
                case 7:
                    pictureBox.Image = Properties.Resources._7;
                    break;
                case 8:
                    pictureBox.Image = Properties.Resources._8;
                    break;
                case 9:
                    pictureBox.Image = Properties.Resources._9;
                    break;
            }
        }
        
        
        /*
         * Verilen dakika ve saniyeye göre
         * zamanı resim olarak gösterme
         */
        private void setTimePicture(int minutes, int seconds)
        {

            int onlarBasamak = minutes / 10; // Onlar basamağı
            int birlerBasamak = minutes % 10; // Birler basamağı
            
            // Dakika
            numberToPicture(onlarBasamak, timePicture0);
            numberToPicture(birlerBasamak, timePicture1);

            onlarBasamak = seconds / 10;
            birlerBasamak = seconds % 10;
           
            // Saniye
            numberToPicture(onlarBasamak, timePicture3);
            numberToPicture(birlerBasamak, timePicture4);
        }

       
        // Form açıldığında olucak işlemler
        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1, "Sayacı başlat"); 
            
            switch(Properties.Settings.Default.lastMode)
            {
                case (int)PomodoroModes.Work:
                    // Program çalışma modunda kapatıldı.
                    setTimePicture(Properties.Settings.Default.pWorkTime, 0);
                    remainMinutes = Properties.Settings.Default.pWorkTime;
                    break;
                case (int)PomodoroModes.Mola:
                    // ...
                    setTimePicture(Properties.Settings.Default.pMolaTime, 0);
                    remainMinutes = Properties.Settings.Default.pMolaTime;
                    break;
                case (int)PomodoroModes.Rest:
                    // ...
                    setTimePicture(Properties.Settings.Default.pRestTime, 0);
                    remainMinutes = Properties.Settings.Default.pRestTime;
                    break;
            }
        }
        
        // Form kapatıldığında oluşacak işlemler
        // Örneğin: Ayarların kaydedilmesi
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Hangi aşamadayız ?
            Properties.Settings.Default.lastMode = (int)currentMode;   
        }

        /**
         * Sayacı başlatıyor
         */
        private void startCounting()
        {
            timeCounter.Enabled = true;
            isCounting = true;
            button1.BackgroundImage = Properties.Resources.pausebutton;
            toolTip1.SetToolTip(this.button1, "Sayacı durdur"); 
        }
        
        /**
         * Sayacı duraklat / bitir
         */
        private void pauseCounting()
        {
            timeCounter.Enabled = false;
            isCounting = false;
            button1.BackgroundImage = Properties.Resources.playbutton;
            toolTip1.SetToolTip(this.button1, "Sayacı başlat"); 
        }


        /**
         * Her 1 saniyede ...
         */
        private void timeCounter_Tick(object sender, EventArgs e)
        {
            /**
             * Saniyeyi azaltmamız ve saniye 0 olduğu zaman
             * dakikayı azaltmamız gerekiyor ayrıca şuan ki 
             * zaman için Resimleri ayarlamamız gerekiyor
             */
            if (remainMinutes == 0 && remainSeconds == 0)
            {
                // Süre doldu !!
                // TODO: switchMode
                return;
            }
            if (remainSeconds == 0) // 0 Saniye
            {
                // Dakikayı azalt saniye ise = 59
                remainSeconds = 59;
                remainMinutes--;
            } else
            {
                remainSeconds--;
            }
            //Resimleri değiştiriyoruz:
            setTimePicture(remainMinutes, remainSeconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isCounting)
                pauseCounting();
            else
                startCounting();
        }
        
        // Instagram sayfamız
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/bilgisayar.bilimleri");
        }
    
        // Web sitemiz
        private void button3_Click(object sender, EventArgs e)
        {
            // Websiteyi açma işlemi
            System.Diagnostics.Process.Start("https://www.bilgisayarbilimi.org");
        }

        // Facebook sayfamız
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Bilgisayar-Bilimi-588994085125986");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

        private int pomodoroCount = 0;
        private int molasCount = 0;
        private int restsCount = 0;

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
            toolTip1.SetToolTip(this.button5, "Bu aşamayı atla");
            labelDate.Text = DateTime.Now.ToLongDateString();
            switch(Properties.Settings.Default.lastMode)
            {
                case (int)PomodoroModes.Work:
                    // Program çalışma modunda kapatıldı.
                    setTimePicture(Properties.Settings.Default.pWorkTime, 0);
                    remainMinutes = Properties.Settings.Default.pWorkTime;
                    label5.Text = "Çalışma zamanı !";
                    break;
                case (int)PomodoroModes.Mola:
                    // ...
                    setTimePicture(Properties.Settings.Default.pMolaTime, 0);
                    remainMinutes = Properties.Settings.Default.pMolaTime;
                    label5.Text = "Mola zamanı !";
                    break;
                case (int)PomodoroModes.Rest:
                    // ...
                    setTimePicture(Properties.Settings.Default.pRestTime, 0);
                    remainMinutes = Properties.Settings.Default.pRestTime;
                    label5.Text = "Dinlenme zamanı !";   
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

        private void updateLabels()
        {

            long pomodoroMin = pomodoroCount * Properties.Settings.Default.pWorkTime;
            long molaMin = molasCount * Properties.Settings.Default.pMolaTime;
            long restMin = restsCount * Properties.Settings.Default.pRestTime;
            
            labelPomodoro.Text =
                String.Format("{0} = {1} dakika", pomodoroCount, pomodoroMin);

            labelMola.Text =
                String.Format("{0} = {1} dakika", molasCount, molaMin);

            labelRest.Text =
                String.Format("{0} = {1} dakika", restsCount, restMin);

            long totalMins = pomodoroMin + molaMin + restMin;
            long hours = 0;
            
            if (totalMins >= 60)
            {
                hours = totalMins / 60;
                totalMins %= 60;
            }

            label4.Text =
                String.Format("Toplam: {0} saat {1} dakika.", hours, totalMins);

        }
    
        /**
         * Bir diğer aşamaya geçme
         */
        private void switchMode(bool updateTimer = true)
        {
            remainSeconds = 0;
            if(timeCounter.Enabled && updateTimer) timeCounter.Enabled = false;
            if(currentMode == PomodoroModes.Work && 0 == (++pomodoroCount % 4)) // Dinlenme
            {
                currentMode = PomodoroModes.Rest;
                remainMinutes = Properties.Settings.Default.pRestTime;
                MessageBox.Show("Güzel bir dinlenmeyi hakettiniz. Bir kahve ? :)",
                    "Dinlenme zamanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label5.Text = "Dinlenme zamanı !";
                if( !timeCounter.Enabled && updateTimer) timeCounter.Enabled = true;
                updateLabels();
                return;
            } 
            switch(currentMode)
            {
                case PomodoroModes.Work:
                    currentMode = PomodoroModes.Mola;
                    //pomodoroCount++; Yukarıda zaten arttırıldı.
                    remainMinutes = Properties.Settings.Default.pMolaTime;
                    MessageBox.Show("Çalışmayı bırakınız.. Mola zamanı.", "Mola", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    label5.Text = "Mola zamanı !";
                    break;
                case PomodoroModes.Mola:
                    currentMode = PomodoroModes.Work;
                    molasCount++;
                    remainMinutes = Properties.Settings.Default.pWorkTime;
                    MessageBox.Show("Çalışma zamanı, molanız sona erdi", "Çalışma", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    label5.Text = "Çalışma zamanı !";
                    break;
                case PomodoroModes.Rest:
                    currentMode = PomodoroModes.Work;
                    restsCount++;
                    remainMinutes = Properties.Settings.Default.pWorkTime;
                    MessageBox.Show("Güzelce dinlendiğinize göre artık çalışmaya başlamalısınız !", "Çalışma", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    label5.Text = "Çalışma zamanı !";
                    break;
            }
            updateLabels();
            if(!timeCounter.Enabled && updateTimer) timeCounter.Enabled = true;
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
                /*switch(currentMode)
                {
                    case PomodoroModes.Work:
                        pomodoroCount++;
                        break;
                    case PomodoroModes.Mola:
                        molasCount++;
                        break;
                    case PomodoroModes.Rest:
                        restsCount++;
                        break;
                }*/
                
                switchMode(); 
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
            //TODO play tick sound. if enabled in settings
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

        private void setTime()
        {
            remainSeconds = 0;
            switch(currentMode)
            {
                case PomodoroModes.Work:
                    remainMinutes = Properties.Settings.Default.pWorkTime;
                    break;
                case PomodoroModes.Mola:
                    remainMinutes = Properties.Settings.Default.pMolaTime;
                    break;
                case PomodoroModes.Rest:
                    remainMinutes = Properties.Settings.Default.pRestTime;
                    break;
            }
        }

        // Zamanlama ayarları
        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlarForm = new Ayarlar();
            DialogResult dr = ayarlarForm.ShowDialog();
            if (dr == DialogResult.Yes) // Yeni ayarlar
            {
                setTime();
                setTimePicture(remainMinutes, remainSeconds);
            }
        }

        private void deleteStatistics_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bütün istatiskleri temizlemek istediğinize emin misiniz?", "İstatikler temizleniyor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                pomodoroCount = 0;
                molasCount = 0;
                restsCount = 0;
                updateLabels();
            }
        }

        // Aşamayı atla
        private void button5_Click(object sender, EventArgs e)
        {
            //if(timeCounter.Enabled)
            //{
                remainMinutes = 0;
                remainSeconds = 0;
            if (isCounting)
                switchMode();
            else
                switchMode(false);
                setTimePicture(remainMinutes, remainSeconds);
                  //} 
        }

        // Sıfırla
        private void button6_Click(object sender, EventArgs e)
        {
            setTime();
            setTimePicture(remainMinutes, remainSeconds);
        }

        /** 
         * Veritabanı bağlantısı
         * NOT: Veritabanı bağlantısı için System.Data.SQLite yüklenmesi
         * gerekir. Yüklemek için Visual Studio -> Tools -> NuGet Package Manager -> Package Manager Console açarak
         * Install-package System.Data.SQLite -Version 1.0.113.1
         * 
         * https://www.nuget.org/packages/System.Data.SQLite
         */
        private void saveStatistics_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Bugünün istatistiklerini veritabanına kaydetmek istediğinize emin misiniz?",
                "Kaydet", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult != DialogResult.Yes)
                return;

            /*
             * Veritabanına bağlantı ve table oluşturulmamış ise (ilk sefer)
             * oluşturuyoruz*/
            try
            {
                DatabaseConnection connection = new DatabaseConnection("stats.db");
                SQLiteCommand command = connection.GetCommand;
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Statistics(id INTEGER PRIMARY KEY,
Tarih TEXT, YapilanPomodoro INT,PMDakika INT, VerilenMola INT,
VMDakika INT, Dinlenme INT, DDakika INT)";
                command.ExecuteNonQuery();

                long pmMinutes = pomodoroCount * Properties.Settings.Default.pWorkTime;
                long mMinutes = molasCount * Properties.Settings.Default.pMolaTime;
                long rMinutes = restsCount * Properties.Settings.Default.pRestTime;

                string cmdString =
                    String.Format("INSERT INTO Statistics(Tarih,YapilanPomodoro,PMDakika,VerilenMola,VMDakika,"+
"Dinlenme,DDakika) VALUES('{0}', {1}, {2}, {3}, {4}, {5}, {6})",
                        DateTime.Now.ToShortDateString(), pomodoroCount, pmMinutes, molasCount, mMinutes,
                        restsCount, rMinutes);

                command.CommandText = cmdString;
                command.ExecuteNonQuery();

                MessageBox.Show("İstatistikler kaydedildi!", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (SQLiteException sqliteException)
            {
                MessageBox.Show(sqliteException.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

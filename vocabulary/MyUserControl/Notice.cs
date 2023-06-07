using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vocabulary.MyUserControl
{
    public partial class Notice : UserControl
    {
        public int score;
        public string name;
        public int gameDifficulty;
        public Notice()
        {
            InitializeComponent();
        }

        public Notice(int score, int gameDifficulty)
        {
            InitializeComponent();
            //this.score = score;
            //this.gameDifficulty = gameDifficulty;
        }

        public void checkRank()
        {
            string filePath;
            if (gameDifficulty == 0)
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankEasy.txt";
            else if (gameDifficulty == 1)
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankMedium.txt";
            else
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankHard.txt";
            TimeSpan vietnamOffset = TimeSpan.FromMinutes(44); // UTC+7:00 for Vietnam

            // Get the current UTC time
            DateTime utcDateTime = DateTime.Now - vietnamOffset;

            // Calculate the local time in Vietnam
            DateTime vietnamDateTime = utcDateTime;
            string currentTime = vietnamDateTime.ToString("HH:ss dd/MM/yyyy");

            // write to file
            //using (StreamWriter sw = new StreamWriter(filePath))
            //{
            //    sw.WriteLine($"{1},{"Tuan"},{score},{currentTime}");
            //}

            string tempFilePath = Path.GetTempFileName();
            int count = 0;
            int rank = 0;
            bool flag = true;
            // Open the file and create a StreamReader object
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Create a StreamWriter object to write to a temporary file
                using (StreamWriter sw = new StreamWriter(tempFilePath))
                {
                    // Loop through each line in the original file
                    // string _line = textBox1.Text;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        count++;
                        if (score >= int.Parse(line.Split(',')[1]) && flag && count <= 5)
                        {
                            // Replace the first line with the new line
                            sw.WriteLine($"{name},{score},{currentTime}");
                            rank = count;
                            count++;
                            flag = false;
                        }
                        sw.WriteLine(line);
                    }
                }
            }
            // Replace the original file with the temporary file
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);

            if (count < 5 && flag)
            {
                count++;
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    // Write the content to the end of the file
                    writer.WriteLine($"{name},{score},{currentTime}");
                    flag = false;
                    rank = count;
                }
            }

            if (!flag)
                label6.Text = rank.ToString();
            else
            {
                label6.Text = "Unrank";
            }
        }


        public void Notice_Load()
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\claps-44774.mp3";
            player.settings.volume = 80;
            player.controls.play();
            label5.Text = score.ToString();
            label1.Text = "Congratulations " + name + "!"; 
            checkRank();
            if (gameDifficulty == 0)
            {
                label7.Text = "Easy";
            }
            else if (gameDifficulty == 1)
            {
                label7.Text = "Medium";
            }
            else
                label7.Text = "Hard";

        }
    }
}

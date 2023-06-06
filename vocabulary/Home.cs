using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace vocabulary
{
    public partial class Home : Form
    {
        
        private bool music = false;
        public Home()
        {
            InitializeComponent();
            initMusicPlayer();
        }

        public void initMusicPlayer()
        {
            player = new WindowsMediaPlayer();
            player.URL = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\nhacgame01.mp3";
            player.controls.play();
            player.settings.volume = 50;
            player.settings.setMode("loop", true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            music = !music;
            if (music)
            {
                player.controls.pause();
                pictureBox2.Image = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\no-sound.png");
            }
            else
            {
                player.URL = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\nhacnen3.mp3";
                player.controls.play();
                pictureBox2.Image = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\sound.png");
            }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // hide home cs and show game cs
            Game game = new Game("animal", this);
            game.FormClosed += Game_FormClosed;
            game.Show();
            this.Hide();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Close the application when Form2 is closed
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // hide home cs and show game cs
            Game game = new Game("vehicle", this);
            game.FormClosed += Game_FormClosed;
            game.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // hide home cs and show game cs
            Game game = new Game("fruit", this);
            game.FormClosed += Game_FormClosed;
            game.Show();
            this.Hide();
        }
    }
}

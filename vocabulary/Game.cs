using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vocabulary.MyUserControl;

namespace vocabulary
{
    public partial class Game : Form
    {
        private Home home1;
        public string typeQuiz;
        public int levelDifficulty;
        public Game()
        {
            InitializeComponent();
        }

        public void Level1_CloseLevelControl(object sender, EventArgs e)
        { 
            this.levelDifficulty = level1.LevelDifficulty;
            showQuiz(typeQuiz, levelDifficulty);
        }

        public Game(string typeQuiz, object home)
        {
            InitializeComponent();
            home1 = home as Home;
            this.typeQuiz = typeQuiz;
            if (typeQuiz == "animal")
                this.BackgroundImage = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\animal_theme.jpg");
            else if (typeQuiz == "vehicle")
                this.BackgroundImage = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\vehicle_theme.jpg");
            else
                this.BackgroundImage = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\3681625.jpg");
            level1.CloseLevelControl += new EventHandler(Level1_CloseLevelControl);
        }

        public void showQuiz(string typeQuiz, int LevelDifficulty)
        {
            Quiz quiz = new Quiz(typeQuiz, level1.LevelDifficulty);
            panel1.Controls.Add(quiz);
            panel1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home1.Show();
        }
    }
}

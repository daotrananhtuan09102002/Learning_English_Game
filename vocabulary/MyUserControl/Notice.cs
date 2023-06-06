using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vocabulary.MyUserControl
{
    public partial class Notice : UserControl
    {
        public int score;
        public int gameDifficulty;
        public Notice()
        {
            InitializeComponent();
        }

        public Notice(int score, int gameDifficulty)
        {
            InitializeComponent();
            this.score = score;
            this.gameDifficulty = gameDifficulty;
        }

        private void Notice_Load(object sender, EventArgs e)
        {
            label5.Text = score.ToString();
            if (gameDifficulty == 0)
            {
                label6.Text = "Easy";
            }
            else if (gameDifficulty == 1)
            {
                label6.Text = "Medium";
            }
            else
                label6.Text = "Hard";
        }
    }
}

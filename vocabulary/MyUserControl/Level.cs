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
    public partial class Level : UserControl
    {
        public event EventHandler CloseLevelControl;
        public Level()
        {
            InitializeComponent();
        }

        public int LevelDifficulty;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LevelDifficulty = 0;
            CloseLevelControl?.Invoke(this, e);
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LevelDifficulty = 1;
            CloseLevelControl?.Invoke(this, e);
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LevelDifficulty = 2;
            CloseLevelControl?.Invoke(this, e);
            this.Hide();
        }
    }
}

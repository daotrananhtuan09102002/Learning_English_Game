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

namespace vocabulary
{
    public partial class Ranking : Form
    {
        private Home home1;
        public Ranking()
        {
            InitializeComponent();
        }

        public Ranking(object home)
        {
            InitializeComponent();
            home1 = home as Home;
            Ranking_Load(0);
        }


        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current row is valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Get the current row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the background color for the row
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#274b47");
            }
        }


        public void Ranking_Load(int gameDifficulty)
        {
            string filePath;
            if (gameDifficulty == 0)
            {
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankEasy.txt";
            }
            else if (gameDifficulty == 1)
            {
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankMedium.txt";
            }
            else
                filePath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\UserData\RankHard.txt";


            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            dt.Columns.Add("Top" , typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Score", typeof(string));
            dt.Columns.Add("Time", typeof(string));

            // define num of line if length of line check line less than 10
            int numLine = lines.Length >= 5 ? 5 : lines.Length;

            for (int i = 0; i < numLine; i++)
            {
                string[] data = lines[i].Split(',');
                // Create a new string array with index as the first element
                string[] rowValues = new string[data.Length + 1];
                rowValues[0] = (i + 1).ToString();

                // Copy the elements from 'data' to 'rowValues'
                Array.Copy(data, 0, rowValues, 1, data.Length);
                dt.Rows.Add(rowValues);
            }

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#274b47");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 100; 
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 400;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Ranking_Load(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ranking_Load(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Ranking_Load(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            home1.Show();
        }
    }
}

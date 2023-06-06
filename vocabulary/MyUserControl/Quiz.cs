using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace vocabulary.MyUserControl
{
    public partial class Quiz : UserControl
    {
        private List<string> randomFilePaths;
        private int index = -1;
        private int GameDifficulty;
        private int duration;
        public int score = 0;
        public Quiz()
        {
            InitializeComponent();
        }

        public Quiz(string typeQuiz, int GameDifficulty)
        {
            InitializeComponent();
            this.GameDifficulty = GameDifficulty;
            setImage_and_setText(typeQuiz);
            button1_Click(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void setImage_and_setText(string typeQuiz)
        {
            string folderPath;
            if (typeQuiz == "animal")
                folderPath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\animal_nobg";
            else if (typeQuiz == "fruit")
                folderPath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\fruit_nobg";
            else
                folderPath = @"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\vehicle_nobg";

            // Get all files in the folder
            string[] files = Directory.GetFiles(folderPath);

            // Select five random indices
            // Random number generator
            Random rand = new Random();
            List<int> randomIndices = Enumerable.Range(0, files.Length).OrderBy(x => rand.Next()).Take(5).ToList();

            // Select the corresponding file paths
            randomFilePaths = randomIndices.Select(index => files[index]).ToList();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            textBox.SelectAll();
        }

        private System.Windows.Forms.TextBox CreateTextBox(string text, string id)
        {
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Margin = new System.Windows.Forms.Padding(0);
            textBox.MaxLength = 1;
            textBox.Name = "textBoxx" + id;
            textBox.Size = new System.Drawing.Size(52, 71);
            textBox.TabIndex = 1;
            textBox.Text = text;
            textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox.Enter += new System.EventHandler(this.TextBox_Enter);
            return textBox;
        }

        private Label CreateLabel(string id)
        {
            Label label = new Label();
            label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label.Name = "labelx" + id;
            label.Size = new System.Drawing.Size(52, 1);
            return label;
        }

        private void showNewEasyQuiz()
        {
            pictureBox1.Image = Image.FromFile(randomFilePaths[index]);
            string imageName = Path.GetFileNameWithoutExtension(randomFilePaths[index]).Split('/').Last();
            int charCount = imageName.Length / 3;
            int indexFlag = 0;

            // Random number generator
            Random rand = new Random();
            List<int> randomIndices = Enumerable.Range(0, imageName.Length).OrderBy(x => rand.Next()).Take(charCount).ToList();
            randomIndices.Sort();


            int textBoxWidth = 52; // Width of each TextBox
            int textBoxSpacing = 10; // Spacing between TextBoxes
            int initialX = 10; // Initial X position of the TextBoxes
            int initialY = 10; // Initial Y position of the TextBoxes
            listView1.Controls.Clear();
            int listViewWidth = initialX + (textBoxWidth + textBoxSpacing) * imageName.Length;
            listView1.Width = listViewWidth;
            for (int i = 0; i < imageName.Length; i++)
            {
                // text only contain 1 character
                System.Windows.Forms.TextBox textBox;
                if (indexFlag < randomIndices.Count && randomIndices[indexFlag] == i)
                { 
                    textBox = CreateTextBox(imageName[i].ToString(), i.ToString());
                    indexFlag++;
                }
                else
                    textBox = CreateTextBox("", i.ToString());


                // label is -
                Label label = CreateLabel(i.ToString());
                // ListViewItem item = new ListViewItem();
                // item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox.Text));
                int col = i % imageName.Length; // Calculate the column number

                textBox.Location = new Point(initialX + (textBoxWidth + textBoxSpacing) * col, initialY);
                label.Location = new Point(initialX + (textBoxWidth + textBoxSpacing) * col, initialY - 10 + (textBox.Height + textBoxSpacing));
                //listView1.Items.Add(item);
                listView1.Controls.Add(textBox);
                listView1.Controls.Add(label);
            }
            int formX = (this.Width - listView1.Width) / 4;
            int formY = listView1.Location.Y;

            // Set the form's position within the panel
            listView1.Location = new Point(formX, formY);
        }

        private void showNewMediumQuiz()
        {
            pictureBox1.Image = Image.FromFile(randomFilePaths[index]);
            string imageName = Path.GetFileNameWithoutExtension(randomFilePaths[index]).Split('/').Last();

            int textBoxWidth = 52; // Width of each TextBox
            int textBoxSpacing = 10; // Spacing between TextBoxes
            int initialX = 10; // Initial X position of the TextBoxes
            int initialY = 10; // Initial Y position of the TextBoxes
            listView1.Controls.Clear();
            int listViewWidth = initialX + (textBoxWidth + textBoxSpacing) * imageName.Length;
            listView1.Width = listViewWidth;
            for (int i = 0; i < imageName.Length; i++)
            {
                // text only contain 1 character
                System.Windows.Forms.TextBox textBox = CreateTextBox("", i.ToString());

                // label is -
                Label label = CreateLabel(i.ToString());
                // ListViewItem item = new ListViewItem();
                // item.SubItems.Add(new ListViewItem.ListViewSubItem(item, textBox.Text));
                int col = i % imageName.Length; // Calculate the column number

                textBox.Location = new Point(initialX + (textBoxWidth + textBoxSpacing) * col, initialY);
                label.Location = new Point(initialX + (textBoxWidth + textBoxSpacing) * col, initialY - 10 + (textBox.Height + textBoxSpacing));
                //listView1.Items.Add(item);
                listView1.Controls.Add(textBox);
                listView1.Controls.Add(label);
            }
            int formX = (this.Width - listView1.Width) / 4;
            int formY = listView1.Location.Y;

            // Set the form's position within the panel
            listView1.Location = new Point(formX, formY);
        }

        private bool check()
        {
            string imageName = Path.GetFileNameWithoutExtension(randomFilePaths[index - 1]).Split('/').Last();
            string answer = "";
            for (int i = 0; i < imageName.Length; i++)
            {
                Control controls = listView1.Controls.Find("textBoxx" + i.ToString(), true)[0];
                answer += controls.Text;
            }
            if (answer == imageName)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index++;
            if (index > 0 && index <= 5)
            {
                if (index < 5)
                    label3.Text = (index + 1).ToString() + "/5";
                PictureBox control = this.Controls.Find("pictureBox" + (index+1).ToString(), true)[0] as PictureBox;
                if (check())
                {
                    
                    control.Image = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\check-mark.png");
                    score += 20;
                }
                else
                {
                    control.Image = Image.FromFile(@"C:\Users\tuan\source\repos\vocabulary\vocabulary\Resources\wrong.png");
                }
                label4.Text = score.ToString();
            }
            if (index >= 5)
            {          
                timer1.Stop();
                this.Hide();
                return;
            }
            if (this.GameDifficulty == 0)
                showNewEasyQuiz();
            else if (this.GameDifficulty == 1)
                showNewMediumQuiz();
            else
            {
                label1.Visible = true;
                label7.Visible = true;
                this.duration = 5;
                timer1.Start();
                label1.Text = "5";
                showNewMediumQuiz();
            }
            
                

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            duration--;
            label1.Text = duration.ToString();
            if (duration <= 0)
            {
                timer1.Stop();
                button1_Click(sender, e);
            }

        }
    }
}

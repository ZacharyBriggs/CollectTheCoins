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
using Newtonsoft.Json;

namespace CollectTheCoins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C: \Users\s178020\Documents\Visual Studio 2015\Projects\CollectTheCoins\CollectTheCoins\Properties\coin.png");
            score = 0;
            textBox1.Text = "Score: " + score;
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "score.txt");
            if (System.IO.File.Exists(path))
            {
                var data = File.ReadAllText(path);
                highScore = JsonConvert.DeserializeObject<int>(data);
            }
            else
            {
                highScore = 0;
            }
            textBox2.Text = "High Score: " + highScore;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score += 1;
            if (score > highScore)
                highScore = score;
            textBox1.Text = "Score: " + score;
            textBox2.Text = "High Score: " + highScore;
            Random rand = new Random();
            int posX = rand.Next(0, 501);
            int posY = rand.Next(0, 501);
            Point pos = new Point(posX,posY);
            pictureBox1.Location = pos;
            string json = JsonConvert.SerializeObject(score);
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "score.txt");
            System.IO.File.WriteAllText(path, json);
        }


    }
}

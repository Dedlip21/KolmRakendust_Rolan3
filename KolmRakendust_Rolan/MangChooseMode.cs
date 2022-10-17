using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolmRakendust_Rolan
{
    public partial class MangChooseMode : Form
    {
        Label selectMode;
        Button selectEasy, selectHard;

        public MangChooseMode()
        {
            InitializeComponent();
            this.Size = new Size(300, 300);

            selectMode = new Label()
            {
                Text = "Select game mode",
                Font = new Font("Comic-Sans", 15, FontStyle.Bold),
                Location = new Point(50, Top),
                Size = new Size(200, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            selectEasy = new Button()
            {
                Text = "Easy mode (10 misses)",
                Font = new Font("Comic-Sans", 10, FontStyle.Bold),
                Location = new Point(50, 75),
                Size = new Size(80, 50),
                ImageAlign = ContentAlignment.MiddleRight

            };
            selectHard = new Button
            {
                Text = "Hard mode",
                Font = new Font("Comic-Sans", 10, FontStyle.Bold),
                Location = new Point(130, 75),
                Size = new Size(80, 50),
                ImageAlign = ContentAlignment.MiddleLeft
            };

            selectHard.Click += SelectHard_Click;
            selectEasy.Click += SelectEasy_Click;

            Controls.Add(selectMode);
            Controls.Add(selectEasy);
            Controls.Add(selectHard);
        }


        public static bool chooseMode;
        public static bool GameIsOn = true;
        public void SelectEasy_Click(object sender, EventArgs e)
        {
            chooseMode = true;

            this.Close();
            Mang mang = new Mang();
            mang.ShowDialog();

            
        }

        public void SelectHard_Click(object sender, EventArgs e)
        {
            chooseMode = false;

            this.Close();
            Mang mang = new Mang();
            mang.ShowDialog();

            
        }

        private void MangChooseMode_Load(object sender, EventArgs e)
        {

        }
    }
}

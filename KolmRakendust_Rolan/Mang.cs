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
    public partial class Mang : Form
    {
        //-----------Random icons-------------
        Random random = new Random();
        List<string> icons2 = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k", "f", "f", "#", "#",
                "b", "b", "v", "v", "w", "w", "z", "z", "q", "q", "M", "M",
                "o", "o", "A", "A", "x", "x", "P", "P", "h", "h", "¤", "¤",

            };

        List<string> icons1 = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k", "f", "f", "#", "#",
                "b", "b", "v", "v"

            };
        //------------------------------------
        TableLayoutPanel TLP1, TLP2;
        Label lbl;
        Label firstClicked = null;
        Label secondClicked = null;
        Label missesLabel;
        Timer timer, gameTimer;
        public int misses = 9;

        bool choose = MangChooseMode.chooseMode;

        public Mang()
        {
            //InitializeComponent();


            this.Size = new Size(550, 550);

            //---------------TableLayoutPanel----------------------------------------------------------
            if (choose == false)
            {
                TLP2 = new TableLayoutPanel
                {
                    AutoSize = true,
                    ColumnCount = 6,
                    RowCount = 6,
                    BackColor = Color.CornflowerBlue,
                    Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                    Name = "TableLayoutPanel1",
                    TabIndex = 0
                };

                /*gameTimer = new Timer
                {

                };*/

                timer = new Timer
                {
                    Interval = 750
                };
                timer.Tick += Timer_Tick;

                for (int i = 0; i < 6; i++)
                {
                    TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                    for (int j = 0; j < 6; j++)
                    {
                        TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

                        TLP2.Controls.Add(lbl = new Label() { BackColor = Color.CornflowerBlue, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "c", Font = new Font("Webdings", 48, FontStyle.Bold), UseCompatibleTextRendering = true });
                        lbl.Click += Lbl_Click;
                    }

                }

                Controls.Add(TLP2);
                AssignIconsToSquares();

            }
            else if (choose == true)
            {
                TLP1 = new TableLayoutPanel
                {
                    AutoSize = true,
                    ColumnCount = 4,
                    RowCount = 4,
                    BackColor = Color.CornflowerBlue,
                    //Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                    Name = "TableLayoutPanel2",
                    Size = new Size(550,450),
                    TabIndex = 0
                };
                missesLabel = new Label
                {
                    Text = "Misses: " + misses,
                    Font = new Font("Comic-Sans", 15, FontStyle.Bold),
                    Location = new Point(150, 450),
                    Size = new Size(200, 50),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                //missesLabel.TextChanged += MissesLabel_TextChanged;

                timer = new Timer
                {
                    Interval = 750
                };
                timer.Tick += Timer_Tick;

                for (int i = 0; i < 4; i++)
                {
                    TLP1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                    for (int j = 0; j < 4; j++)
                    {
                        TLP1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

                        TLP1.Controls.Add(lbl = new Label() { BackColor = Color.CornflowerBlue, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "c", Font = new Font("Webdings", 48, FontStyle.Bold), UseCompatibleTextRendering = true });
                        lbl.Click += Lbl_Click;
                    }

                }

                Controls.Add(TLP1);
                Controls.Add(missesLabel);
                AssignIconsToSquares();
            }


            //-----------------------------------------------------------------------------
        }

        /*private void MissesLabel_TextChanged(object sender, EventArgs e)
        {
            if (choose == true)
            {
                if (missesLabel.Text == "You lost")
                {
                    foreach (Control control in TLP1.Controls)
                    {
                        Label iconLabel = control as Label;

                        if (iconLabel != null)
                        {
                            if (iconLabel.ForeColor == iconLabel.BackColor)
                                return;
                        }
                    }
                    MessageBox.Show("You lost the game. Your tries run out!", "Try again");
                    Close();
                }

            }
        }*/

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        /*private void Mang_Shown()
        {
            if (missesLabel.Text == "You lost")
            {
                MessageBox.Show("You lost the game. Your tries run out!", "Try again");
                Close();
            }
            else
            {
                return;
            }
        }*/

        private void CheckForWinner()
        {
            if (choose == false)
            {
                foreach (Control control in TLP2.Controls)
                {
                    Label iconLabel = control as Label;

                    if (iconLabel != null)
                    {
                        if (iconLabel.ForeColor == iconLabel.BackColor)
                            return;
                    }
                }
                MessageBox.Show("You matched all the icons!", "Congratulations");
                Close();
            }
            else if (choose == true)
            {
                if (misses >= 0)
                {
                    foreach (Control control in TLP1.Controls)
                    {
                        Label iconLabel = control as Label;

                        if (iconLabel != null)
                        {
                            if (iconLabel.ForeColor == iconLabel.BackColor)
                                return;
                        }
                    }
                    MessageBox.Show("You matched all the icons!", "Congratulations");
                    Close();
                }
                else if (misses < 0)
                {
                    MessageBox.Show("You lost the game. Your tries run out!", "Try again");
                    Close();
                }

            }

        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Check to see if the player won
                CheckForWinner();

                if(choose == true)
                {
                    if (firstClicked.Text == secondClicked.Text)
                    {

                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }
                    else
                    {
                        misses -= 1;
                        missesLabel.Text = "Misses: " + misses.ToString();
                        if (misses <= -1)
                        {
                            missesLabel.Text = "You lost";
                        }
                        else
                        {
                            missesLabel.Text = "Misses: " + misses.ToString();
                        }


                    }
                }
                else
                {
                    if (firstClicked.Text == secondClicked.Text)
                    {

                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }
                }
                


                timer.Start();
            }
        }

        private void AssignIconsToSquares()
        {
            if (choose == false)
            {
                foreach (Control control in TLP2.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null)
                    {
                        int randomNumber = random.Next(icons2.Count);
                        iconLabel.Text = icons2[randomNumber];
                        iconLabel.ForeColor = iconLabel.BackColor;
                        icons2.RemoveAt(randomNumber);
                    }
                }
            }
            else if (choose == true)
            {
                foreach (Control control in TLP1.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null)
                    {
                        int randomNumber = random.Next(icons1.Count);
                        iconLabel.Text = icons1[randomNumber];
                        iconLabel.ForeColor = iconLabel.BackColor;
                        icons1.RemoveAt(randomNumber);
                    }
                }
            }

        }




        private void Mang_Load(object sender, EventArgs e)
        {

        }
    }
}

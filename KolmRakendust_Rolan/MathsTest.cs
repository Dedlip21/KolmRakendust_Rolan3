using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolmRakendust_Rolan
{
    public partial class MathsTest : Form
    {
        Label time, timeLabel1, plusLeftLabel1, plusRightLabel1, minusLeftLabel,
            minusRightLabel, multLeftLabel, multRightLabel, subLeftLabel, subRightLabel;

        NumericUpDown Sum1, Sum2, Sum3, Sum4;
        Random randomizer = new Random();
        Button button;
        Timer timer;

        Stopwatch sw;
        int seconds;
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;
        public MathsTest()
        {
            //-------------------Timer----------------------
            this.Size = new Size(500, 400);

            //---------------------time1----------------------
            timeLabel1 = new Label();
            timeLabel1.Text = "Time Left";
            timeLabel1.Name = "Time";
            timeLabel1.Font = new Font("Arial", 15);
            timeLabel1.Location = new Point(200);

            time = new Label();
            time.Location = new Point(230, 40);
            time.Font = new Font("Arial", 15);

            //---------------------left1----------------------
            plusLeftLabel1 = new Label();
            plusLeftLabel1.Text = "?  " + "     +";
            plusLeftLabel1.Name = "plusLeftLabel";
            plusLeftLabel1.Font = new Font("Arial", 15);
            plusLeftLabel1.Location = new Point(100, 100);
            //---------------------right1----------------------
            plusRightLabel1 = new Label();
            plusRightLabel1.Text = "?  " + "     =";
            plusRightLabel1.Name = "plusLeftLabel";
            plusRightLabel1.Font = new Font("Arial", 15);
            plusRightLabel1.Location = new Point(200, 100);
            //-----------------------Sum1----------------------
            Sum1 = new NumericUpDown();
            Sum1.Value = 0;
            Sum1.Name = "sum";
            Sum1.Font = new Font("Arial", 15);
            Sum1.Location = new Point(300, 100);
            Sum1.TabIndex = 1;


            //---------------------left2----------------------
            minusLeftLabel = new Label();
            minusLeftLabel.Text = "?  " + "     -";
            minusLeftLabel.Name = "plusLeftLabel";
            minusLeftLabel.Font = new Font("Arial", 15);
            minusLeftLabel.Location = new Point(100, 150);
            //---------------------right2----------------------
            minusRightLabel = new Label();
            minusRightLabel.Text = "?  " + "    =";
            minusRightLabel.Name = "plusLeftLabel";
            minusRightLabel.Font = new Font("Arial", 15);
            minusRightLabel.Location = new Point(200, 150);
            //-----------------------Sum2----------------------
            Sum2 = new NumericUpDown();
            Sum2.Value = 0;
            Sum2.Name = "sum";
            Sum2.Font = new Font("Arial", 15);
            Sum2.Location = new Point(300, 150);
            Sum2.TabIndex = 2;

            //---------------------left3----------------------
            multLeftLabel = new Label();
            multLeftLabel.Text = "?  " + "     x";
            multLeftLabel.Name = "plusLeftLabel";
            multLeftLabel.Font = new Font("Arial", 15);
            multLeftLabel.Location = new Point(100, 200);
            //---------------------right3----------------------
            multRightLabel = new Label();
            multRightLabel.Text = "?  " + "    =";
            multRightLabel.Name = "plusLeftLabel";
            multRightLabel.Font = new Font("Arial", 15);
            multRightLabel.Location = new Point(200, 200);
            //-----------------------Sum3----------------------
            Sum3 = new NumericUpDown();
            Sum3.Value = 0;
            Sum3.Name = "sum";
            Sum3.Font = new Font("Arial", 15);
            Sum3.Location = new Point(300, 200);
            Sum3.TabIndex = 3;

            //---------------------left4----------------------
            subLeftLabel = new Label();
            subLeftLabel.Text = "?  " + "     /";
            subLeftLabel.Name = "plusLeftLabel";
            subLeftLabel.Font = new Font("Arial", 15);
            subLeftLabel.Location = new Point(100, 250);
            //---------------------right4----------------------
            subRightLabel = new Label();
            subRightLabel.Text = "?  " + "   =";
            subRightLabel.Name = "plusLeftLabel";
            subRightLabel.Font = new Font("Arial", 15);
            subRightLabel.Location = new Point(200, 250);
            //-----------------------Sum4----------------------
            Sum4 = new NumericUpDown();
            Sum4.Value = 0;
            Sum4.Name = "sum";
            Sum4.Font = new Font("Arial", 15);
            Sum4.Location = new Point(300, 250);
            Sum4.TabIndex = 4;

            //----------------------Button----------------------
            button = new Button();
            button.Text = "Start";
            button.Location = new Point(200, 305);
            button.TabIndex = 0;
            button.AutoSize = true;
            button.Click += Button_Click;

            Controls.AddRange(new Control[] { timeLabel1, button, time });
            Controls.AddRange(new Control[] { plusLeftLabel1, plusRightLabel1, Sum1 });
            Controls.AddRange(new Control[] { minusLeftLabel, minusRightLabel, Sum2 });
            Controls.AddRange(new Control[] { multLeftLabel, multRightLabel, Sum3 });
            Controls.AddRange(new Control[] { subLeftLabel, subRightLabel, Sum4 });

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (button.Text == "Start" || button.Text == "You Won!" || button.Text == "You Lose")
            {
                StartTheQuiz();
                button.Text = "Check";
                this.BackColor = Color.White;
            }
            else
            {

                button.Text = "Start";
                if (CheckTheAnswer())
                {
                    button.Text = "You Won!";
                    this.BackColor = Color.LightGreen;
                    timer.Stop();
                }
                else
                {
                    button.Text = "You Lose";
                    this.BackColor = Color.IndianRed;
                    timer.Stop();
                }
            }
        }
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            minuend = randomizer.Next(101);
            subtrahend = randomizer.Next(1, minuend);

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            dividend = randomizer.Next(2, 11);
            divisor = randomizer.Next(2, 11);

            plusLeftLabel1.Text = addend1.ToString() + "      +";
            plusRightLabel1.Text = addend2.ToString() + "      =";

            minusLeftLabel.Text = minuend.ToString() + "      -";
            minusRightLabel.Text = subtrahend.ToString() + "      =";

            multLeftLabel.Text = multiplicand.ToString() + "      x";
            multRightLabel.Text = multiplier.ToString() + "      =";

            subLeftLabel.Text = dividend.ToString() + "      /";
            subRightLabel.Text = divisor.ToString() + "      =";
            Sum1.Value = 0;
            Sum2.Value = 0;
            Sum3.Value = 0;
            Sum4.Value = 0;
            timer = new Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            seconds = 20;
            time.Text = seconds--.ToString();
            time.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time.Text = seconds--.ToString();
            if (seconds < 0)
            {
                timer.Stop();
                time.Enabled = false;
                button.Text = "You Lose";
                this.BackColor = Color.IndianRed;
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == Sum1.Value)
                && (minuend - subtrahend == Sum2.Value)
                && (multiplicand * multiplier == Sum3.Value)
                && (dividend / divisor == Sum4.Value))
                return true;
            else
                return false;
        }

        private void MathsTest_Load(object sender, EventArgs e)
        {

        }
    }
}

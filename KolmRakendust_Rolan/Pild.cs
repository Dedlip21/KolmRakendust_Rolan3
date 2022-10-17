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
    public partial class Pild : Form
    {
        PictureBox pictureBox1 = new PictureBox();
        TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        ColorDialog ColorDialog = new ColorDialog();
        CheckBox box = new CheckBox();
        public Pild()
        {

            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            this.Size = new Size(815, 625);
            //------------------Table----------------------
            dynamicTableLayoutPanel.Location = new Point(0, 0);
            dynamicTableLayoutPanel.Name = "TableLayoutPanel1";
            dynamicTableLayoutPanel.Size = new Size(800, 600);
            dynamicTableLayoutPanel.BackColor = Color.Transparent;
            dynamicTableLayoutPanel.ColumnCount = 2;
            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90));
            dynamicTableLayoutPanel.RowCount = 2;
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            Controls.Add(dynamicTableLayoutPanel);
            //------------------Table----------------------
            //
            //----------------PictureBox-------------------

            pictureBox1.Size = MaximumSize;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.Gray;

            dynamicTableLayoutPanel.Controls.Add(pictureBox1, 0, 0);
            dynamicTableLayoutPanel.SetCellPosition(pictureBox1, new TableLayoutPanelCellPosition(0, 0));
            dynamicTableLayoutPanel.SetColumnSpan(pictureBox1, 2);
            //----------------PictureBox-------------------
            //
            //-----------------CheckBox--------------------

            box.Text = "Strech";

            box.CheckedChanged += CheckBox_CheckedChanged;
            dynamicTableLayoutPanel.Controls.Add(box, 0, 1);
            dynamicTableLayoutPanel.SetCellPosition(box, new TableLayoutPanelCellPosition(0, 1));
            //-----------------CheckBox--------------------
            //

            //-----------------Buttons---------------------
            FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();

            Button btnClose = new Button
            {
                Text = "Sulge",
                Name = "Close"
            };
            Button btnShow = new Button
            {
                Text = "Näita pilti",
                Name = "Show a picture"
            };
            Button btnClear = new Button
            {
                Text = "Tühjendage pilt",
                Name = "Clear_the_picture"
            };
            Button btnBgC = new Button
            {
                Text = "Määrake taustavärv",
                Name = "Set_the_background"

            };

            FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            FlowLayoutPanel1.Controls.AddRange(new Control[] { btnClose, btnShow, btnClear, btnBgC });
            FlowLayoutPanel1.Dock = DockStyle.Fill;
            dynamicTableLayoutPanel.Controls.Add(FlowLayoutPanel1, 1, 1);
            dynamicTableLayoutPanel.SetCellPosition(FlowLayoutPanel1, new TableLayoutPanelCellPosition(1, 1));
            btnClose.Click += Btn1_Click;
            btnShow.Click += BtnShow_Click;
            btnClear.Click += BtnClear_Click;
            btnBgC.Click += BtnBgC_Click;

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (box.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void BtnBgC_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = ColorDialog.Color;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Pild_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AdminLogin : Form
    {
        TableLayoutPanel TLP;
        Label user, passwd;
        Button login, back;
        TextBox enterUser, enterPasswd;
        /*private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;*/

        public AdminLogin()
        {
            InitializeComponent();

            this.Size = new Size(400, 400);

            TLP = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 4,
                BackColor = Color.LightSkyBlue,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                Name = "TableLayoutPanel1",
                TabIndex = 0
            };


            //TextBoxes
            enterUser = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Anchor = AnchorStyles.None,
                Width = 150
            };
            enterPasswd = new TextBox
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Anchor = AnchorStyles.None,
                Width = 150
            };

            //Buttons
            login = new Button
            {
                Text = "Login",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            login.Click += Login_Click;
            back = new Button
            {
                Text = "Back",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            back.Click += back_Click;


            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

            TLP.Controls.Add(user = new Label()
            {
                Text = "Enter User Name",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);
            TLP.Controls.Add(passwd = new Label()
            {
                Text = "Enter Password",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 1);

            TLP.Controls.Add(enterUser, 1, 0);
            TLP.Controls.Add(enterPasswd, 1, 1);
            TLP.Controls.Add(login, 0, 2);
            TLP.Controls.Add(back, 0, 3);
            TLP.SetColumnSpan(login, 2);
            TLP.SetColumnSpan(back, 2);
            Controls.Add(TLP);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (enterPasswd.Text != string.Empty || enterUser.Text != string.Empty)
            {
                if(enterPasswd.Text == "admin123" || enterUser.Text == "Admin")
                {
                    this.Close();
                    DataList DL = new DataList();
                    DL.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong password or username. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

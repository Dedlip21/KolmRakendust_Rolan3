using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KolmRakendust_Rolan.Kasutaja;

namespace KolmRakendust_Rolan
{
    public partial class Login : Form
    {
        TableLayoutPanel TLP;
        Label user, passwd;
        Button login, valja;
        TextBox enterUser, enterPasswd;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public static bool LoggedIn;
        public static bool logged
        {
            get { return LoggedIn; }
            set { LoggedIn = value; }
        }

        public Login()
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

            valja = new Button
            {
                Text = "Välja",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            valja.Click += valja_Click;


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
            TLP.Controls.Add(valja, 0, 3);
            TLP.SetColumnSpan(login, 2);
            TLP.SetColumnSpan(valja, 2);
            Controls.Add(TLP);
        }

        public static string username;
        public static string email;
        public static string sugu;
        public static string vanus;
        /*public static string getUsername
        {
            get { return username; }
            set { username = value; }
        }*/



        private void Login_Click(object sender, EventArgs e)
        {
            //logged = false;
            if (enterPasswd.Text != string.Empty || enterUser.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from LoginTable where username='" + enterUser.Text + "' and password='" + enterPasswd.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    username = enterUser.Text;
                    logged = true;
                    dr.Close();
                    this.Hide();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //dr.Close();
                
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //cn.Close();
            
        }

        private void valja_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Registr registration = new Registr();
            registration.ShowDialog();*/
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\TARpv20_RolanMaslennikov\KolmRakendust-master\KolmGG\Database.mdf;Integrated Security=True");
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rolan\source\repos\KolmRakendust_Rolan\KolmRakendust_Rolan\Database.mdf;Integrated Security=True");
            cn.Open();
        }
    }
}

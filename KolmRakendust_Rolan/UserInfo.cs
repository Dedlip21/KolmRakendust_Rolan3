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

namespace KolmRakendust_Rolan
{
    public partial class UserInfo : Form
    {
        TableLayoutPanel TLP;
        Label user, email, sugu, vanus;
        Label userAnswer, emailAnswer, suguAnswer, vanusAnswer;

        Button valja;

        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public UserInfo()
        {
            InitializeComponent();

            this.Size = new Size(400, 400);


            TLP = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 5,
                BackColor = Color.LightSkyBlue,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                Name = "TableLayoutPanel1",
                TabIndex = 0
            };

            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));


            TLP.Controls.Add(user = new Label()
            {
                Text = "User's name:",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);
            TLP.Controls.Add(email = new Label()
            {
                Text = "User's email:",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);
            TLP.Controls.Add(sugu = new Label()
            {
                Text = "User's sugu:",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);
            TLP.Controls.Add(vanus = new Label()
            {
                Text = "User's vanus:",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);


            


            valja = new Button
            {
                Text = "Välja",
                AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
            };
            valja.Click += valja_Click;

            TLP.Controls.Add(user, 0, 0);
            TLP.Controls.Add(email, 0, 1);
            TLP.Controls.Add(sugu, 0, 2);
            TLP.Controls.Add(vanus, 0, 3);

            

            TLP.Controls.Add(valja, 0, 4);
            TLP.SetColumnSpan(valja, 2);
            Controls.Add(TLP);
        }

        private void valja_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\TARpv20_RolanMaslennikov\KolmRakendust-master\KolmGG\Database.mdf;Integrated Security=True");
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rolan\source\repos\KolmRakendust_Rolan\KolmRakendust_Rolan\Database.mdf;Integrated Security=True");
            cn.Open();

            cmd = new SqlCommand("select * from LoginTable", cn);
            dr = cmd.ExecuteReader();

            //Right labels

            TLP.Controls.Add(userAnswer = new Label()
            {
                Text = Login.username,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);

            dr.Read();
            TLP.Controls.Add(emailAnswer = new Label()
            {
                Text = dr["email"].ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);

            dr.Read();
            TLP.Controls.Add(suguAnswer = new Label()
            {
                Text = dr["sugu"].ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);

            dr.Read();
            TLP.Controls.Add(vanusAnswer = new Label()
            {
                Text = dr["vanus"].ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                UseCompatibleTextRendering = true
            }, 0, 0);

            TLP.Controls.Add(userAnswer, 1, 0);
            TLP.Controls.Add(emailAnswer, 1, 1);
            TLP.Controls.Add(suguAnswer, 1, 2);
            TLP.Controls.Add(vanusAnswer, 1, 3);

            dr.Close();
            cn.Close();
        }
    }
}

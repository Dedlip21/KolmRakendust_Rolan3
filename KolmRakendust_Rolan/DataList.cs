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
    public partial class DataList : Form
    {
        ListBox userList;
        public SqlConnection cn;
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Button BtnExit, BtnChangePasswd, BtnDelete, BtnChangeUsername;

        public DataList()
        {
            InitializeComponent();

            this.Size = new Size(400, 400);

            userList = new ListBox
            {
                Size = new Size(200, 300),
                Location = new Point(10, 10),
                SelectionMode = SelectionMode.MultiExtended
            };

            //Buttons
            BtnDelete = new Button
            {
                Text = "Delete User",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50),
                Location = new Point(220, 10)
            };
            BtnDelete.Click += BtnDelete_Click;
            BtnExit = new Button
            {
                Text = "Exit",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50),
                Location = new Point(220, 70)
            };
            BtnExit.Click += BtnExit_Click;

            Controls.Add(userList);
            Controls.Add(BtnDelete);
            Controls.Add(BtnExit);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Delete from LoginTable where username='" + userList.Text + "'", cn);
            dr = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            MessageBox.Show("User is successfuly deleted!");
            dt.Load(dr);
            dt.EndLoadData();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataList_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\TARpv20_RolanMaslennikov\KolmRakendust-master\KolmGG\Database.mdf;Integrated Security=True");
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rolan\source\repos\KolmRakendust_Rolan\KolmRakendust_Rolan\Database.mdf;Integrated Security=True");
            cn.Open();
            dt = new DataTable();
            da = new SqlDataAdapter("select * from LoginTable", cn);
            da.Fill(dt);

            userList.DataSource = null;
            userList.DataSource = dt;
            userList.DisplayMember = "UserName";
        }
    }
}

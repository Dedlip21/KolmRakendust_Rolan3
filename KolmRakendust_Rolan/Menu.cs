using Microsoft.Win32;
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
    public partial class Menu : Form
    {
        TableLayoutPanel TLP;
        Label LblUsername;
        Button BtnPild, BtnMatem, BtnMang, BtnDB, BtnExit;
        bool game = MangChooseMode.GameIsOn;
        private SqlConnection cn;

        public Menu()
        {
            InitializeComponent();

            this.Size = new Size(500, 400);

            // Create an empty MainMenu.
            MainMenu mainMenu = new MainMenu();

            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();

            menuItem1.Text = "Registreerimine";
            menuItem2.Text = "Login";
            // Add two MenuItem objects to the MainMenu.
            mainMenu.MenuItems.Add(menuItem1);
            mainMenu.MenuItems.Add(menuItem2);

            menuItem1.Click += MenuItem1_Click;
            menuItem2.Click += MenuItem2_Click;

            // Bind the MainMenu to Form1.
            Menu = mainMenu;

            TLP = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 4,
                BackColor = Color.LightSkyBlue,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                Name = "TableLayoutPanel1",
                TabIndex = 0
            };

            //Labels


            LblUsername = new Label
            {
                //Text = "Username: " + Login.getUsername,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 15, FontStyle.Bold),
                Size = new Size(400, 50)
            };
            //LblUsername.MouseClick += LblUsername_MouseClick;

            //Buttons
            BtnPild = new Button
            {
                Text = "Pildi vaatamine",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50),
                Enabled = false
            };
            BtnMatem = new Button
            {
                Text = "Matemaatika test",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50),
                Enabled = false
            };
            BtnMang = new Button
            {
                Text = "Mälumäng",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50),
                Enabled = false
            };
            BtnDB = new Button
            {
                Text = "Andmebaas",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100, 50)
            };
            BtnExit = new Button
            {
                Text = "Välja",
                //AutoSize = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Font = new Font("Comic Sans MS", 10, FontStyle.Bold),
                Size = new Size(100,50)
            };

            BtnPild.Click += BtnPild_Click;
            BtnMatem.Click += BtnMatem_Click;
            BtnMang.Click += BtnMang_Click;
            BtnDB.Click += BtnDB_Click;
            BtnExit.Click += BtnExit_Click;

            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

            TLP.Controls.Add(LblUsername, 0, 0);
            TLP.Controls.Add(BtnPild, 0, 1);
            TLP.Controls.Add(BtnMatem, 1, 1);
            TLP.Controls.Add(BtnMang, 2, 1);
            TLP.Controls.Add(BtnDB, 1, 2);
            TLP.Controls.Add(BtnExit, 1, 3);

            TLP.SetColumnSpan(LblUsername, 3);

            Controls.Add(TLP);
        }

        private void LblUsername_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
            UserInfo info = new UserInfo();
            info.ShowDialog();
            Menu_Shown();
            Show();
        }

        private void Menu_Shown()
        {
            if (Login.logged == false)
            {
                LblUsername.Text = null;

                // Create an empty MainMenu.
                MainMenu mainMenu = new MainMenu();

                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();

                menuItem1.Text = "Registreerimine";
                menuItem2.Text = "Login";
                // Add two MenuItem objects to the MainMenu.
                mainMenu.MenuItems.Add(menuItem1);
                mainMenu.MenuItems.Add(menuItem2);

                menuItem1.Click += MenuItem1_Click;
                menuItem2.Click += MenuItem2_Click;

                // Bind the MainMenu to Form1.
                Menu = mainMenu;
            }
            else if (Login.logged == true)
            {
                //LblUsername.Text = "Username: " + Login.getUsername;
                LblUsername.Text = "Username: " + Login.username;

                MainMenu mainMenu = new MainMenu();

                MenuItem menuItemLogout = new MenuItem();

                menuItemLogout.Text = "Logout";

                mainMenu.MenuItems.Add(menuItemLogout);

                menuItemLogout.Click += MenuItemLogout_Click;

                Menu = mainMenu;

                BtnMang.Enabled = true;
                BtnMatem.Enabled = true;
                BtnPild.Enabled = true;
            }
        }


        private void MenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            Menu_Shown();
            Show();
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            Registr reg = new Registr();
            reg.ShowDialog();
            Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane.TTHK\source\repos\TARpv20_RolanMaslennikov\KolmRakendust-master\KolmGG\Database.mdf;Integrated Security=True");
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rolan\source\repos\KolmRakendust_Rolan\KolmRakendust_Rolan\Database.mdf;Integrated Security=True");
            cn.Open();

            /*if(Login.logged == false)
            {
                LblUsername.Text = null;
            }
            else if(Login.logged == true)
            {
                LblUsername.Text = "Username: " + Login.username;
            }
            

            if(LblUsername.Text == null)
            {

                MainMenu mainMenu = new MainMenu();

                MenuItem menuItemLogout = new MenuItem();

                menuItemLogout.Text = "Logout";

                mainMenu.MenuItems.Add(menuItemLogout);

                menuItemLogout.Click += MenuItemLogout_Click;

                Menu = mainMenu;

                BtnMang.Enabled = true;
                BtnMatem.Enabled = true;
                BtnPild.Enabled = true;
            }*/
        }

        private void MenuItemLogout_Click(object sender, EventArgs e)
        {
            LblUsername.Text = null;

            Login.logged = false;

            BtnMang.Enabled = false;
            BtnMatem.Enabled = false;
            BtnPild.Enabled = false;

            // Create an empty MainMenu.
            MainMenu mainMenu = new MainMenu();

            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();

            menuItem1.Text = "Registreerimine";
            menuItem2.Text = "Login";
            // Add two MenuItem objects to the MainMenu.
            mainMenu.MenuItems.Add(menuItem1);
            mainMenu.MenuItems.Add(menuItem2);

            menuItem1.Click += MenuItem1_Click;
            menuItem2.Click += MenuItem2_Click;

            // Bind the MainMenu to Form1.
            Menu = mainMenu;
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {
            Hide();
            /*DataList dataList = new DataList();
            dataList.ShowDialog();*/
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.ShowDialog();
            Show();
        }

        private void BtnMang_Click(object sender, EventArgs e)
        {

            Hide();
            MangChooseMode mang = new MangChooseMode();
            mang.ShowDialog();
            Show();
            /*if (game == true)
            {
                mang.ShowDialog();
            }
            Show();*/
        }

        private void BtnMatem_Click(object sender, EventArgs e)
        {
            Hide();
            MathsTest math = new MathsTest();
            math.ShowDialog();
            Show();
        }

        private void BtnPild_Click(object sender, EventArgs e)
        {
            Hide();
            Pild pild = new Pild();
            pild.ShowDialog();
            Show();
        }
    }
}

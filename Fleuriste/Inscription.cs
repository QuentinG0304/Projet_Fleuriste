using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fleuriste
{
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
        }

        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Client temp = new Client(connection, textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
            temp.Register();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accueil form1 = new Accueil();
            this.Hide();
            form1.Show();
        }


    }
}

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
    public partial class Bellefleur : Form
    {
        Client client;
        public Bellefleur()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            client = new Client(connection, 0);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Modification_Client page = new Modification_Client(Convert.ToInt32(textBox1.Text));
                this.Hide();
                page.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Id Client incorrect");
            }
        }

        private void Bellefleur_Load(object sender, EventArgs e)
        {
            label9.Text = client.BestBouquet();
            label10.Text = client.BestClientMonth();
            label11.Text = client.AVGBouquet();
            label16.Text = client.BestChiffreDaffaire();
            label12.AutoSize = true;
            label12.Text = client.LessSoldFlower();
            panel2.AutoScroll = true;
            // Ajout du label au panel
            panel2.Controls.Add(label12);
            // Ajout du panel au formulaire
            Controls.Add(panel2);

            label4.AutoSize = true;
            label4.Text = client.ListClient();
            panel1.AutoScroll = true;

            // Ajout du label au panel
            panel1.Controls.Add(label4);

            // Ajout du panel au formulaire
            Controls.Add(panel1);

            label14.AutoSize = true;
            label14.Text = client.AlertStock();
            panel3.AutoScroll = true;
            // Ajout du label au panel
            panel3.Controls.Add(label14);
            // Ajout du panel au formulaire
            Controls.Add(panel3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil page = new Accueil();
            page.Show();
        }
    }
}

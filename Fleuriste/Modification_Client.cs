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
    public partial class Modification_Client : Form
    {
        Client client;
        public Modification_Client(int idCLient)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            this.client = new Client(connection, idCLient);
            InitializeComponent();
        }

        private void Modification_Client_Load(object sender, EventArgs e)
        {
            label3.AutoSize = true;
            label3.Text = client.HistoriqueClient();
            panel1.Location = new Point(736, 200);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 300);
            panel1.TabIndex = 34;
            panel1.AutoScroll = true;

            // Ajout du label au panel
            panel1.Controls.Add(label3);

            // Ajout du panel au formulaire
            Controls.Add(panel1);

            label6.Text = client.prenom;
            label7.Text = client.nom;
            label8.Text = client.Statut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.UpdateStatut();
            label8.Text = client.Statut();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bellefleur page = new Bellefleur();
            page.Show();
        }
    }
}

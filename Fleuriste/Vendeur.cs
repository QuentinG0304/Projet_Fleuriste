using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class Vendeur : Form
    {
        Client client;
        public Vendeur()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            client = new Client(connection, 0);
            InitializeComponent();
        }

        private void Vendeur_Load(object sender, EventArgs e)
        {
            label8.Hide();


            label7.AutoSize = true;
            label7.Text = client.HistoCommandes();
            panel1.AutoScroll = true;
            // Ajout du label au panel
            panel1.Controls.Add(label7);
            // Ajout du panel au formulaire
            Controls.Add(panel1);

            label9.AutoSize = true;
            panel2.AutoScroll = true;
            // Ajout du label au panel
            panel2.Controls.Add(label9);
            // Ajout du panel au formulaire
            Controls.Add(panel2);


            label11.AutoSize = true;
            label11.Text = client.ShowStock();
            panel3.AutoScroll = true;
            // Ajout du label au panel
            panel3.Controls.Add(label11);
            // Ajout du panel au formulaire
            Controls.Add(panel3);
        }

        //Affichage de la commande 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label8.Show();
                label9.Text = client.Composition(Convert.ToInt16(textBox1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Id de commande incorrect");
            }

        }

        #region Changement de statut
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                client.UpdateCommand(Convert.ToInt32(textBox1.Text), "CC");
                label7.Text = client.HistoCommandes();

            }
            catch (Exception)
            {
                MessageBox.Show("Id de commande incorrect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                client.UpdateCommand(Convert.ToInt32(textBox1.Text), "CAL");
                label7.Text = client.HistoCommandes();

            }
            catch (Exception)
            {
                MessageBox.Show("Id de commande incorrect");
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                client.UpdateCommand(Convert.ToInt32(textBox1.Text), "CL");
                label7.Text = client.HistoCommandes();

            }
            catch (Exception)
            {
                MessageBox.Show("Id de commande incorrect");
            }
        }
        #endregion

        //Revenir à la page précédente
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil page = new Accueil();
            page.Show();
        }

        //Modification de commande
        private void button6_Click(object sender, EventArgs e)
        {
            Commande com = new Commande(Convert.ToInt32(textBox1.Text));
            if(com.Etat == "CPAV")
            {
                Modification_Commande page = new Modification_Commande(Convert.ToInt32(textBox1.Text));
                this.Hide();
                page.Show();
            }
            else
            {
                MessageBox.Show("Cette commande ne peut pas être modifiée");
            }

        }
    }
}

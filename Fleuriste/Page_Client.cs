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
    public partial class Page_Client : Form
    {

        int idCLient;
        Client client_actuel;
        public Page_Client(int idClient)
        {
            this.idCLient = idClient;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            client_actuel = new Client(connection, idCLient);
            InitializeComponent();
        }

        public Page_Client(Client client_actuel)
        {
            this.client_actuel = client_actuel;
            this.idCLient = client_actuel.IdClient;
            InitializeComponent();
        }

        private void Page_Client_Load(object sender, EventArgs e)
        {
            #region en-tête
            label1.Text = "Bonjour " + client_actuel.prenom + " " + client_actuel.nom;
            #endregion

            label11.Text = Convert.ToString(numericUpDown1.Value * 45 + numericUpDown2.Value * 65 + numericUpDown3.Value * 40 + numericUpDown4.Value * 80 + numericUpDown4.Value * 120);

            # region Initialisation des valeurs des dates

            numericUpDown6.Minimum = DateTime.Now.Day;
            numericUpDown7.Minimum = DateTime.Now.Month;
            if (numericUpDown7.Value == 1 || numericUpDown7.Value == 3 || numericUpDown7.Value == 5 || numericUpDown7.Value == 7 || numericUpDown7.Value == 8 || numericUpDown7.Value == 10 || numericUpDown7.Value == 12)
            {
                numericUpDown6.Maximum = 31;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 29;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 28;
            }
            else
            {
                numericUpDown6.Maximum = 30;
            }
            #endregion

            label18.AutoSize = true;
            label18.Text = client_actuel.HistoriqueClient();
            panel1.Location = new Point(736, 200);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 300);
            panel1.TabIndex = 34;
            panel1.AutoScroll = true;

            // Ajout du label au panel
            panel1.Controls.Add(label18);

            // Ajout du panel au formulaire
            Controls.Add(panel1);
        }



        private string texte()
        {
            string texte;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand update = connection.CreateCommand();
            update.CommandText = $" SELECT statut FROM clients WHERE idClient = {client_actuel.IdClient};";
            MySqlDataReader r = update.ExecuteReader();
            r.Read();
            string statut = r.GetString(0);
            update.Dispose();
            r.Close();

            if (statut == "OR")
            {

                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 45 + numericUpDown2.Value * 65 + numericUpDown3.Value * 40 + numericUpDown4.Value * 80 + numericUpDown5.Value * 120)) * 0.85) + " €";
            }
            else if (statut == "bronze")
            {

                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 45 + numericUpDown2.Value * 65 + numericUpDown3.Value * 40 + numericUpDown4.Value * 80 + numericUpDown5.Value * 120)) * 0.95) + " €";

            }
            else
            {
                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 45 + numericUpDown2.Value * 65 + numericUpDown3.Value * 40 + numericUpDown4.Value * 80 + numericUpDown5.Value * 120))) + " €";
            }
            return texte;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            label11.Text = texte();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 2023 && numericUpDown7.Value == DateTime.Now.Month)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2023)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = 0;
            }
            else
            {
                numericUpDown6.Minimum = 0;
                numericUpDown7.Minimum = 0;
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 2023 && numericUpDown7.Value == DateTime.Now.Month)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2023)
            {
                numericUpDown7.Minimum = DateTime.Now.Month;
                numericUpDown6.Minimum = 0;
            }
            else
            {
                numericUpDown6.Minimum = 0;
                numericUpDown7.Minimum = 0;
            }
            if (numericUpDown7.Value == 1 || numericUpDown7.Value == 3 || numericUpDown7.Value == 5 || numericUpDown7.Value == 7 || numericUpDown7.Value == 8 || numericUpDown7.Value == 10 || numericUpDown7.Value == 12)
            {
                numericUpDown6.Maximum = 31;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 29;
            }
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 == 0)
            {
                numericUpDown6.Maximum = 28;
            }
            else
            {
                numericUpDown6.Maximum = 30;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Arrangement floral avec marguerites et verdure", "Composition");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arrangement floral avec roses blanches et roses rouges", "Composition");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arrangement floral avec ginger, oiseaux du paradis, roses et genet", "Composition");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arrangement floral avec gerbera, roses blanches, lys et alstroméria", "Composition");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arrangement floral avec lys et orchidées ", "Composition");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0 && numericUpDown2.Value == 0 && numericUpDown3.Value == 0 && numericUpDown4.Value == 0 && numericUpDown5.Value == 0)
            {
                MessageBox.Show("Commande nulle");
            }
            else
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime date = new DateTime(Convert.ToInt32(numericUpDown8.Value), Convert.ToInt32(numericUpDown7.Value), Convert.ToInt32(numericUpDown6.Value));
                Commande com = new Commande(false, client_actuel, textBox1.Text, textBox2.Text, date, Convert.ToDouble(label11.Text.Replace(" €", "")));
                com.AddCommande();
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    Bouquet bouq = new Bouquet(connection, "Gros Merci");
                    bouq.AddBouquet(com.IdCommande);
                }
                for (int i = 0; i < numericUpDown2.Value; i++)
                {
                    Bouquet bouq = new Bouquet(connection, "L'Amoureux");
                    bouq.AddBouquet(com.IdCommande);
                }
                for (int i = 0; i < numericUpDown3.Value; i++)
                {
                    Bouquet bouq = new Bouquet(connection, "L'Exotique");
                    bouq.AddBouquet(com.IdCommande);
                }
                for (int i = 0; i < numericUpDown4.Value; i++)
                {
                    Bouquet bouq = new Bouquet(connection, "Maman");
                    bouq.AddBouquet(com.IdCommande);
                }
                for (int i = 0; i < numericUpDown5.Value; i++)
                {
                    Bouquet bouq = new Bouquet(connection, "Vive la Mariee");
                    bouq.AddBouquet(com.IdCommande);
                }
                label18.Text = client_actuel.HistoriqueClient();
                MessageBox.Show("Commande validée");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bouquet_perso bouquet = new Bouquet_perso(client_actuel);
            bouquet.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil page = new Accueil();
            page.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}

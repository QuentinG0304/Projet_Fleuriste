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
using System.Windows.Input;

namespace Fleuriste
{
    public partial class Bouquet_perso : Form
    {
        Client client;
        public Bouquet_perso(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void Page_Bouquet_Perso_Load(object sender, EventArgs e)
        {

            label11.Text = Convert.ToString(numericUpDown1.Value * 5 + numericUpDown2.Value * 4 + numericUpDown3.Value * Convert.ToDecimal(2.25) + numericUpDown4.Value * Convert.ToDecimal(2.5) + numericUpDown5.Value + numericUpDown13.Value * Convert.ToDecimal(1.5) + numericUpDown12.Value * 2 + numericUpDown11.Value * Convert.ToDecimal(0.75) + numericUpDown10.Value * Convert.ToDecimal(1.25) + numericUpDown9.Value * 10 + numericUpDown14.Value * Convert.ToDecimal(1.5)) + " €";

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
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 != 0)
            {
                numericUpDown6.Maximum = 28;
            }
            else
            {
                numericUpDown6.Maximum = 30;
            }

            numericUpDown17.Minimum = DateTime.Now.Day;
            numericUpDown16.Minimum = DateTime.Now.Month;
            if (numericUpDown16.Value == 1 || numericUpDown16.Value == 3 || numericUpDown16.Value == 5 || numericUpDown16.Value == 7 || numericUpDown16.Value == 8 || numericUpDown16.Value == 10 || numericUpDown16.Value == 12)
            {
                numericUpDown17.Maximum = 31;
            }
            else if (numericUpDown16.Value == 2 && numericUpDown15.Value % 4 == 0)
            {
                numericUpDown17.Maximum = 29;
            }
            else if (numericUpDown16.Value == 2 && numericUpDown15.Value % 4 != 0)
            {
                numericUpDown17.Maximum = 28;
            }
            else
            {
                numericUpDown17.Maximum = 30;
            }
            #endregion

            if (!(numericUpDown7.Value >= 5 && numericUpDown7.Value <= 11))
            {
                button5.Hide();
                numericUpDown5.Hide();
                numericUpDown5.Value = 0;
                label9.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page_Client page = new Page_Client(client);
            page.Show();
        }

        #region propriétés des numericUpDown
        private string texte()
        {
            string texte;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand update = connection.CreateCommand();
            update.CommandText = $" SELECT statut FROM clients WHERE idClient = {client.IdClient};";
            MySqlDataReader r = update.ExecuteReader();
            r.Read();
            string statut = r.GetString(0);
            update.Dispose();
            r.Close();

            if (statut == "OR")
            {

                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 5 + numericUpDown2.Value * 4 + numericUpDown3.Value * Convert.ToDecimal(2.25) + numericUpDown4.Value * Convert.ToDecimal(2.5) + numericUpDown5.Value + numericUpDown13.Value * Convert.ToDecimal(1.5) + numericUpDown12.Value * 2 + numericUpDown11.Value * Convert.ToDecimal(0.75) + numericUpDown10.Value * Convert.ToDecimal(1.25) + numericUpDown9.Value * 10 + numericUpDown14.Value * Convert.ToDecimal(1.5)) * Convert.ToDecimal(0.85))) + " €";
            }
            else if (statut == "bronze")
            {
                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 5 + numericUpDown2.Value * 4 + numericUpDown3.Value * Convert.ToDecimal(2.25) + numericUpDown4.Value * Convert.ToDecimal(2.5) + numericUpDown5.Value + numericUpDown13.Value * Convert.ToDecimal(1.5) + numericUpDown12.Value * 2 + numericUpDown11.Value * Convert.ToDecimal(0.75) + numericUpDown10.Value * Convert.ToDecimal(1.25) + numericUpDown9.Value * 10 + numericUpDown14.Value * Convert.ToDecimal(1.5)) * Convert.ToDecimal(0.85))) + " €";
            }
            else
            {
                texte = Convert.ToString(Convert.ToDouble((numericUpDown1.Value * 5 + numericUpDown2.Value * 4 + numericUpDown3.Value * Convert.ToDecimal(2.25) + numericUpDown4.Value * Convert.ToDecimal(2.5) + numericUpDown5.Value + numericUpDown13.Value * Convert.ToDecimal(1.5) + numericUpDown12.Value * 2 + numericUpDown11.Value * Convert.ToDecimal(0.75) + numericUpDown10.Value * Convert.ToDecimal(1.25) + numericUpDown9.Value * 10 + numericUpDown14.Value * Convert.ToDecimal(1.5)))) + " €";

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
            else if (numericUpDown7.Value == 2 && numericUpDown8.Value % 4 != 0)
            {
                numericUpDown6.Maximum = 28;
            }
            else
            {
                numericUpDown6.Maximum = 30;
            }

            if (!(numericUpDown7.Value >= 5 && numericUpDown7.Value <= 11))
            {
                button5.Hide();
                numericUpDown5.Hide();
                numericUpDown5.Value = 0;
                label9.Hide();
            }
            else
            {
                button5.Show();
                numericUpDown5.Show();
                label9.Show();
            }

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = texte();
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown15.Value == 2023)
            {
                numericUpDown17.Minimum = DateTime.Now.Day;
                numericUpDown16.Minimum = DateTime.Now.Month;
            }
            else
            {
                numericUpDown17.Minimum = 0;
                numericUpDown16.Minimum = 0;
            }
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown15.Value == 2023 && numericUpDown16.Value == DateTime.Now.Month)
            {
                numericUpDown16.Minimum = DateTime.Now.Month;
                numericUpDown15.Minimum = DateTime.Now.Day;
            }
            else if (numericUpDown8.Value == 2023)
            {
                numericUpDown16.Minimum = DateTime.Now.Month;
                numericUpDown17.Minimum = 0;
            }
            else
            {
                numericUpDown17.Minimum = 0;
                numericUpDown16.Minimum = 0;
            }
            if (numericUpDown16.Value == 1 || numericUpDown16.Value == 3 || numericUpDown16.Value == 5 || numericUpDown16.Value == 7 || numericUpDown16.Value == 8 || numericUpDown16.Value == 10 || numericUpDown16.Value == 12)
            {
                numericUpDown17.Maximum = 31;
            }
            else if (numericUpDown16.Value == 2 && numericUpDown15.Value % 4 == 0)
            {
                numericUpDown17.Maximum = 29;
            }
            else if (numericUpDown16.Value == 2 && numericUpDown15.Value % 4 != 0)
            {
                numericUpDown17.Maximum = 28;
            }
            else
            {
                numericUpDown17.Maximum = 30;
            }
        }
        #endregion

        #region bouton commande
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0 && numericUpDown2.Value == 0 && numericUpDown3.Value == 0 && numericUpDown4.Value == 0 && numericUpDown5.Value == 0
                && numericUpDown9.Value == 0 && numericUpDown10.Value == 0 && numericUpDown11.Value == 0 && numericUpDown12.Value == 0 && numericUpDown13.Value == 0 && numericUpDown14.Value==0)
            {
                MessageBox.Show("Commande nulle");
            }
            else
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime date = new DateTime(Convert.ToInt32(numericUpDown8.Value), Convert.ToInt32(numericUpDown7.Value), Convert.ToInt32(numericUpDown6.Value));
                Commande com = new Commande(true, client, textBox1.Text, textBox2.Text, date, Convert.ToDouble(label11.Text.Replace(" €", "")));
                com.AddCommande();
                Bouquet bouq = new Bouquet(connection, "Perso");
                bouq.Personnalisation(1, Convert.ToInt32(numericUpDown1.Value));

                bouq.Personnalisation(2, Convert.ToInt32(numericUpDown2.Value));

                bouq.Personnalisation(4, Convert.ToInt32(numericUpDown3.Value));

                bouq.Personnalisation(5, Convert.ToInt32(numericUpDown4.Value));

                bouq.Personnalisation(3, Convert.ToInt32(numericUpDown5.Value));

                bouq.Personnalisation(16, Convert.ToInt32(numericUpDown9.Value));

                bouq.Personnalisation(15, Convert.ToInt32(numericUpDown10.Value));

                bouq.Personnalisation(14, Convert.ToInt32(numericUpDown11.Value));

                bouq.Personnalisation(13, Convert.ToInt32(numericUpDown12.Value));

                bouq.Personnalisation(12, Convert.ToInt32(numericUpDown13.Value));

                bouq.Personnalisation(17, Convert.ToInt32(numericUpDown1.Value));

                bouq.AddBouquet(com.IdCommande);

                MessageBox.Show("Commande validée");
                this.Hide();
                Page_Client page = new Page_Client(client);
                page.Show();

            }

        }
        #endregion

        #region Description
        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le gerbera est une fleur colorée et vibrante qui symbolise la joie, l'innocence et la beauté naturelle. Il est souvent utilisé pour exprimer des sentiments d'amitié et de soutien.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le gingembre (Hedychium coronarium) est une fleur tropicale blanche et parfumée qui pousse en grappes. Elle est utilisée en médecine traditionnelle et en parfumerie.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le glaïeul est une fleur élégante et gracieuse originaire d'Afrique du Sud. Il est disponible dans une variété de couleurs et est souvent utilisé dans les bouquets de mariage.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La marguerite est une fleur simple et délicate qui symbolise l'innocence et la pureté. Elle est souvent utilisée dans les arrangements printaniers.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La rose rouge est une fleur classique et romantique qui symbolise l'amour et la passion. Elle est souvent utilisée pour exprimer des sentiments amoureux.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Un ruban en satin peut ajouter une touche élégante et sophistiquée à n'importe quel bouquet de fleurs.");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Les perles peuvent être enfilées sur des tiges de fleurs pour ajouter de la texture et de l'éclat aux arrangements floraux.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Un papier d'emballage coloré peut ajouter une touche de gaieté et de festivité aux bouquets de fleurs.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Les épingles à cheveux décoratives peuvent être utilisées pour fixer les fleurs dans les coiffures, ou pour ajouter une touche de brillance à un bouquet.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Un vase décoratif peut mettre en valeur les fleurs et ajouter une touche élégante à n'importe quelle pièce.");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La verdure est un accessoire de décoration florale qui ajoute de la texture et de la profondeur à un bouquet. Elle est souvent utilisée pour créer une base pour les fleurs et les autres accessoires.");
        }
        #endregion

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox3.Text);
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Prix ou description nulle");
                }
                else
                {
                    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    DateTime date = new DateTime(Convert.ToInt32(numericUpDown15.Value), Convert.ToInt32(numericUpDown16.Value), Convert.ToInt32(numericUpDown17.Value));
                    Commande com = new Commande(true, client, textBox4.Text, textBox5.Text, date, Convert.ToDouble(textBox3.Text.Replace(" €", "")), true);
                    com.AddCommande();
                    Bouquet bouq = new Bouquet(connection, "Perso");


                    bouq.AddBouquet(com.IdCommande);
                    MessageBox.Show("Commande validée");
                    this.Hide();
                    Page_Client page = new Page_Client(client);
                    page.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Prix incorrect");
            }

        }
    }
}

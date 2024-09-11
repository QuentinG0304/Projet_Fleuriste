using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fleuriste
{
    public partial class Modification_Commande : Form
    {
        int idCommande;
        string statut;
        public Modification_Commande(int idCommande)
        {
            InitializeComponent();
            this.idCommande = idCommande;
            this.statut = Client.GetClientStatut(idCommande);
        }

        private void Modification_Commande_Load(object sender, EventArgs e)
        {
            Commande com = new Commande(idCommande);
            label26.AutoSize = true;
            label26.Text = com.Message;
            panel1.AutoScroll = true;
            panel1.Controls.Add(label26);
            Controls.Add(panel1);

            numericUpDown1.Value = Client.NbItemCommande(idCommande, 1);
            numericUpDown2.Value = Client.NbItemCommande(idCommande, 2);
            numericUpDown3.Value = Client.NbItemCommande(idCommande, 4);
            numericUpDown4.Value = Client.NbItemCommande(idCommande, 5);
            numericUpDown5.Value = Client.NbItemCommande(idCommande, 3);
            numericUpDown13.Value = Client.NbItemCommande(idCommande, 12);
            numericUpDown12.Value = Client.NbItemCommande(idCommande, 13);
            numericUpDown11.Value = Client.NbItemCommande(idCommande, 14);
            numericUpDown10.Value = Client.NbItemCommande(idCommande, 15);
            numericUpDown9.Value = Client.NbItemCommande(idCommande, 16);
            numericUpDown14.Value = Client.NbItemCommande(idCommande, 17);
            label11.Text = texte();


            //Affichage du Prix Max ou non 

            if (!(numericUpDown1.Value == 0 && numericUpDown2.Value == 0 && numericUpDown3.Value == 0 && numericUpDown4.Value == 0 && numericUpDown5.Value == 0
                && numericUpDown9.Value == 0 && numericUpDown10.Value == 0 && numericUpDown11.Value == 0 && numericUpDown12.Value == 0 && numericUpDown13.Value == 0))
            {
                label2.Hide();
                label3.Hide();
                label1.Hide();
                panel1.Hide();
            }
            else
            {
                Commande com1 = new Commande(idCommande);
                label3.Text = Convert.ToString(com1.Montant_Total)+" €";
            }

        }


        private string texte()
        {
            string texte;

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

        #region Initialisation des numericUpAndDown
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

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vendeur page = new Vendeur();
            page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0 && numericUpDown2.Value == 0 && numericUpDown3.Value == 0 && numericUpDown4.Value == 0 && numericUpDown5.Value == 0
                && numericUpDown9.Value == 0 && numericUpDown10.Value == 0 && numericUpDown11.Value == 0 && numericUpDown12.Value == 0 && numericUpDown13.Value == 0)
            {
                MessageBox.Show("Commande nulle");
            }
            else
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                Commande com = new Commande(idCommande);
                Bouquet.UpdateBouquetPerso(idCommande, 1, Convert.ToInt32(numericUpDown1.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 2, Convert.ToInt32(numericUpDown2.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 3, Convert.ToInt32(numericUpDown5.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 4, Convert.ToInt32(numericUpDown3.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 5, Convert.ToInt32(numericUpDown4.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 12, Convert.ToInt32(numericUpDown13.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 13, Convert.ToInt32(numericUpDown12.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 14, Convert.ToInt32(numericUpDown11.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 15, Convert.ToInt32(numericUpDown10.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 16, Convert.ToInt32(numericUpDown9.Value));
                Bouquet.UpdateBouquetPerso(idCommande, 17, Convert.ToInt32(numericUpDown14.Value));
                com.Refresh(com.Date_Livraison, Convert.ToDouble(label11.Text.Replace("€", "")), "CC");
                MessageBox.Show("Commande validée");
                this.Hide();
                Vendeur page = new Vendeur();
                page.Show();

            }
        }
    }
}

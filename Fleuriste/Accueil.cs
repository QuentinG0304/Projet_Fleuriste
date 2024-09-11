using crypto;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Net.Sockets;
using System.Net;
using System;

namespace Fleuriste
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }
        public int idClient;
        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


        }

        //soumettre création client
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string mail = textBox1.Text;
            string mdp = textBox2.Text;
            if (Client.SignIn(connection, mail, mdp))
            {
                command.CommandText = $" SELECT idClient FROM clients WHERE courriel = '{mail}' AND mdp = '{mdp}';";
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                reader.Read();
                idClient = reader.GetInt32(0);
                command.Dispose();
                reader.Close();
                this.Hide();
                Page_Client form3 = new Page_Client(idClient);
                form3.Show();
            }
            else
            {
                MessageBox.Show("Adresse mail ou mot de passe incorrect");
            }

        }

        //Bouton S'inscrire
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inscription form2 = new Inscription();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form passwordBox = new Form();
            passwordBox.Text = "Entrez le mot de passe";
            passwordBox.Size = new Size(600, 300);
            passwordBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordBox.StartPosition = FormStartPosition.CenterScreen;

            // Création du label "Entrer le mot de passe"
            Label passwordLabel = new Label();
            passwordLabel.Text = "Entrer le mot de passe :";
            passwordLabel.Location = new Point(20, 20);
            passwordLabel.AutoSize = true;
            passwordBox.Controls.Add(passwordLabel);

            // Création de la zone de texte pour saisir le mot de passe
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Location = new Point(20, 50);
            passwordTextBox.Size = new Size(130, 20);
            passwordBox.Controls.Add(passwordTextBox);

            // Création du bouton "OK"
            Button okButton = new Button();
            okButton.Width = 50;
            okButton.Height = 40;
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Text = "OK";
            okButton.Location = new Point(200, 50);
            passwordBox.Controls.Add(okButton);

            // Affichage de la boîte de dialogue et récupération du mot de passe saisi
            DialogResult result = passwordBox.ShowDialog();
            string password = passwordTextBox.Text;

            // Vérification du résultat et du mot de passe
            if (result == DialogResult.OK)
            {
                if (password == "michel")
                {
                    // Mot de passe correct
                    this.Hide();
                    Bellefleur page = new Bellefleur();
                    page.Show();
                }
                else if(password == "vendeur")
                {
                    this.Hide();
                    Vendeur page = new Vendeur();
                    page.Show();
                }
                else
                {
                    // Mot de passe incorrect, affichage d'un message d'erreur
                    MessageBox.Show("Mot de passe incorrect !");
                }
            }

        }
    }
}
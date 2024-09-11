using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Fleuriste
{
    public class Client
    {
        int idClient;
        public int IdClient { get { return idClient; } }
        public string prenom { get; set; }

        public string nom { get; set; }
        public string numPhone { get; set; }
        public string mail { get; set; }
        public string mdp { get; set; }
        public string adresse { get; set; }
        public string creditCard { get; set; }

        static MySqlConnection connection;

        public MySqlConnection Connection { get { return connection; } }
        int uniqueID(string input)
        {
            SHA256 hash = SHA256.Create();
            byte[] str = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                str[i] = Convert.ToByte(input[i]);
            }
            byte[] hash1 = hash.ComputeHash(str);

            int ret = Math.Abs(BitConverter.ToInt32(hash1));

            return ret;
        }
        public Client(MySqlConnection connec, string prenom, string nom, string numPhone, string mail, string mdp, string adresse, string creditCard)
        {
            connection = connec;
            idClient = uniqueID(mail);
            this.prenom = prenom;
            this.nom = nom;
            this.numPhone = numPhone;
            this.mail = mail;
            this.mdp = mdp;
            this.adresse = adresse;
            this.creditCard = creditCard;
        }

        public Client(MySqlConnection connec, int id)
        {
            connection = connec;
            MySqlCommand command = connection.CreateCommand();
            idClient = id;
            command.CommandText = $" SELECT prenom, nom, telephone, courriel, mdp, adresse, carte_credit FROM clients WHERE idClient = {Convert.ToString(idClient)};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            this.prenom = reader.GetString(0);
            this.nom = reader.GetString(1);
            this.numPhone = reader.GetString(2);
            this.mail = reader.GetString(3);
            this.mdp = reader.GetString(4);
            this.adresse = reader.GetString(5);
            try
            {
                this.creditCard = reader.GetString(6);
            }
            catch (Exception)
            {

                creditCard = "";
            }
            reader.Close();
            command.Dispose();
        }

        public bool Register()
        {
            bool ret;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT courriel FROM clients WHERE courriel = '{mail}';";


            MySqlDataReader reader;
            reader = command.ExecuteReader();
            command.Dispose();
            bool cond = !reader.Read();
            if (cond)
            {
                reader.Close();
                MySqlCommand add = connection.CreateCommand();
                add.CommandText = $" INSERT INTO clients VALUES({idClient},'{nom}', '{prenom}', '{numPhone}', '{mail}', '{mdp}', '{adresse}','{creditCard}', 'normal'); ";
                add.ExecuteNonQuery();
                //ret = ("Le compte a été crée avec succès.");
                ret = true;
                add.Dispose();
            }
            else
            {
                reader.Close();
                ret = false;
                //ret = "Adresse mail déjà utilisée. \nVeuillez en saisir une nouvelle ou vous connecter.";
            }
            return ret;
        }

        static public bool SignIn(MySqlConnection connection, string mail, string pass)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT * FROM clients WHERE courriel = '{mail}' and mdp = '{pass}';";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            bool cond = reader.Read();
            if (cond)
            {
                reader.Close();
                command.Dispose();
                return true;
            }
            else
            {
                reader.Close();
                command.Dispose();
                return false;
            }
        }

        #region Clients

        public string HistoriqueClient()
        {
            string ret = "id     date commande       date livraison      prix \n";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT idCommande, date_commande, date_livraison, montant_total as prix FROM commandes WHERE idClient = {idClient} ORDER BY date_commande DESC;";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string idCommande = reader.GetString(0);
                string dateCom = reader.GetString(1).Replace("00:00:00", "");
                string dateLiv = reader.GetString(2).Replace("00:00:00", "");
                string prix = reader.GetString(3);

                for (int i = 0; i < 7; i++)
                {
                    if (i < idCommande.Length)
                    {
                        ret += idCommande[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (i < dateCom.Length)
                    {
                        ret += dateCom[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (i < dateLiv.Length)
                    {
                        ret += dateLiv[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i < prix.Length)
                    {
                        ret += prix[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                ret += "\n";

            }

            reader.Close();
            command.Dispose();
            return ret;
        }

        #endregion

        #region Bellefleur
        public string AVGBouquet()
        {
            string ret = "";
            if (idClient == 0)//l'id client de M. Bellefleur
            {
                MySqlCommand avgBouqBoughtCommand = connection.CreateCommand();
                avgBouqBoughtCommand.CommandText = " SELECT truncate(AVG(montant_total), 2) FROM commandes;";
                MySqlDataReader reader = avgBouqBoughtCommand.ExecuteReader();
                reader.Read();
                string avgBouqBought = reader.GetString(0);
                ret += $"{avgBouqBought}";
                avgBouqBoughtCommand.Dispose();
                reader.Close();
            }
            return ret;
        }

        public string BestClientMonth()
        {
            string ret = "";
            if (idClient == 0)
            {
                MySqlDataReader reader;
                MySqlCommand bestClientCommand = connection.CreateCommand();
                bestClientCommand.CommandText = " SELECT nom, prenom " +
                                                " FROM clients JOIN commandes ON clients.idClient = commandes.idClient" +
                                                " WHERE date_commande > DATE_FORMAT(CURRENT_DATE, '%Y-%m-01') and date_commande<DATE_FORMAT(DATE_ADD(CURRENT_DATE, INTERVAL 1 month), '%Y-%m-01')" +
                                                " GROUP BY clients.idClient" +
                                                " HAVING SUM(montant_total) >= ALL(SELECT SUM(montant_total)" +
                                                " FROM commandes" +
                                                " WHERE date_commande > DATE_FORMAT(CURRENT_DATE, '%Y-%m-01') and date_commande < DATE_FORMAT(DATE_ADD(CURRENT_DATE, INTERVAL 1 month), '%Y-%m-01')" +
                                                " GROUP BY commandes.idClient" +
                                                " ); ";

                reader = bestClientCommand.ExecuteReader();
                reader.Read();
                ret += $"{reader.GetString(0)} {reader.GetString(1)}";
                bestClientCommand.Dispose();
                reader.Close();
            }
            return ret;
        }

        public string BestBouquet()
        {
            string ret = "";
            if (idClient == 0)
            {
                MySqlDataReader reader;
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = " SELECT nom " +
                                                " FROM compo" +
                                                " GROUP BY nom" +
                                                " HAVING COUNT(nom) >= ALL(SELECT COUNT(nom) FROM compo GROUP BY nom); ";

                reader = command.ExecuteReader();
                reader.Read();
                ret += $"{reader.GetString(0)}";
                command.Dispose();
                reader.Close();
            }
            return ret;
        }

        public string LessSoldFlower()
        {
            List<string> ret = new List<string>();
            if (idClient == 0)
            {
                MySqlDataReader reader;
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT nom " +
                                      "FROM stock " +
                                      "WHERE stock.idItem NOT IN " +
                                      "(SELECT items.idItem FROM items) AND type = 'fleur';";

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add($"{reader.GetString(0)}");
                }
                reader.Close();
                command.Dispose();

                if (ret.Count() == 0)
                {
                    command.CommandText = " SELECT nom FROM items" +
                                          " JOIN stock ON items.idItem = stock.idItem" +
                                          " WHERE type = 'fleur'" +
                                          " GROUP BY nom" +
                                          " HAVING COUNT(items.idItem) <= ALL(" +
                                          " SELECT COUNT(idItem) FROM items GROUP BY idItem); ";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add($"{reader.GetString(0)}");
                    }

                }

                command.Dispose();
                reader.Close();
            }
            string ret1 = "";
            for (int i = 0; i < ret.Count; i++)
            {
                if (i < ret.Count - 1)
                {
                    ret1 += $"{ret[i]} ,";
                }
                else
                {
                    ret1 += $"{ret[i]}.";
                }
            }
            return ret1;
        }

        public string BestChiffreDaffaire()
        {
            string ret = "";
            if (idClient == 0)
            {
                MySqlDataReader reader;
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT b.idBoutique, SUM(montant_total)" +
                    " FROM commandes c JOIN boutique b ON c.idBoutique=b.idBoutique" +
                    " GROUP BY b.idBoutique" +
                    " HAVING SUM(montant_total)<=  ALL(" +
                    "SELECT SUM(montant_total)" +
                    " FROM boutique GROUP BY idboutique)" +
                    " ORDER BY SUM(montant_total)DESC;";

                reader = command.ExecuteReader();
                reader.Read();
                ret += $"{reader.GetString(0)} :  CA de {reader.GetString(1)} €";
                command.Dispose();
                reader.Close();
            }
            return ret;
        }

        public string AlertStock()
        {
            string ret = "Nom                 quantité\n";
            if (idClient == 0)
            {
                MySqlCommand command = connection.CreateCommand();
                SortedList<string, int> stock = new SortedList<string, int>();
                command.CommandText = " SELECT nom, quantite" +
                                      " FROM stock" +
                                      " WHERE quantite <= 10;";

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stock.Add(reader.GetString(0), reader.GetInt32(1));
                }
                reader.Close();
                command.Dispose();
                string nom;
                int quantite;
                for (int i = 0; i < stock.Count; i++)
                {
                    nom = stock.Keys[i];
                    quantite = stock[stock.Keys[i]];

                    for (int j = 0; j < 20; j++)
                    {
                        if (j < nom.Length)
                        {
                            ret += nom[j];
                        }
                        else
                        {
                            ret += " ";
                        }
                    }
                    ret += $"  {Convert.ToString(quantite)}\n";
                }
            }
            return ret;
        }

        public string ListClient()
        {
            string ret = "id                  nom                       prenom              statut \n";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT idClient, nom, prenom, statut FROM clients WHERE idClient != 0 AND idClient !=1;";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string idClient = reader.GetString(0);
                string nom = reader.GetString(1);
                string prenom = reader.GetString(2);
                string statut = reader.GetString(3);

                for (int i = 0; i < 12; i++)
                {
                    if (i < idClient.Length)
                    {
                        ret += idClient[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 25; i++)
                {
                    if (i < nom.Length)
                    {
                        ret += nom[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (i < prenom.Length)
                    {
                        ret += prenom[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    if (i < statut.Length)
                    {
                        ret += statut[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                ret += "\n";

            }

            reader.Close();
            command.Dispose();
            return ret;
        }

        public string Statut()
        {
            string ret = "";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT statut FROM clients WHERE idClient = {idClient};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            ret = reader.GetString(0);
            command.Dispose();
            reader.Close();
            return ret;
        }

        public void UpdateStatut()
        {
            string statut = Statut();
            MySqlCommand command = connection.CreateCommand();
            if (statut == "normal")
            {
                command.CommandText = $" UPDATE clients SET statut = 'bronze' WHERE idClient = {idClient};";
                command.ExecuteNonQuery();
            }
            else if (statut == "bronze")
            {
                command.CommandText = $" UPDATE clients SET statut = 'OR' WHERE idClient = {idClient};";
                command.ExecuteNonQuery();
            }
            else if (statut == "OR")
            {
                command.CommandText = $" UPDATE clients SET statut = 'normal' WHERE idClient = {idClient};";
                command.ExecuteNonQuery();
            }

            command.Dispose();

        }
        #endregion

        #region Vendeur

        public string Composition(int idCommande)
        {
            string ret = "idCompo   nom             description\n";

            MySqlCommand comp = connection.CreateCommand();
            comp.CommandText = $" SELECT idCompo, nom, description FROM compo WHERE idCommande = {idCommande};";
            MySqlDataReader compReader = comp.ExecuteReader();

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connec2 = new MySqlConnection(connectionString);
            connec2.Open();

            while (compReader.Read())
            {
                string idComp = compReader.GetString(0);
                string nom = compReader.GetString(1);
                string description = compReader.GetString(2);



                for (int i = 0; i < 10; i++)
                {
                    if (i < idComp.Length)
                    {
                        ret += idComp[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    if (i < nom.Length)
                    {
                        ret += nom[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                ret += description + "\n\n";


                MySqlCommand it = connec2.CreateCommand();
                it.CommandText = $" SELECT items.idItem, nom, items.quantite FROM items JOIN stock ON items.idItem = stock.idItem WHERE idCompo = {idComp}; ";
                MySqlDataReader itReader = it.ExecuteReader();

                ret += "\tidItem     nom                  quantite\n";
                while (itReader.Read())
                {

                    string idItem = itReader.GetString(0);
                    string name = itReader.GetString(1);
                    string quant = itReader.GetString(2);

                    ret += "\t";
                    for (int i = 0; i < 11; i++)
                    {
                        if (i < idItem.Length)
                        {
                            ret += idItem[i];
                        }
                        else
                        {
                            ret += " ";
                        }
                    }

                    for (int i = 0; i < 24; i++)
                    {
                        if (i < name.Length)
                        {
                            ret += name[i];
                        }
                        else
                        {
                            ret += " ";
                        }
                    }

                    ret += quant + "\n";

                }
                ret += "\n";
                itReader.Close();
                it.Dispose();

            }

            compReader.Close();
            comp.Dispose();
            connec2.Close();
            return ret;
        }

        public void UpdateCommand(int idCommande, string etat)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" UPDATE commandes SET etat = '{etat}' WHERE idCommande = {idCommande};";
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public string HistoCommandes()
        {
            string ret = "id     date commande       date livraison      prix      etat\n";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT idCommande, date_commande, date_livraison, montant_total as prix, etat FROM commandes WHERE etat != 'CL';";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string idCommande = reader.GetString(0);
                string dateCom = reader.GetString(1).Replace("00:00:00", "");
                string dateLiv = reader.GetString(2).Replace("00:00:00", "");
                string prix = reader.GetString(3);
                string etat = reader.GetString(4);

                for (int i = 0; i < 7; i++)
                {
                    if (i < idCommande.Length)
                    {
                        ret += idCommande[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (i < dateCom.Length)
                    {
                        ret += dateCom[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (i < dateLiv.Length)
                    {
                        ret += dateLiv[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i < prix.Length)
                    {
                        ret += prix[i];
                    }
                    else
                    {
                        ret += " ";
                    }
                }

                ret += $"{etat}\n";

            }

            reader.Close();
            command.Dispose();
            return ret;
        }

        public string ShowStock()
        {

            string ret = "Nom                 quantité\n";
            if (idClient == 0)
            {
                MySqlCommand command = connection.CreateCommand();
                SortedList<string, int> stock = new SortedList<string, int>();
                command.CommandText = " SELECT nom, quantite" +
                                        " FROM stock;";


                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    stock.Add(reader.GetString(0), reader.GetInt32(1));
                }
                reader.Close();
                command.Dispose();
                string nom;
                int quantite;
                for (int i = 0; i < stock.Count; i++)
                {
                    nom = stock.Keys[i];
                    quantite = stock[stock.Keys[i]];

                    for (int j = 0; j < 20; j++)
                    {
                        if (j < nom.Length)
                        {
                            ret += nom[j];
                        }
                        else
                        {
                            ret += " ";
                        }
                    }
                    ret += $"  {Convert.ToString(quantite)}\n";
                }
            }
            return ret;

        }

        public static int NbItemCommande(int idCommande, int idItem)
        {
            int ret;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT SUM(items.quantite) FROM items JOIN compo ON items.idCompo = compo.idCompo JOIN commandes ON commandes.idCommande = compo.IdCommande WHERE idItem = {idItem} AND compo.idCommande = {idCommande};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                ret = reader.GetInt32(0);

            }
            catch (Exception)
            {
                ret = 0;


            }
            reader.Close();
            command.Dispose();
            return ret;
            
        }

        public static string GetClientStatut(int idCommande)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT DISTINCT(statut) FROM clients JOIN commandes ON commandes.idClient = clients.idClient WHERE idCommande = {idCommande};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ret = reader.GetString(0);
            reader.Close();
            command.Dispose();
            return ret;

        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Pkix;

namespace Fleuriste
{
    class Commande
    {
        int idClient;
        DateTime date_commande;
        DateTime date_livraison;
        public DateTime Date_Livraison { get { return date_livraison; } }
        string message;
        public string Message { get { return message; } set { message = value; } }

        double montant_total;
        public double Montant_Total { get { return montant_total; } set { montant_total = value; } }
        string adresse_livraison;
        string etat;
        public string Etat { get { return etat; } }
        MySqlConnection connection;
        int idCommande;
        public int IdCommande { get { return idCommande; } }
        int idBoutique;
        public Commande(bool perso, Client client, string mess, string adresse, DateTime delivery, double montant = 0, bool AV = false)
        {
            idClient = client.IdClient;
            adresse_livraison = adresse;
            connection = client.Connection;
            date_commande = DateTime.Today;
            date_livraison = delivery;
            message = mess;
            montant_total = montant;
            if(AV)
            {
                etat = "CPAV";
            }
            else if(IsCommandSure() && perso)
            {
                etat = "CC";
            }
            else if(!IsCommandSure() && perso)
            {
                etat = "CPAV";
            }
            else if(IsCommandSure() && !perso)
            {
                etat = "CC";
            }
            else
            {
                etat = "VINV";
            }

            Random nbr = new Random();
            this.idBoutique = nbr.Next(1, 4);
        }

        public Commande(int idcommande)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            this.connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $" SELECT idclient,  message, adresse_livraison,date_livraison, montant_total, idboutique, date_commande, etat FROM commandes WHERE idCommande = {idcommande};";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            this.idClient = reader.GetInt32(0);
            adresse_livraison = reader.GetString(2);
            DateTime date_co = new DateTime(Convert.ToInt32(reader.GetString(6).Substring(6,4)), Convert.ToInt32(reader.GetString(6).Substring(3, 2)), Convert.ToInt32(reader.GetString(6).Substring(0, 2)));
            date_commande = date_co;
            DateTime date_li = new DateTime(Convert.ToInt32(reader.GetString(3).Substring(6,4)), Convert.ToInt32(reader.GetString(3).Substring(3, 2)), Convert.ToInt32(reader.GetString(3).Substring(0, 2)));
            date_livraison = date_li;
            message = reader.GetString(1);
            montant_total = reader.GetInt32(4);
            this.idBoutique = reader.GetInt32(5);
            this.etat = reader.GetString(7);
            this.idCommande = idcommande;
            reader.Close();
            command.Dispose();
        }
        public void AddCommande()
        {
            string date_com;
            string date_liv;
            if (date_commande.Month >= 10)
            {
                date_com = $"{date_commande.Year}-{date_commande.Month}-{date_commande.Day}";
            }
            else
            {
                date_com = $"{date_commande.Year}-0{date_commande.Month}-{date_commande.Day}";
            }

            if (date_livraison.Month >= 10)
            {
                date_liv = $"{date_livraison.Year}-{date_livraison.Month}-{date_livraison.Day}";
            }
            else
            {
                date_liv = $"{date_livraison.Year}-0{date_livraison.Month}-{date_livraison.Day}";
            }

            MySqlCommand add = connection.CreateCommand();

            add.CommandText = ($" INSERT INTO commandes(idClient, date_commande,date_livraison,adresse_livraison,message,montant_total,etat, idBoutique) VALUES({idClient}, '{date_com}', '{date_liv}', '{adresse_livraison}', '{message}', {Convert.ToString(montant_total).Replace(',', '.')}, '{etat}', {idBoutique});");
            add.ExecuteNonQuery();
            add.Dispose();

            MySqlCommand idCom = connection.CreateCommand();
            idCom.CommandText = ($" SELECT MAX(idCommande) FROM commandes WHERE idClient = {idClient};");
            MySqlDataReader r = idCom.ExecuteReader();
            r.Read();
            idCommande = r.GetInt32(0);
            idCom.Dispose();
            r.Close();

            MySqlCommand update = connection.CreateCommand();
            update.CommandText = $" SELECT COUNT(idCommande) FROM commandes WHERE idClient = {idClient} AND date_commande < DATE_FORMAT(DATE_ADD(CURRENT_DATE, INTERVAL 1 month), '%Y-%m-01') AND date_commande > DATE_FORMAT(CURRENT_DATE, '%Y-%m-01');";
            r = update.ExecuteReader();
            r.Read();
            int nbCom = r.GetInt32(0);
            update.Dispose();
            r.Close();

            update = connection.CreateCommand();
            update.CommandText = $" SELECT statut FROM clients WHERE idClient = {idClient};";
            r = update.ExecuteReader();
            r.Read();
            string statut = r.GetString(0);
            update.Dispose();
            r.Close();


            if (nbCom == 5)
            {
                update = connection.CreateCommand();
                update.CommandText = $" UPDATE clients SET statut = 'OR' WHERE idClient = {idClient};";
                update.ExecuteNonQuery();
                update.Dispose();

            }
            else if (nbCom == 1)
            {
                update = connection.CreateCommand();
                update.CommandText = $" UPDATE clients SET statut = 'bronze' WHERE idClient = {idClient};";
                update.ExecuteNonQuery();
                update.Dispose();
            }

        }

        public void Refresh(DateTime dateLiv, double prix, string state)
        {
            date_livraison = dateLiv;
            montant_total = prix;
            etat = state;
            string date_liv = "";
            if (date_livraison.Month >= 10)
            {
                date_liv = $"{dateLiv.Year}-{dateLiv.Month}-{dateLiv.Day}";
            }
            else
            {
                date_liv = $"{dateLiv.Year}-0{dateLiv.Month}-{dateLiv.Day}";
            }
            MySqlCommand refresh = connection.CreateCommand();
            refresh.CommandText = $" UPDATE commandes SET date_livraison = '{date_liv}', montant_total = {Convert.ToString(prix).Replace(',', '.')}, etat = '{state}' WHERE idCommande = {idCommande};";
            refresh.ExecuteNonQuery();
            refresh.Dispose();
        }

        public bool IsCommandSure()
        {
            bool ret = true;
            TimeSpan days = new TimeSpan(3, 0, 0, 0);
            if (date_livraison - date_commande < days)
            {
                ret = false;
            }
            return ret;
        }
    }
}

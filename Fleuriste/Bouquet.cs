using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Fleuriste
{
    class Bouquet
    {
        string nom;
        string description;
        double prix;
        public double Prix { get { return prix; } }
        List<int> composition;
        MySqlConnection connection;
        int idCompo;
        bool isPerso;

        public Bouquet(MySqlConnection connection, string name, string description = "", double price = -1)
        {
            this.connection = connection;
            composition = new List<int>();
            isPerso = false;
            switch (name)
            {
                case "Gros Merci":
                    GrosMerci();
                    break;
                case "L'Amoureux":
                    Amoureux();
                    break;
                case "L'Exotique":
                    Exotique();
                    break;
                case "Maman":
                    Maman();
                    break;
                case "Vive la Mariee":
                    Mariee();
                    break;
                default:
                    nom = name;
                    this.description = description;
                    prix = price;
                    isPerso = true;
                    break;
            }
        }

        public void Personnalisation(int idItem, int quantite)//à relier aux boutons pour créer un bouquet personnalisé avec une quantité d'item 
        {
            for (int i = 0; i < quantite; i++)
            {
                composition.Add(idItem);
            }
            MySqlCommand destock = connection.CreateCommand();
            destock.CommandText = $" UPDATE stock SET quantite = quantite - {quantite} WHERE idItem = {idItem};";
            destock.ExecuteNonQuery();
            destock.Dispose();

        }
        public void AddBouquet(int idCommande)
        {
            if (isPerso)
            {
                MySqlCommand add = connection.CreateCommand();
                add.CommandText = $" INSERT INTO compo VALUES(0, \"{nom}\", \"{description}\", {idCommande}, {Convert.ToString(prix).Replace(',', '.')});";
                add.ExecuteNonQuery();
                add.Dispose();

                MySqlCommand idComp = connection.CreateCommand();
                idComp.CommandText = ($" SELECT MAX(idCompo) FROM compo WHERE idCommande = {idCommande};");
                MySqlDataReader r = idComp.ExecuteReader();
                r.Read();
                idCompo = r.GetInt32(0);
                idComp.Dispose();
                r.Close();

                SortedList<int, int> dis = new SortedList<int, int>();

                for (int i = 0; i < composition.Count; i++)
                {
                    if (!dis.Keys.Contains(composition[i]))
                    {
                        dis.Add(composition[i], 1);
                    }
                    else
                    {
                        dis[composition[i]] += 1;
                    }
                }


                for (int i = 0; i < dis.Keys.Count; i++)
                {
                    MySqlCommand addIt = connection.CreateCommand();
                    addIt.CommandText = $" INSERT INTO items VALUES({dis.Keys[i]}, {idCompo}, {dis[dis.Keys[i]]});";
                    addIt.ExecuteNonQuery();
                    addIt.Dispose();
                }
            }
            else
            {
                MySqlCommand add = connection.CreateCommand();
                add.CommandText = $" INSERT INTO compo VALUES(0, \"{nom}\", \"{description}\", {idCommande}, {Convert.ToString(prix).Replace(',', '.')});";
                add.ExecuteNonQuery();
                add.Dispose();

                MySqlCommand idComp = connection.CreateCommand();
                idComp.CommandText = ($" SELECT MAX(idCompo) FROM compo WHERE idCommande = {idCommande};");
                MySqlDataReader r = idComp.ExecuteReader();
                r.Read();
                idCompo = r.GetInt32(0);
                idComp.Dispose();
                r.Close();

                SortedList<int, int> dis = new SortedList<int, int>();

                for (int i = 0; i < composition.Count; i++)
                {
                    if (!dis.Keys.Contains(composition[i]))
                    {
                        dis.Add(composition[i], 1);
                    }
                    else
                    {
                        dis[composition[i]] += 1;
                    }
                }


                for (int i = 0; i < dis.Keys.Count; i++)
                {
                    MySqlCommand addIt = connection.CreateCommand();
                    addIt.CommandText = $" INSERT INTO items VALUES({dis.Keys[i]}, {idCompo}, 0);";
                    addIt.ExecuteNonQuery();
                    addIt.Dispose();
                }
            }

        }

        public static void UpdateBouquetPerso(int idCommande, int idItem, int quantite)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand findBouq = connection.CreateCommand();
            findBouq.CommandText = $" SELECT idCompo FROM compo WHERE idCommande = {idCommande};";
            MySqlDataReader r = findBouq.ExecuteReader();
            r.Read();
            int idBouq = r.GetInt32(0);
            r.Close();
            findBouq.Dispose();

            MySqlCommand update = connection.CreateCommand();
            try
            {
                update.CommandText = $" UPDATE items SET quantite = {quantite} WHERE idCompo = {idBouq} AND idItem = {idItem};";
                update.ExecuteNonQuery();
            }
            catch (Exception)
            {
                update.CommandText = $" INSERT INTO items VALUES({idItem}, {idBouq}, {quantite});";
                update.ExecuteNonQuery();
            }
            update.Dispose();


            MySqlCommand destock = connection.CreateCommand();
            destock.CommandText = $" UPDATE stock SET quantite = quantite - {quantite} WHERE idItem = {idItem};";
            destock.ExecuteNonQuery();
            destock.Dispose();

            connection.Close();

        }

        public void GrosMerci()
        {
            nom = "Gros Merci";
            description = "Toute occasion";
            prix = 45;
            composition.Add(4);
            composition.Add(17);
        }

        public void Amoureux()
        {
            nom = "L'Amoureux";
            description = "St-Valentin";
            prix = 65;
            composition.Add(8);
            composition.Add(5);
        }

        public void Exotique()
        {
            nom = "L'Exotique";
            description = "Toute occasion";
            prix = 40;
            composition.Add(2);
            composition.Add(7);
            composition.Add(5);
            composition.Add(18);
        }

        public void Maman()
        {
            nom = "Maman";
            description = "Fête des mères";
            prix = 80;
            composition.Add(1);
            composition.Add(8);
            composition.Add(9);
            composition.Add(10);
        }

        public void Mariee()
        {
            nom = "Vive la mariée";
            description = "Mariage";
            prix = 120;
            composition.Add(9);
            composition.Add(11);
        }

    }
}

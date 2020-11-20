using MySql.Data.MySqlClient;
using System;
using MetierTrader;
using System.Collections.Generic;

namespace GestionnaireBDD
{
    public class GstBdd
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        // Constructeur
        public GstBdd()
        {
            string chaine = "Server=localhost;Database=bourse;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Trader> getAllTraders()
        {
            List<Trader> lesTraders = new List<Trader>();

            cmd = new MySqlCommand("SELECT idTrader, nomTrader FROM trader", cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Trader unTrader = new Trader(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesTraders.Add(unTrader);
            }
            dr.Close();
            return lesTraders;
        }
        public List<ActionPerso> getAllActionsByTrader(int numTrader)
        {
            List<MetierTrader.Action> LesActionsPerso = new List<MetierTrader.Action>();
            cmd = new MySqlCommand("select idAction, nomAction, prixAchat, (acheter.prixAchat * acheter.quantite) from action INNER JOIN acheter ON action.idAction = acheter.numAction INNER JOIN trader ON acheter.numTrader = trader.idTrader where idTrader = " + numTrader, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionPerso uneActionPerso = new ActionPerso(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                lesActionsPerso.Add(uneActionPerso);
            }
            dr.Close();
            return lesActionsPerso;
        }

        public List<MetierTrader.Action> getAllActionsNonPossedees(int numTrader)
        {
            int actionsNonPossedees;
            cmd = new MySqlCommand("select idAction, nomAction from action INNER JOIN acheter ON acheter.numAction = action.idAction WHERE acheter.numTrader != " + numTrader, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            actionsNonPossedees = Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
            dr.Close();
            return actionsNonPossedees;
        }

        public void SupprimerActionAcheter(int numAction, int numTrader)
        {
            cmd = new MySqlCommand("insert into categorie values(" + numCateg + ",'" + nomCateg + "','https://zupimages.net/up/19/34/5rph.jpg')", cnx);
            cmd.ExecuteNonQuery();
        }

        public void UpdateQuantite(int numAction, int numTrader, int quantite)
        {
            
        }

        public double getCoursReel(int numAction)
        {
            int coursReel;
            cmd = new MySqlCommand("select coursReel from action WHERE numAction = " + numAction, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            coursReel = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            return coursReel;
        }
        public void AcheterAction(int numAction, int numTrader, double prix, int quantite)
        {

        }
        public double getTotalPortefeuille(int numTrader)
        {
            int total;
            cmd = new MySqlCommand("select (prixAchat * quantite) from acheter", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            total = Convert.ToInt16(dr[0].ToString();
            dr.Close();
            return total;
        }
    }
}

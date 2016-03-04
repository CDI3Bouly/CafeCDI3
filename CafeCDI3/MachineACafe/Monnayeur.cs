using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineACafe
{
    [Serializable]
    public class Monnayeur : IMonnayeur
    {
        private Dictionary<int, int> caisse;
        private Dictionary<int, int> capacite;
        private Dictionary<int, int> compteur;
        private int id;

        public Monnayeur(int id)
        {
            this.id = id;
            compteur = new Dictionary<int, int>();
            caisse = new Dictionary<int, int>();
            capacite = new Dictionary<int, int>();
        }

        //ajout d'une nouvelle piece que la machine accepte de prendre
        bool IMonnayeur.insertCoinType(double coin, int cap, int max)
        {
            int piece = Convert.ToInt16(coin * 100);    //convertion de la valeur en centime
            if (compteur.ContainsKey(piece) == false)   //verifier si la piece existe déjà dans le compteur
                compteur.Add(piece, 0);               //ajout de la piece ainsi que la capacite stocké 
            if (caisse.ContainsKey(piece) == false)     //verifier si la piece existe déjà dans la caisse
            {
                caisse.Add(piece, cap);                   //ajout de la piece et initialisation à 0 pour la commande
                capacite.Add(piece, max);               //ajout de la piece ainsi que la capacité maximum quelle paut avoir
            }
            return true;
        }

        //ajout d'une piece par le consommateur pour une commande
        bool IMonnayeur.insertCoin(double coin)
        {
            int piece = Convert.ToInt16(coin * 100);    //convertion de la valeur en centime
            if (compteur.ContainsKey(piece) == true)    //verifier si la piece existe dans le compteur
            {
                compteur[piece]++;                      //ajouter cette piece parmis ceux déjà donné
                return true;
            }
            else return false;
        }

        //valeur de la monnaie a rendre
        bool IMonnayeur.annuler()
        {
            foreach (KeyValuePair<int, int> c in compteur)
            {
                compteur[c.Key] = 0;
            }
            return true;
        }

        //obtenir la capacité pour chaque piece du monnayeur
        int[] IMonnayeur.capMonnayeur()
        { 
            int i = 0;
            int[] p = new int[6];                             //création du tableau à retourner
            foreach (KeyValuePair<int, int> c in capacite)    //parcours du dictionnaire "capacite"
            {
                p[i] = c.Value;                               //insertion de la valeur de la ligne du dictionnaire dans le tableau
                i++;                                        
            }
            return p;                                         //retourne le tableau
        }

        //affiche les valeurs de caisses et de compteur
        string IMonnayeur.etat()
        {
            double tcaisse = 0, tcompteur = 0;
            string etat;
            foreach (KeyValuePair<int, int> c in caisse)    //verifie chaque ligne du dictionnaire "caisse"
            {
                tcaisse += ((c.Value * c.Key) / 100);       //calcule, convertie en € et ajoute au total de la valeur de la caisse
            }
            foreach (KeyValuePair<int, int> c in compteur)  //verifie chaque ligne du dictionnaire "compteur"
            {
                tcompteur += ((c.Value * c.Key) / 100);     //calcule, convertie en € et ajoute au total de la valeur du compteur
            }
            etat = "la caisse contient: " + tcaisse + "€ et le compteur contient: " + tcompteur + "€";
            return etat;
        }

        //verifie le nombre de chaque piece dans la caisse
        int[] IMonnayeur.etatCaisse()
        {
            int i = 0;
            int[] p = new int[6];                           //création du tableau à retourner
            foreach (KeyValuePair<int, int> c in caisse)    //parcours du dictionnaire "caisse"
            {
                p[i] = c.Value;                             //insertion de la valeur de la ligne du dictionnaire dans le tableau
                i++;
            }
            return p;                                       //retourne le tableau
        }

        //verifie le nombre de chaque piece dans le compteur
        int[] IMonnayeur.etatCompteur()
        {
            int i = 0;
            int[] p = new int[6];                             //création du tableau à retourner
            foreach (KeyValuePair<int, int> c in compteur)    //parcours du dictionnaire "compteur"
            {
                p[i] = c.Value;                               //insertion de la valeur de la ligne du dictionnaire dans le tableau
                i++;
            }
            return p;                                         //retourne le tableau
        }

        //verifie le prix restant à payer ou rendre 
        double IMonnayeur.checkInsertedMoney(double n)
        {
            double tcompteur = 0, reste;
            foreach (KeyValuePair<int, int> c in compteur)  
            {
                tcompteur += ((c.Value * c.Key) / 100);     
            }
            reste = tcompteur - n;
            return reste;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineACafe
{
    public interface IMonnayeur
    {
        /* ===== Méthodes Front Office ===== */
        bool insertCoin(double coin);
        bool annuler();

        /* ===== Méthodes Back Office ===== */
        string etat();
        int[] capMonnayeur();
        int[] etatCaisse();
        int[] etatCompteur();
        double checkInsertedMoney(double n);

        /* ===== MODE CONSOLE ===== */
        bool insertCoinType(double coin, int cap, int max);
        //int[] capMonnayeur(int cap);
        //int[] capMonnayeur(int[] caps);
    }
}

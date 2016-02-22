using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeCDI3Project
{
    interface IMachine
    {
        /* ===== Méthodes Front Office ===== */
        // Machine
        string showBoisson(int num);
        double showPrice(int num);
        void prepareBoisson();
        void getBoisson(int num);
        void annuler();

        // Monnayeur
        void insertCoin(double coin);
        void getChange();

        /* ===== Méthodes Back Office ===== */
        // Machine
        void initMachine();

        // Monnayeur
        void initMonnayeur();
        void etatMonnayeur();
        double checkInsertedMoney();

    }
}
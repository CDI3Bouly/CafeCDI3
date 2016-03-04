using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineACafe
{
    public interface IMachine
    {
        /* ===== Méthodes Front Office ===== */
        string showBoisson(int num);
        double showPrice(int num);
        bool serveBoisson(int num);
        //int prepBoisson(int num);

        /* ===== Méthodes Back Office ===== */
        bool initMachine(int num);
        bool saveMachine(int num);
        string getPassword();

        // Ajout et modification des boissons
        bool addBoisson(string name);
        bool addBoisson(int num, string name);
        bool addBoisson(string[] names);
        bool modBoisson(int num, string name);

        // Etat des boissons
        int capBoisson(int num);
        int etatBoisson(int num);
        bool refillBoisson(int num);

        // Etat des gobelets
        int capGobelet();
        int etatGobelet();
        bool refillGobelet();

        // Etat du sucre
        int capSucre();
        int etatSucre();
        bool refillSucre();

        /* ===== MODE CONSOLE ===== */
        string ToString();

        bool addBoisson(string name, int cap);
        bool addBoisson(int num, string name, int cap);
        bool addBoisson(string[] names, int[] cap);
        bool modBoisson(int num, int cap);
        bool modBoisson(int num, string name, int cap);

        int capGobelet(int cap);
        int capSucre(int cap);
    }
}
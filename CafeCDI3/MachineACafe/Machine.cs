using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineACafe
{
    public class Machine
    {
        private int id;
        private Monnayeur leMonnayeur;
        private struct CaracB
        {
            public Boisson b;
            public double prix;
            public int cap;
        }
        private Dictionary<int, CaracB> lesBoissons;

        public Machine(int id)
        {
            this.id = id;
        }
        public void ajouterBoisson(int code, Boisson b, double p, int c)
        {
            CaracB boisson = new CaracB();
            boisson.b = b;
            boisson.prix = p;
            boisson.cap = c;
            lesBoissons.Add(code, boisson);
        }
        public void supprimerBoisson(int code)
        {
            lesBoissons.Remove(code);
        }

    }
}

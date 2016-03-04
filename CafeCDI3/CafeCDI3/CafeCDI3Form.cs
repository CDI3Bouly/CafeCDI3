using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MachineACafe;

namespace CafeCDI3Project
{
    [Serializable]
    public partial class CafeCDI3Form : Form
    {
        private IMachine cafeMachine;
        private IMonnayeur cafeMoney;
        private Timer time;
        private bool booted1, booted2, hasAccess;

        public CafeCDI3Form()
        {
            InitializeComponent();
        }

        private void CafeCDI3Form_Load(object sender, EventArgs e)
        {
            booted1 = false;
            booted2 = false;
            hasAccess = false;
            BootMachine(1);
            InitializeTimer();
        }

        private void CafeCDI3Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cafeMachine.saveMachine(1);
        }

        /* ===== BOUTONS Front Office ===== */
        // Boissons
        private void btBoisson1_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(1);
            RefreshAll();
        }

        private void btBoisson2_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(2);
            RefreshAll();
        }

        private void btBoisson3_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(3);
            RefreshAll();
        }

        private void btBoisson4_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(4);
            RefreshAll();
        }

        private void btBoisson5_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(5);
            RefreshAll();
        }

        private void btBoisson6_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(6);
            RefreshAll();
        }

        private void btBoisson7_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(7);
            RefreshAll();
        }

        private void btBoisson8_Click(object sender, EventArgs e)
        {
            //cafeMachine.serveBoisson(8);
            RefreshAll();
        }

        private void btTake_Click(object sender, EventArgs e)
        {
            pbPrep.Value = 0;
            time.Start();
            btTake.Visible = false;
        }

        // Sucre
        private void btMoreSugar_Click(object sender, EventArgs e)
        {
            pbSugar.Increment(1);
        }

        private void btLessSugar_Click(object sender, EventArgs e)
        {
            pbSugar.Increment(-1);
        }

        // Monnaie
        private void bt2Euro_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(2.00);
        }

        private void bt1Euro_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(1.00);
        }

        private void bt50Cent_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(0.50);
        }

        private void bt20Cent_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(0.20);
        }

        private void bt10Cent_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(0.10);
        }

        private void bt5Cent_Click(object sender, EventArgs e)
        {
            //cafeMoney.insertCoin(0.05);
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            //cafeMoney.getChange();
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            //cafeMoney.annuler();
        }
        /* ===== MENU ===== */
        // Choix machine
        private void menuMachine1_Click(object sender, EventArgs e)
        {
            //BootMachine(1);
        }

        private void menuMachine2_Click(object sender, EventArgs e)
        {
            //BootMachine(2);
        }

        // Accès maintenance
        private void menuMaintenance_Click(object sender, EventArgs e)
        {
            menuMaintenance.Checked = !menuMaintenance.Checked;

            if (!menuMaintenance.Checked)
            {
                btMaintenance.Visible = false;
                btMonnayeur.Visible = false;
                panelLogo.Visible = true;
                gbBoissons.Visible = true;
                gbMonnayeur.Visible = true;
            }

            else
            {
                if (!hasAccess)
                {
                    if (askPassword())
                    {
                        btMaintenance.Visible = true;
                        btMonnayeur.Visible = true;
                        menuLock.Visible = true;
                    }

                    else
                    {
                        menuMaintenance.Checked = false;
                    }
                }

                else
                {
                    btMaintenance.Visible = true;
                    btMonnayeur.Visible = true;
                }
            }
        }

        private void menuLock_Click(object sender, EventArgs e)
        {
            if (menuMaintenance.Checked)
            {
                menuMaintenance_Click(sender, e);
            }

            menuLock.Visible = false;
            hasAccess = false;
        }

        /* ===== BOUTONS Back Office ===== */
        // Serrures
        private void btMaintenance_Click(object sender, EventArgs e)
        {
            panelLogo.Visible = !panelLogo.Visible;
            gbBoissons.Visible = !gbBoissons.Visible;
        }

        private void btMonnayeur_Click(object sender, EventArgs e)
        {
            gbMonnayeur.Visible = !gbMonnayeur.Visible;
        }

        // Boissons mises en vente
        private void btChBoiss1_Click(object sender, EventArgs e)
        {
            if (labelBoisson1.Text == "")
            {
                editBoisson(1);
            }
        }

        private void btChBoiss2_Click(object sender, EventArgs e)
        {
            if (labelBoisson2.Text == "")
            {
                editBoisson(2);
            }
        }

        private void btChBoiss3_Click(object sender, EventArgs e)
        {
            if (labelBoisson3.Text == "")
            {
                editBoisson(3);
            }
        }

        private void btChBoiss4_Click(object sender, EventArgs e)
        {
            if (labelBoisson4.Text == "")
            {
                editBoisson(4);
            }
        }

        private void btChBoiss5_Click(object sender, EventArgs e)
        {
            if (labelBoisson5.Text == "")
            {
                editBoisson(5);
            }
        }

        private void btChBoiss6_Click(object sender, EventArgs e)
        {
            if (labelBoisson6.Text == "")
            {
                editBoisson(6);
            }
        }

        private void btChBoiss7_Click(object sender, EventArgs e)
        {
            if (labelBoisson7.Text == "")
            {
                editBoisson(7);
            }
        }

        private void btChBoiss8_Click(object sender, EventArgs e)
        {
            if (labelBoisson8.Text == "")
            {
                editBoisson(8);
            }
        }

        // Niveaux d'eau & de sucre
        private void btCupRefill_Click(object sender, EventArgs e)
        {
            //ReplenishCups();
        }

        private void btSugarRefill_Click(object sender, EventArgs e)
        {
            //ReplenishSugar();
        }

        // Niveaux des boissons
        private void btRefillB1_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(1);
        }

        private void btRefillB2_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(2);
        }

        private void btRefillB3_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(3);
        }

        private void btRefillB4_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(4);
        }

        private void btRefillB5_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(5);
        }

        private void btRefillB6_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(6);
        }

        private void btRefillB7_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(7);
        }

        private void btRefillB8_Click(object sender, EventArgs e)
        {
            //ReplenishBoisson(8);
        }

        private void btRefillAll_Click(object sender, EventArgs e)
        {
            //ReplenishAll();
        }

        // Monnayeur
        private void btBackMonnayeur_Click(object sender, EventArgs e)
        {
            //cafeMoney.initMonnayeur();
        }

        /* ===== AUTRES CONTROLES ===== */
        private void tbDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        /* ===== FONCTIONS & PROCEDURES ===== */
        // Démarrage de la machine
        private void BootMachine(int num)
        {
            if (isBooted(num))
            {
                MessageBox.Show("La machine " + num + " est déjà lancée.");
            }

            else
            {
                //cafeMachine = new Machine(1);
                InitMonnayeur(num);
                RefreshAll();

                if (num == 1)
                {
                    booted1 = true;
                    booted2 = false;
                }

                if (num == 2)
                {
                    booted1 = false;
                    booted2 = true;
                }
            }
        }

        private bool isBooted(int num)
        {
            bool b = false;

            if (num == 1)
            {
                b = booted1;
            }

            if (num == 2)
            {
                b = booted2;
            }

            return b;
        }

        // Mises à jour
        private void RefreshAll()
        {
            RefreshMonnayeur();
            //RefreshCaps();
            //RefreshLevels();
            //RefreshFrontLabels();
            //RefreshBackLabels();
        }

        private void RefreshCaps()
        {
            // Capacités Maximales
            pbCup.Maximum = cafeMachine.capGobelet();
            pbSugarB.Maximum = cafeMachine.capSucre();
            pbBoisson1.Maximum = cafeMachine.capBoisson(1);
            pbBoisson2.Maximum = cafeMachine.capBoisson(2);
            pbBoisson3.Maximum = cafeMachine.capBoisson(3);
            pbBoisson4.Maximum = cafeMachine.capBoisson(4);
            pbBoisson5.Maximum = cafeMachine.capBoisson(5);
            pbBoisson6.Maximum = cafeMachine.capBoisson(6);
            pbBoisson7.Maximum = cafeMachine.capBoisson(7);
            pbBoisson8.Maximum = cafeMachine.capBoisson(8);
        }

        private void RefreshLevels()
        {
            // Niveaux actuels
            pbCup.Value = cafeMachine.etatGobelet();
            pbSugarB.Value = cafeMachine.etatSucre();
            pbBoisson1.Value = cafeMachine.etatBoisson(1);
            pbBoisson2.Value = cafeMachine.etatBoisson(2);
            pbBoisson3.Value = cafeMachine.etatBoisson(3);
            pbBoisson4.Value = cafeMachine.etatBoisson(4);
            pbBoisson5.Value = cafeMachine.etatBoisson(5);
            pbBoisson6.Value = cafeMachine.etatBoisson(6);
            pbBoisson7.Value = cafeMachine.etatBoisson(7);
            pbBoisson8.Value = cafeMachine.etatBoisson(8);
        }

        private void RefreshFrontLabels()
        {
            // Labels Front Office
            labelBoisson1.Text = cafeMachine.showBoisson(1);
            labelBoisson2.Text = cafeMachine.showBoisson(2);
            labelBoisson3.Text = cafeMachine.showBoisson(3);
            labelBoisson4.Text = cafeMachine.showBoisson(4);
            labelBoisson5.Text = cafeMachine.showBoisson(5);
            labelBoisson6.Text = cafeMachine.showBoisson(6);
            labelBoisson7.Text = cafeMachine.showBoisson(7);
            labelBoisson8.Text = cafeMachine.showBoisson(8);
        }

        private void RefreshBackLabels()
        {
            // Labels Back Office
            lbl1.Text = cafeMachine.showBoisson(1) + " : " + pbBoisson1.Value + "/" + pbBoisson1.Maximum;
            lbl2.Text = cafeMachine.showBoisson(2) + " : " + pbBoisson2.Value + "/" + pbBoisson2.Maximum;
            lbl3.Text = cafeMachine.showBoisson(3) + " : " + pbBoisson3.Value + "/" + pbBoisson3.Maximum;
            lbl4.Text = cafeMachine.showBoisson(4) + " : " + pbBoisson4.Value + "/" + pbBoisson4.Maximum;
            lbl5.Text = cafeMachine.showBoisson(5) + " : " + pbBoisson5.Value + "/" + pbBoisson5.Maximum;
            lbl6.Text = cafeMachine.showBoisson(6) + " : " + pbBoisson6.Value + "/" + pbBoisson6.Maximum;
            lbl7.Text = cafeMachine.showBoisson(7) + " : " + pbBoisson7.Value + "/" + pbBoisson7.Maximum;
            lbl8.Text = cafeMachine.showBoisson(8) + " : " + pbBoisson8.Value + "/" + pbBoisson8.Maximum;
        }

        // Modification des boissons mises en vente
        private void editBoisson(int num)
        {
            string label = "";
            string text = "";

            switch (num)
            {
                case 1: label = labelBoisson1.Text;
                        text = tbChBoiss1.Text;
                        tbChBoiss1.Clear();
                        break;

                case 2: label = labelBoisson2.Text;
                        text = tbChBoiss2.Text;
                        tbChBoiss2.Clear();
                        break;

                case 3: label = labelBoisson3.Text;
                        text = tbChBoiss3.Text;
                        tbChBoiss3.Clear();
                        break;

                case 4: label = labelBoisson4.Text;
                        text = tbChBoiss4.Text;
                        tbChBoiss4.Clear();
                        break;

                case 5: label = labelBoisson5.Text;
                        text = tbChBoiss5.Text;
                        tbChBoiss5.Clear();
                        break;

                case 6: label = labelBoisson6.Text;
                        text = tbChBoiss6.Text;
                        tbChBoiss6.Clear();
                        break;

                case 7: label = labelBoisson7.Text;
                        text = tbChBoiss7.Text;
                        tbChBoiss7.Clear();
                        break;

                case 8: label = labelBoisson8.Text;
                        text = tbChBoiss8.Text;
                        tbChBoiss8.Clear();
                        break;
            }

            editBoissMachine(num, text, label);
            RefreshAll();
        }

        public void editBoissMachine(int num, string text, string label)
        {
            if (label == "")
            {
                cafeMachine.addBoisson(text);
            }

            else
            {
                cafeMachine.modBoisson(num, text);
            }
        }

        // Niveaux des boissons
        private void ReplenishBoisson(int num)
        {
            cafeMachine.refillBoisson(num);
            int etat = cafeMachine.etatBoisson(num);

            switch (num)
            {
                case 1: pbBoisson1.Value = etat;
                        break;

                case 2: pbBoisson2.Value = etat;
                        break;

                case 3: pbBoisson3.Value = etat;
                        break;

                case 4: pbBoisson4.Value = etat;
                        break;

                case 5: pbBoisson5.Value = etat;
                        break;

                case 6: pbBoisson6.Value = etat;
                        break;

                case 7: pbBoisson7.Value = etat;
                        break;

                case 8: pbBoisson8.Value = etat;
                        break;
            }

            RefreshAll();
        }

        // Niveaux d'eau et de sucre
        private void ReplenishCups()
        {
            cafeMachine.refillGobelet();
            pbCup.Value = cafeMachine.etatGobelet();
            lblCup.Text = "Gobelets : " + pbCup.Value + "/" + pbCup.Maximum;
        }

        private void ReplenishSugar()
        {
            cafeMachine.refillSucre();
            pbSugarB.Value = cafeMachine.etatSucre();
            lblSucre.Text = "Sucre : " + pbSugarB.Value + " / " + pbSugarB.Maximum;
        }

        // Remplissage total
        private void ReplenishAll()
        {
            ReplenishCups();
            ReplenishSugar();

            for (int i = 1; i < 9; i++)
            {
                ReplenishBoisson(i);
            }
        }

        // Monnayeur
        private void InitMonnayeur(int num)
        {
            cafeMoney = new Monnayeur(num);
            cafeMoney.insertCoinType(2.00, 0, 100);
            cafeMoney.insertCoinType(1.00, 0, 200);
            cafeMoney.insertCoinType(0.50, 0, 200);
            cafeMoney.insertCoinType(0.20, 0, 200);
            cafeMoney.insertCoinType(0.10, 0, 100);
            cafeMoney.insertCoinType(0.05, 0, 100);
            RefreshMonnayeur();
        }

        private void RefreshMonnayeur()
        {
            RefreshCaisseCaps();
            RefreshCaisseLevels();
            RefreshCaisseLabels();
        }

        private void RefreshCaisseCaps()
        {
            // Capacités maximales
            pb2E.Maximum = cafeMoney.capMonnayeur()[0];
            pb1E.Maximum = cafeMoney.capMonnayeur()[1];
            pb50c.Maximum = cafeMoney.capMonnayeur()[2];
            pb20c.Maximum = cafeMoney.capMonnayeur()[3];
            pb10c.Maximum = cafeMoney.capMonnayeur()[4];
            pb5c.Maximum = cafeMoney.capMonnayeur()[5];
        }

        private void RefreshCaisseLevels()
        {
            // Niveaux actuels
            pb2E.Value = cafeMoney.etatCaisse()[0];
            pb1E.Value = cafeMoney.etatCaisse()[1];
            pb50c.Value = cafeMoney.etatCaisse()[2];
            pb20c.Value = cafeMoney.etatCaisse()[3];
            pb10c.Value = cafeMoney.etatCaisse()[4];
            pb5c.Value = cafeMoney.etatCaisse()[5];
        }

        private void RefreshCaisseLabels()
        {
            lbl2E.Text = "2€ : " + pb2E.Value + " / " + pb2E.Maximum;
            lbl1E.Text = "1€ : " + pb1E.Value + " / " + pb1E.Maximum;
            lbl50c.Text = "50c : " + pb50c.Value + " / " + pb50c.Maximum;
            lbl20c.Text = "20c : " + pb20c.Value + " / " + pb20c.Maximum;
            lbl10c.Text = "10c : " + pb10c.Value + " / " + pb10c.Maximum;
            lbl5c.Text = "5c : " + pb5c.Value + " / " + pb5c.Maximum;
        }

        private void InitializeTimer()
        {
            time = new Timer();
            time.Interval = 100;
            time.Tick += new EventHandler(IncreaseProgressBar);
            time.Start();
        }

        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Hardware Insert.wav");
            pbPrep.Increment(1);
            if (pbPrep.Value == pbPrep.Maximum)
            {
                time.Stop();
                btTake.Visible = true;
                tbDisplay.Text = "Boisson prête.\r\n Attention !\r\n C'est chaud !";
                player.Play();
            }
        }

        private bool askPassword()
        {
            using (var form = new PasswordPrompt(cafeMachine))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    hasAccess = form.GrantAcces;
                }
            }

            return hasAccess;
        }
    }
}

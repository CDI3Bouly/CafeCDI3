using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CafeCDI3Project
{
    public partial class CafeCDI3Form : Form
    {
        private Timer time;
        private IMachine cafeMachine;

        public CafeCDI3Form()
        {
            InitializeComponent();
        }

        private void CafeCDI3Form_Load(object sender, EventArgs e)
        {
            cafeMachine.initMachine();
            time = new Timer();
            time.Interval = 100;
            time.Tick += new EventHandler(IncreaseProgressBar);
            time.Start();
        }

        /* ===== BOUTONS Front Office ===== */
        // Boissons
        private void btBoisson1_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(1);
        }

        private void btBoisson2_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(2);
        }

        private void btBoisson3_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(3);
        }

        private void btBoisson4_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(4);
        }

        private void btBoisson5_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(5);
        }

        private void btBoisson6_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(6);
        }

        private void btBoisson7_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(7);
        }

        private void btBoisson8_Click(object sender, EventArgs e)
        {
            cafeMachine.getBoisson(8);
        }

        private void btTake_Click(object sender, EventArgs e)
        {
            pbPrep.Increment(-100);
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
            cafeMachine.insertCoin(2.00);
        }

        private void bt1Euro_Click(object sender, EventArgs e)
        {
            cafeMachine.insertCoin(1.00);
        }

        private void bt50Cent_Click(object sender, EventArgs e)
        {
            cafeMachine.insertCoin(0.50);
        }

        private void bt20Cent_Click(object sender, EventArgs e)
        {
            cafeMachine.insertCoin(0.20);
        }

        private void bt10Cent_Click(object sender, EventArgs e)
        {
            cafeMachine.insertCoin(0.10);
        }

        private void bt5Cent_Click(object sender, EventArgs e)
        {
            cafeMachine.insertCoin(0.05);
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            cafeMachine.getChange();
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            cafeMachine.annuler();
        }

        /* ===== BOUTONS Back Office ===== */
        // Serrures
        private void btMaintenance_Click(object sender, EventArgs e)
        {
            panelLogo.Visible = !panelLogo.Visible;
        }

        private void btMonnayeur_Click(object sender, EventArgs e)
        {
            gbMonnayeur.Visible = !gbMonnayeur.Visible;
        }

        // Machine



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

        // Méthodes
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
    }
}

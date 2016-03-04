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
    public partial class PasswordPrompt : Form
    {
        private IMachine cafeMach;
        public bool GrantAcces { get;set;}

        public PasswordPrompt(IMachine mach)
        {
            InitializeComponent();
            cafeMach = mach;
            GrantAcces = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputPass = textBox1.Text;

            if (inputPass != "test")
            {
                MessageBox.Show("Mot de passe incorrect ! Accès refusé !", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                GrantAcces = true;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1_Click(sender, e); }
        }
    }
}

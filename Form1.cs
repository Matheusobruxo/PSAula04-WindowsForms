using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PSAULA04_AppBanco
{
    public partial class Form1 : Form
    {
        public static double saldo = 0.00;
        string extrato;



        public Form1()
        {
            InitializeComponent();
            lblSaldo.Text = $"R$ {saldo}";
            txtOperacao.Focus();
        }

        private void btnExtrato_Click(object sender, EventArgs e)
        {
            MessageBox.Show(extrato);
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            lblOperacao.Text = "Saque"; 

            btnDepositar.BackColor = Color.RosyBrown;
            btnExtrato.BackColor = Color.RosyBrown;

            btnSacar.BackColor = Color.LightCoral;
            btnEnviar.BackColor = Color.LightCoral;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            lblOperacao.Text = "Depósito";

            btnSacar.BackColor = Color.RosyBrown;
            btnExtrato.BackColor = Color.RosyBrown;
            btnDepositar.BackColor = Color.LightCoral;
            btnEnviar.BackColor = Color.LightCoral;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (lblOperacao.Text == "Saque")
            {
                double saque = double.Parse(txtOperacao.Text);
                saldo = saldo - saque;
                lblSaldo.Text = $"R$ {saldo}";
            }
            else
            {
                double deposito = double.Parse(txtOperacao.Text);
                saldo = saldo + deposito;
                lblSaldo.Text = $"R$ {saldo}";
            }
            
            extrato = $"Você fez {lblOperacao.Text} de R$ {txtOperacao.Text}\n" + extrato;


            txtOperacao.Clear();
            btnSacar.BackColor = Color.LightCoral;
            btnDepositar.BackColor = Color.LightCoral;
            btnExtrato.BackColor = Color.LightCoral;
            btnEnviar.BackColor = Color.RosyBrown;
            lblSaldo.Focus();
        }

        private void txtDepositar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaCaracter(e);
        }
        public void ValidaCaracter(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . por virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string

                if (txtOperacao.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista detona o processo 
                }
            }

            //aceita apenas números, tecla backspace.

            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}

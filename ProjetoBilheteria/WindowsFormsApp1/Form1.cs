using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[] btnArr = new Button[600];
        int faturamento = 0;
        int nReservados = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            char fileira = 'A';
            int coluna = 1;
            int x = 50;
            int y = 50;
            
            btnArr[0] = new Button();
            btnArr[0].Name = String.Concat(fileira.ToString(), coluna.ToString());
            btnArr[0].Text = String.Concat(fileira.ToString(), coluna.ToString());
            btnArr[0].BackColor = Color.Green;
            btnArr[0].Location = new Point(x, y);
            btnArr[0].Width = 40;
            btnArr[0].Height = 40;
            btnArr[0].Click += ocupado_Click;
            this.Controls.Add(btnArr[0]);


            for (int i = 1; i < 600; i++)
            {


                btnArr[i] = new Button();
                btnArr[i].Width = 40;
                btnArr[i].Height = 40;

                if (i % 15 == 0)
                {
                    x += 50;
                    y = 100;
                    fileira = 'A';
                    coluna++;
                    btnArr[i].Location = new Point((btnArr[i - 1].Left + 40), (btnArr[0].Top));
                }
                else if (i != 0)
                {
                    btnArr[i].Location = new Point((btnArr[i - 1].Left), (btnArr[i - 1].Top) + 40);
                    fileira++;
                }
                btnArr[i].Name = String.Concat(fileira.ToString(), coluna.ToString());
                btnArr[i].Text = String.Concat(fileira.ToString(), coluna.ToString());
                btnArr[i].BackColor = Color.Green;
                btnArr[i].Click += ocupado_Click;
                this.Controls.Add(btnArr[i]);
            }
            Button  btnReservar = new Button();
            Button btnFaturamento = new Button();
            btnReservar.Location = new Point(btnArr[598].Left, btnArr[598].Top + 100);
            btnFaturamento.Location = new Point(btnArr[598].Left + 100, btnReservar.Top);
            btnFaturamento.Name = "Faturamento";
            btnReservar.Name = "Reservar";
            btnFaturamento.Text = "Faturamento";
            btnReservar.Text = "Reservar";
            btnReservar.Click += Reservar_Click;
            btnFaturamento.Click += Faturamento_Click;
            this.Controls.Add(btnReservar);
            this.Controls.Add(btnFaturamento);

        }

        private void Reservar_Click(object sender, EventArgs e)
        {
           int totalReservas = 0;
            int totalFaturas = 0;
            for(int i = 0;  i < btnArr.Length; i++)
            {
                if(btnArr[i].BackColor == Color.Red)
                {
                    btnArr[i].Click -= livre_Click; 
                    totalReservas++;
                    totalFaturas += 10;
                    
                }
            }
            faturamento = totalFaturas;
            totalReservas = totalReservas;
            
        }
        private void Faturamento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("R$ " + faturamento);
        }

        private void ocupado_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Red;
            button.Click -= ocupado_Click;
            button.Click += livre_Click;
        }
        private void livre_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Green;
            button.Click -= livre_Click;
            button.Click += ocupado_Click;
        }
    }
    }


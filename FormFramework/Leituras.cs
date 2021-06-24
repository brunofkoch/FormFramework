using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFramework
{
    public partial class Leituras : Form
    {
        public int IDVeiculo { get; set; }
        public int IDVersao { get; set; }
        

        public Leituras()
        {
            InitializeComponent();
        }



        public Leituras(int IDV, int VV)
        {
            InitializeComponent();

            // IDVeiculo = Identificador do veiculo criado para equipe
            // IDDescMed = Identificador da Descrição e Medidas da versão do veiculo
            this.IDVeiculo = IDV;
            this.IDVersao = VV;

            if (this.IDVersao == 1)
            {
                labelVVersao.Text = "Veiculo Normal";
            }
            else
            {
                labelVVersao.Text = "Veiculo Otimizado";
            }
            
        }

        private void Leituras_Load(object sender, EventArgs e)
        {

        }

        private void buttonSal1_Click(object sender, EventArgs e)
        {            

            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                1,
                Int32.Parse(textBox1p1.Text),
                Int32.Parse(textBox2p1.Text),
                Int32.Parse(textBox3p1.Text),
                Int32.Parse(textBox4p1.Text)
                );      
        }

        private void buttonSal2_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                2,
                Int32.Parse(textBox1p2.Text),
                Int32.Parse(textBox2p2.Text),
                Int32.Parse(textBox3p2.Text),
                Int32.Parse(textBox4p2.Text)
                );
        }

        private void buttonSal3_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                3,
                Int32.Parse(textBox1p3.Text),
                Int32.Parse(textBox2p3.Text),
                Int32.Parse(textBox3p3.Text),
                Int32.Parse(textBox4p3.Text)
                );
        }

        private void buttonSal4_Click(object sender, EventArgs e)
        {
            Leitura l = new Leitura();
            l.createLeitura(
                this.IDVeiculo,
                this.IDVersao,
                4,
                Int32.Parse(textBox1p4.Text),
                Int32.Parse(textBox2p4.Text),
                Int32.Parse(textBox3p4.Text),
                Int32.Parse(textBox4p4.Text)
                );
        }
    }
}

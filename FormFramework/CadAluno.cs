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
    public partial class CadAluno : Form
    {

        public int IdEquipe { get; set; }

        private Aluno Alu = new Aluno();

        private string Box1;
        private string Box2;
        private string Box3;
        private string Box4;
        private string Box5; 

        public CadAluno()
        {
            InitializeComponent();
        }

        public CadAluno(int id)
        {
            InitializeComponent();
            this.IdEquipe = id;
        }

        private void CadAluno_Load(object sender, EventArgs e)
        {
            // Query na tabela aluno para verificar se a equipe ja possui alunos cadastrados
            var db = new MyContext();
            var query = from al in db.Alunos
                        where al.Equipe.EquipeID == this.IdEquipe
                        select al;

            // Comando de repetição para atribuir todos os alunos cadastrados nos TextBox
            foreach (var item in query)
            {
                // Se o textBox se encontrar vazo será atribuido o nome do aluno cadastrado
                if (String.IsNullOrEmpty(textBoxAlu1.Text))
                {
                    textBoxAlu1.Text = item.Nome;
                    label1id.Text = item.AlunoID.ToString();
                    this.Box1 = item.Nome;
                }
                else if (String.IsNullOrEmpty(textBoxAlu2.Text))
                {
                    textBoxAlu2.Text = item.Nome;
                    label2id.Text = item.AlunoID.ToString();
                    this.Box2 = item.Nome;
                }
                else if (String.IsNullOrEmpty(textBoxAlu3.Text))
                {
                    textBoxAlu3.Text = item.Nome;
                    label3id.Text = item.AlunoID.ToString();
                    this.Box3 = item.Nome;
                }
                else if (String.IsNullOrEmpty(textBoxAlu4.Text))
                {
                    textBoxAlu4.Text = item.Nome;
                    label4id.Text = item.AlunoID.ToString();
                    this.Box4 = item.Nome;
                }
                else 
                {
                    textBoxAlu5.Text = item.Nome;
                    label5id.Text = item.AlunoID.ToString();
                    this.Box5 = item.Nome;
                }
                               
            }
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            if (!String.IsNullOrEmpty(textBoxAlu1.Text))
            {
                if (this.Box1 != textBoxAlu1.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu1.Text);
            }                

            if (!String.IsNullOrEmpty(textBoxAlu2.Text))
            {
                if(this.Box2 != textBoxAlu2.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu2.Text);
            }
                

            if (!String.IsNullOrEmpty(textBoxAlu3.Text))
            {
                if (this.Box3 != textBoxAlu3.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu3.Text);
            }
                

            if (!String.IsNullOrEmpty(textBoxAlu4.Text))
            {
                if (this.Box4 != textBoxAlu4.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu4.Text);
            }
                

            if (!String.IsNullOrEmpty(textBoxAlu5.Text))
            {
                if (this.Box5 != textBoxAlu5.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu5.Text);
            }
                

            if(!String.IsNullOrEmpty(textBoxAlu1.Text) || !String.IsNullOrEmpty(textBoxAlu2.Text) || !String.IsNullOrEmpty(textBoxAlu3.Text) || !String.IsNullOrEmpty(textBoxAlu4.Text) || !String.IsNullOrEmpty(textBoxAlu5.Text))
            {
                MessageBox.Show("Salvo!!!", "Aviso!");
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //////////////////////////////////////////////////////////
        /// Nesta area está os botoes que remove os alunos, cada botão é responsavel por um registro
        /// Quando aluno excluido automaticamente é limpado o 'texbox' que se encontra e o 'label' onde se encontra o 'Id do aluno'
        private void buttonR1_Click(object sender, EventArgs e)
        {
            // É chamada a função deleta da classe Aluno
            // É passado como parametro o Id do Aluno que se encontra no label
            Alu.deleteAluno(Int32.Parse(label1id.Text));
            // Dispara messagem informano que o respectivo aluno foi removido
            MessageBox.Show($"{textBoxAlu1.Text} removido ", "Aviso!");
            // Limpa o textBox que o nome do aluno se encontra
            textBoxAlu1.Clear();
            // Atribui o valor de 0 no label onde armazena o id do aluno
            label1id.Text = "0";
        }

        private void buttonR2_Click(object sender, EventArgs e)
        {
            Alu.deleteAluno(Int32.Parse(label2id.Text));
            MessageBox.Show($"{textBoxAlu2.Text} removido ", "Aviso!");
            textBoxAlu2.Clear();
            label2id.Text = "0";
        }

        private void buttonR3_Click(object sender, EventArgs e)
        {
            Alu.deleteAluno(Int32.Parse(label3id.Text));
            MessageBox.Show($"{textBoxAlu3.Text} removido ", "Aviso!");
            textBoxAlu3.Clear();
            label3id.Text = "0";
        }

        private void buttonR4_Click(object sender, EventArgs e)
        {
            Alu.deleteAluno(Int32.Parse(label4id.Text));
            MessageBox.Show($"{textBoxAlu4.Text} removido ", "Aviso!");
            textBoxAlu4.Clear();
            label4id.Text = "0";
        }

        private void buttonR5_Click(object sender, EventArgs e)
        {
            Alu.deleteAluno(Int32.Parse(label5id.Text));
            MessageBox.Show($"{textBoxAlu5.Text} removido ", "Aviso!");
            textBoxAlu5.Clear();
            label5id.Text = "0";

        }

        private void textBoxAlu1_TextChanged(object sender, EventArgs e)
        {

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            if (!String.IsNullOrEmpty(textBoxAlu1.Text))
            {
                if (this.Box1 != textBoxAlu1.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu1.Text);
            }

            if (!String.IsNullOrEmpty(textBoxAlu2.Text))
            {
                if (this.Box2 != textBoxAlu2.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu2.Text);
            }


            if (!String.IsNullOrEmpty(textBoxAlu3.Text))
            {
                if (this.Box3 != textBoxAlu3.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu3.Text);
            }


            if (!String.IsNullOrEmpty(textBoxAlu4.Text))
            {
                if (this.Box4 != textBoxAlu4.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu4.Text);
            }


            if (!String.IsNullOrEmpty(textBoxAlu5.Text))
            {
                if (this.Box5 != textBoxAlu5.Text)
                    aluno.createAluno(this.IdEquipe, textBoxAlu5.Text);
            }


            if (!String.IsNullOrEmpty(textBoxAlu1.Text) || !String.IsNullOrEmpty(textBoxAlu2.Text) || !String.IsNullOrEmpty(textBoxAlu3.Text) || !String.IsNullOrEmpty(textBoxAlu4.Text) || !String.IsNullOrEmpty(textBoxAlu5.Text))
            {
                MessageBox.Show("Salvo!!!", "Aviso!");
            }

        }
        ////////////////////////////////////////////////////////////////////////////
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoBD
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string conexaoString = "server=localhost;user=root;database=agenda;port=3306;password=";
            string consulta = "INSERT INTO contato (nome,email,telefone) VALUES (@valo1,@valor2,@valor3)";

            try
            {
                // Serão tratadas as informações do banco de dados e os campos do formulário

                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {

                conexao.Open();

                }



                MessageBox.Show("Dados Inseridos com sucesso na base de dados!!!!");
            } catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao Inserir dados: "+ex.Message);
            }
        }
    }
}

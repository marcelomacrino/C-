using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace dadosMysqlForms
{
    public partial class Form1: Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string conexaoString = "server=localhost;user=root;database=db_agenda;port=3306;password=;";
            string consulta = "INSERT INTO contatos (nome, email, telefone) VALUES (@valor1, @valor2, @valor3)";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexao))
                    {
                        comando.Parameters.AddWithValue("@valor1", txtNome.Text);
                        comando.Parameters.AddWithValue("@valor2", txtEmail.Text);
                        comando.Parameters.AddWithValue("@valor3", txtxTelefone.Text);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados inseridos com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao inserir dados: " + ex.Message);
            }
        }
    }
}

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

namespace Projeto_Agenda
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)

            
        {
            
            // Obtem o valor dos campos DateTimePicker
            DateTime dataInicio = dateInicio.Value;
            DateTime dataFim = dateFim.Value;

            // Obtem o valor do CheckBox
            bool valorBoleano = chkFinalizada.Checked;

            // Formatando data para o MySql
            string dataInicioFormatada = dataInicio.ToString("yyyy-MM-dd HH:mm:ss");
            string dataFimFormatada = dataFim.ToString("yyyy-MM-dd HH:mm:ss");

            // Converter o valor booleano para 0 ou 1
            int tarefaFinalizada = valorBoleano ? 1 : 0;

            //MessageBox.Show(dataInicioFormatada);
            //MessageBox.Show(dataFimFormatada);

            string conexaoString = "server=localhost;user=root;" +
                "database=agenda;port=3306;password=;";
            string insercao = "INSERT INTO tbl_tarefas " +
                "(titulo,descricao,dataCriacao,dataInicio,dataFim,finalizada) " +
                "VALUES (@valor1,@valor2,NOW(),@data1,@data2,@valor3)";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(insercao,conexao)) 
                    {
                        comando.Parameters.AddWithValue("@valor1",txtTitulo.Text);
                        comando.Parameters.AddWithValue("@valor2", txtDescricao.Text);
                        comando.Parameters.AddWithValue("@data1", dataInicioFormatada);
                        comando.Parameters.AddWithValue("@data2", dataFimFormatada);
                        comando.Parameters.AddWithValue("@valor3", tarefaFinalizada);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Dados Salvos com Sucesso!!!");
                    }

          
                }
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show("Erro: " + ex.Message); 
            }
            
        }
    }
}

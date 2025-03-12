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
            // Tratar os campos do formulário.

            // Passar para variáveis os campos Titulo e Descrição
            string titulo = txtTitulo.Text;
            string descricao = txtDescricao.Text;

            // Obter o valor dos campos DateTimePicker - dateInicio e dateFim
            DateTime dataInicio = dateInicio.Value;
            DateTime dataFim = dateFim.Value;
            DateTime dataCriacao = DateTime.Now;

            // Formatar as data para o formato MYSQL (yyyy-MM-dd HH:mm:ss
            string dataInicioFormatada = dataInicio.ToString("yyyy-MM-dd HH:mm:ss");
            string dataFimFormatada = dataFim.ToString("yyyy-MM-dd HH:mm:ss");

            // Obter o valor do campo Booleano Finalizada (checkBox)
            bool valorBooleano = chkFinalizada.Checked;

            // Converter o valor booleano para 0 - Não finalizada ou 1 - Finalizada
            int tarefaFinalizada = valorBooleano ? 1 : 0;

            // Criar a String de Conexão com o servidor e o banco de dados
            string conexaoString = "server=localhost;user=root;database=projeto_agenda;port=3306;password=";
            // String SQL INSERT utilizando os dados coletados
            string query = "INSERT INTO tbl_tarefas (titulo, descricao, dataCriacao, dataInicio, dataFim, finalizada) " +
                "VALUES (@titulo, @descricao, @dataCriacao, @dataInicio, @dataFim, @finalizada)";
           
            // Cria uma estrutura try catch. Executa o que está dentro do try, se tudo ok exibe a mensagem
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString)) // Cria a conexao com o banco de dados MYSQl
                {
                    using (MySqlCommand comando = new MySqlCommand(query, conexao)) // Cria um objeto MySqlCommand para executar query com a conexao fornecida
                    {
                        // adiciona os valores dos seus campos de entrada como parâmetros à consulta. Isso evita a injeção de SQL
                        comando.Parameters.AddWithValue("@titulo", titulo); 
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        comando.Parameters.AddWithValue("@dataCriacao", dataCriacao);
                        comando.Parameters.AddWithValue("@dataInicio", dataInicioFormatada);
                        comando.Parameters.AddWithValue("@dataFim", dataFimFormatada);
                        comando.Parameters.AddWithValue("@finalizada", tarefaFinalizada);
                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                        
                    MessageBox.Show("Conecatado com Sucesso!!!");
                }
            } catch (MySqlException ex) // Se der erro no try exibe a mensagem abaixo
            {
                    MessageBox.Show("Erro: "+ex.Message);
            }

        }
    }
}

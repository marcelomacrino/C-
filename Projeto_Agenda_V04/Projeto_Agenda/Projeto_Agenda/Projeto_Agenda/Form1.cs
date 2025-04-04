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
        string conexaoString = "server=localhost;user=root;" +
               "database=agenda;port=3306;password=;";
        private DataTable tarefasDataTable = new DataTable();
        private int tarefaIdSelecionada = -1; // Armazenar o id da tarefa selecionada

        public Form1()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtTitulo.Text = "";
            txtDescricao.Text = "";
            dateInicio.Value = DateTime.Now;
            dateFim.Value = DateTime.Now;
            chkFinalizada.Checked = false;
            tarefaIdSelecionada = -1; // Reseta o ID da Tarefa Selecionada
        }

        private void CarregarTarefas()
        {
            
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    string consulta = "SELECT * FROM tbl_tarefas";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexao))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            tarefasDataTable.Clear();
                            adaptador.Fill(tarefasDataTable);
                            dataGridViewTarefas.DataSource = tarefasDataTable;
                            foreach (DataGridViewColumn coluna in dataGridViewTarefas.Columns)
                            {
                                coluna.ReadOnly = true;
                                dataGridViewTarefas.Columns["id"].HeaderText = "ID";
                                dataGridViewTarefas.Columns["titulo"].HeaderText = "TÍTULO";
                                dataGridViewTarefas.Columns["descricao"].HeaderText = "DESCRIÇÂO";
                                dataGridViewTarefas.Columns["dataCriacao"].HeaderText = "DATA DE CRIAÇÃO";
                                dataGridViewTarefas.Columns["dataInicio"].HeaderText = "DATA DE INÍCIO";
                                dataGridViewTarefas.Columns["dataFim"].HeaderText = "DATA FINALIZAÇÃO";
                                dataGridViewTarefas.Columns["finalizada"].HeaderText = "TERMINADA";
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao carregar tarefas: " + ex.Message);
            }
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

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();

                    MySqlCommand comando;

                    if(tarefaIdSelecionada == -1) // Inserir nova Tarefa
                    {
                        string insercao = "INSERT INTO tbl_tarefas " +
                        "(titulo,descricao,dataCriacao,dataInicio,dataFim,finalizada) " +
                        "VALUES (@valor1,@valor2,NOW(),@data1,@data2,@valor3)";

                        comando = new MySqlCommand(insercao, conexao);
                    } else // Atualiza tarefa existente
                    {
                        string atualizacao = "UPDATE tbl_tarefas SET " +
                                             "titulo = @valor1, descricao = @valor2, dataInicio = @data1, " +
                                             "dataFim = @data2, finalizada = @valor3 WHERE id = @id";

                        comando = new MySqlCommand(atualizacao, conexao);
                        comando.Parameters.AddWithValue("@id", tarefaIdSelecionada);
                    }

                        comando.Parameters.AddWithValue("@valor1", txtTitulo.Text);
                        comando.Parameters.AddWithValue("@valor2", txtDescricao.Text);
                        comando.Parameters.AddWithValue("@data1", dataInicioFormatada);
                        comando.Parameters.AddWithValue("@data2", dataFimFormatada);
                        comando.Parameters.AddWithValue("@valor3", tarefaFinalizada);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Dados Salvos com Sucesso!!!");

                        CarregarTarefas();
                        LimparFormulario();       
                }
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show("Erro: " + ex.Message); 
            }
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            CarregarTarefas();
        }

        // Versão 3 - Implementar os filtros por título
        private void FiltrarPorTitulo(string textoPesquisa)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    string consulta = "SELECT * FROM tbl_tarefas WHERE titulo LIKE @textoPesquisa";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexao))
                    {
                        comando.Parameters.AddWithValue("@textoPesquisa", "%" + textoPesquisa + "%");
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            tarefasDataTable.Clear();
                            adaptador.Fill(tarefasDataTable);
                            dataGridViewTarefas.DataSource = tarefasDataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao filtrar tarefas: " + ex.Message);
            }
        }

        // Implementado na versão 3
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string textoPesquisa = txtPesquisa.Text;
            FiltrarPorTitulo(textoPesquisa);
        }

        // Implementar na versão 3 - por período dataInicio e dataFim
        private void FiltrarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    string consulta = "SELECT * FROM tbl_tarefas WHERE dataInicio >= @dataInicio AND dataFim <= @dataFim";
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexao))
                    {
                        comando.Parameters.AddWithValue("@dataInicio", dataInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                        comando.Parameters.AddWithValue("@dataFim", dataFim.ToString("yyyy-MM-dd HH:mm:ss"));
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            tarefasDataTable.Clear();
                            adaptador.Fill(tarefasDataTable);
                            dataGridViewTarefas.DataSource = tarefasDataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao filtrar tarefas: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Implementado na versão 3
        private void dateFiltroInicio_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataInicio = dateFiltroInicio.Value;
            DateTime dataFim = dateFiltroFim.Value;
            FiltrarPorPeriodo(dataInicio, dataFim);
        }

        private void dateFiltroFim_ValueChanged(object sender, EventArgs e)
        {
            DateTime dataInicio = dateFiltroInicio.Value;
            DateTime dataFim = dateFiltroFim.Value;
            FiltrarPorPeriodo(dataInicio, dataFim);
        }

        private void dataGridViewTarefas_CellContentClick(object sender, DataGridViewCellEventArgs e) // método para clicar no grid e carregar as tarefas no forms para ser alterada
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTarefas.Rows[e.RowIndex];
                tarefaIdSelecionada = Convert.ToInt32(row.Cells["id"].Value);
                txtTitulo.Text = row.Cells["titulo"].Value.ToString();
                txtDescricao.Text = row.Cells["descricao"].Value.ToString();
                dateInicio.Value = Convert.ToDateTime(row.Cells["dataInicio"].Value);
                dateFim.Value = Convert.ToDateTime(row.Cells["dataFim"].Value);
                chkFinalizada.Checked = Convert.ToBoolean(row.Cells["finalizada"].Value);
            }
        }
    }
}

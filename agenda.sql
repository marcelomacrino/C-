-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 21/03/2025 às 19:03
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `agenda`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbl_tarefas`
--

CREATE TABLE `tbl_tarefas` (
  `id` int(10) UNSIGNED NOT NULL,
  `titulo` varchar(255) NOT NULL,
  `descricao` varchar(255) NOT NULL,
  `dataCriacao` datetime NOT NULL,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime NOT NULL,
  `finalizada` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbl_tarefas`
--

INSERT INTO `tbl_tarefas` (`id`, `titulo`, `descricao`, `dataCriacao`, `dataInicio`, `dataFim`, `finalizada`) VALUES
(1, 'Teste', 'teste de tarefas', '2025-03-21 11:32:15', '2025-03-21 11:32:05', '2025-03-21 11:32:05', 0),
(2, 'Teste', 'tarefas teste', '2025-03-21 11:33:47', '2025-03-21 11:33:38', '2025-03-21 11:33:38', 0),
(3, 'zzxbzb', 'zxbzxb', '2025-03-21 13:34:04', '2025-03-21 13:34:00', '2025-03-21 13:34:00', 0),
(4, 'asfasf', 'asfasf', '2025-03-21 13:36:52', '2025-03-21 13:36:48', '2025-03-21 13:36:48', 0),
(5, 'FGGASDGSD', 'SDGSDGDSG', '2025-03-21 14:24:14', '2025-03-21 14:24:08', '2025-03-21 14:24:08', 0),
(6, 'Teste', 'Teste para criar tarefa', '2025-03-21 14:25:20', '2025-03-21 14:25:07', '2025-03-21 14:25:07', 0),
(7, 'wtwtw', 'wetwetwte', '2025-03-21 14:26:26', '2025-03-21 14:26:23', '2025-03-21 14:26:23', 0),
(8, 'wtwtw', 'wetwetwte', '2025-03-21 14:26:53', '2025-03-21 14:26:23', '2025-03-21 14:26:23', 1),
(9, 'Reunião Direção', 'Discutir sobre a turma do 3º Módulo', '2025-03-21 14:27:47', '2025-03-24 14:27:25', '2025-03-24 14:27:25', 0),
(10, 'Arrumar Casa', 'Pintar as Paredes', '2025-03-21 14:33:42', '2025-03-27 14:33:15', '2025-03-28 14:33:15', 0),
(11, 'Teste de Tarefas', 'Descrição de teste de tarefas', '2025-03-21 14:50:17', '2025-03-28 14:49:53', '2025-03-28 14:49:53', 0);

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `tbl_tarefas`
--
ALTER TABLE `tbl_tarefas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbl_tarefas`
--
ALTER TABLE `tbl_tarefas`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

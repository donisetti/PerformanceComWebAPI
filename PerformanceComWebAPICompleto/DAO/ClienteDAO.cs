using Dapper;
using PerformanceComWebAPI.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PerformanceComWebAPICompleto.DAO
{
    public class ClienteDAO
    {
        //string da conexão com a base de dados
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteDapper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        /// <summary>
        /// Listar todos os cliente da base de dados
        /// </summary>
        /// <returns></returns>
        public List<Cliente> Listar()
        {
            var sql = "select * from dbo.Cliente";
            List<Cliente> clientes = new List<Cliente>();

            using (var connection = new SqlConnection(connectionString))
            {
                clientes = connection.Query<Cliente>(sql).ToList();
            }

            return clientes;
        }

        /// <summary>
        /// Metodo que recupera o cliente pelo id
        /// </summary>
        /// <param name="idCliente">id cliente que vai ser recuperado</param>
        /// <returns>O cliente que correspondente do cliente ou null quando não tiver cliente com id</returns>
        public Cliente RecuperarPorID(int idCliente)
        {
            var sql = "select * from dbo.Cliente where id = @id";

            Cliente cliente = new Cliente();

            using (var connection = new SqlConnection(connectionString))
            {
                cliente = connection.QueryFirstOrDefault<Cliente>(sql, new { id = idCliente });
            }

            return cliente;
        }
    }
}

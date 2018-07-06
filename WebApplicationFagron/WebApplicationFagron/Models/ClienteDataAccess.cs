using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationFagron.Models
{
    public class ClienteDataAccess
    {
		//Server=MSSQL1;Database=AdventureWorks;Integrated Security=true;
		string connectionString = @"server=ADM-PC\SQLEXPRESS; Database=TesteFragon;Integrated Security=SSPI;";

		public IEnumerable<Cliente> GetAllCliente()
		{
			try
			{
				List<Cliente> lstCliente = new List<Cliente>();

				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand("spGetAllCliente", con);
					cmd.CommandType = CommandType.StoredProcedure;

					con.Open();
					SqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Cliente cliente = new Cliente();

						cliente.Id = Convert.ToInt32(rdr["id"]);
						cliente.Nome = rdr["nome"].ToString();
						cliente.Sobrenome = rdr["sobrenome"].ToString();
						cliente.Cpf = rdr["cpf"].ToString();
						cliente.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
						cliente.Idade = Convert.ToInt32(rdr["idade"]);
						cliente.Profissao = Convert.ToInt32(rdr["profissao"]);

						lstCliente.Add(cliente);
					}
					con.Close();

				}
				return lstCliente;
			}
			catch
			{
				throw;
			}
		}

		public int AddCliente(Cliente cliente)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand("spAddCliente", con);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
					cmd.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
					cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
					cmd.Parameters.AddWithValue("@Data", cliente.Dt_nasc);
					cmd.Parameters.AddWithValue("@Idade", cliente.Idade);
					cmd.Parameters.AddWithValue("@profissao", cliente.Profissao);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}
				return 1;

			}
			catch
			{
				throw;
			}
		}

		public int UpdateCliente(Cliente cliente)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand("spUpdateCliente", con);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
					cmd.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
					cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
					cmd.Parameters.AddWithValue("@Data", cliente.Dt_nasc);
					cmd.Parameters.AddWithValue("@Idade", cliente.Idade);
					cmd.Parameters.AddWithValue("@profissao", cliente.Profissao);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();

				}
				return 1;

			}
			catch
			{
				throw;
			}
		}

		public Cliente GetCliente(int id)
		{
			try
			{
				Cliente cliente = new Cliente();

				using (SqlConnection con = new SqlConnection(connectionString))
				{
					string sqlQuery = "SELECT * FROM cliente WHERE id = " + id;
					SqlCommand cmd = new SqlCommand(sqlQuery, con);
					
					con.Open();
					SqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						cliente.Id = Convert.ToInt32(rdr["id"]);
						cliente.Nome = rdr["nome"].ToString();
						cliente.Sobrenome = rdr["sobrenome"].ToString();
						cliente.Cpf = rdr["cpf"].ToString();
						cliente.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
						cliente.Idade = Convert.ToInt32(rdr["idade"]);
						cliente.Profissao = Convert.ToInt32(rdr["profissao"]);
					}

				}
				return cliente;
			}
			catch
			{
				throw;
			}
		}

		public int DeleteCliente(int id)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand(connectionString, con);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@id", id);

					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}
				return 1;

			}
			catch
			{
				throw;
			}
		}
	}
}

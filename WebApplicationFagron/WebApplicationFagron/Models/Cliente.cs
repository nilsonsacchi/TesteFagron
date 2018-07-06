using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationFagron.Models
{
	public class Cliente
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public string Sobrenome { get; set; }

		public string Cpf { get; set; }

		public DateTime Dt_nasc { get; set; }

		public int Idade { get; set; }

		public int Profissao { get; set; }

	}
}

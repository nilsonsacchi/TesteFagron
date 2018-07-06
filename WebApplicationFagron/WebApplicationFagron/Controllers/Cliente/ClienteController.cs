using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFagron.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationFagron.Controllers
{

    public class ClienteController : Controller
    {
		ClienteDataAccess objcliente = new ClienteDataAccess();

		[HttpGet]
		[Route("api/Cliente/Index")]
		public IEnumerable<Cliente> Index()
		{
			return objcliente.GetAllCliente();
		}

		[HttpPost]
		[Route("api/Cliente/Create")]
		public int Create([FromBody] Cliente cliente)
		{
			return objcliente.AddCliente(cliente);
		}

		[HttpGet]
		[Route("api/Cliente/Details/{id}")]
		public Cliente Details(int id)
		{
			return objcliente.GetCliente(id);
		}

		[HttpPut]
		[Route("api/Cliente/Edit")]
		public int Edit([FromBody]Cliente cliente)
		{
			return objcliente.UpdateCliente(cliente);
		}

		[HttpDelete]
		[Route("api/Employee/Delete/{id}")]
		public int Delete(int id)
		{
			return objcliente.DeleteCliente(id);
		}
	}
}

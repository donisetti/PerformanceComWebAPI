using Microsoft.AspNetCore.Mvc;
using PerformanceComWebAPI.Modelos;
using System.Collections.Generic;

namespace PerformanceComWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public List<Cliente> Get()
        {
            var listaClientes = new List<Cliente>();
            for (int i = 0; i < 1000; i++)
            {
                listaClientes.Add(new Cliente
                {
                    Id = i,
                    Nome = $"Nome do cliente {i}"
                });
            }
            return listaClientes;
        }
    }
}
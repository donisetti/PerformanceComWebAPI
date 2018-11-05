using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using PerformanceComWebAPI.Modelos;
using PerformanceComWebAPICompleto.DAO;
using System;
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

        [HttpGet("ListarComDapper")]
        public List<Cliente> ListarComDapper(
             [FromServices]IConfiguration config,
             [FromServices]IMemoryCache cache
            )
        {
            
            var clientes = cache.GetOrCreate<List<Cliente>>(
                "ListaClientes", context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                    context.SetPriority(CacheItemPriority.High);
                    var dao = new ClienteDAO();
                    return dao.Listar();
                }
                );

            return clientes;
           
        }

        [HttpGet("{idCliente}")]
        public Cliente RecuperarPorID([FromRoute] int idCliente)
        {
            var dao = new ClienteDAO();
            return dao.RecuperarPorID(idCliente);
        }
    }

}
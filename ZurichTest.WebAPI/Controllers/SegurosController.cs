using Microsoft.AspNetCore.Mvc;
using System;
using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SegurosController : Controller
    {
        private readonly IRepositorioSeguro repositorioSeguro;
        public SegurosController(IRepositorioSeguro repositorioSeguro)
        {
            this.repositorioSeguro = repositorioSeguro;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(repositorioSeguro.PegarTodosOsSeguros());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet("MediaDosValoresDosSeguros")]
        public ActionResult GetMediaDosValoresDosSeguros()
        {
            try
            {
                return Ok(repositorioSeguro.RetornarMediaDosSeguros());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(repositorioSeguro.PesquisarSeguroPorId(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody]Seguro seguro)
        {
            try
            {
                repositorioSeguro.Adicionar(seguro);
                return Ok(seguro);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Seguro seguro)
        {
            try
            {
                repositorioSeguro.Atualizar(id, seguro);
                return Ok(repositorioSeguro.PesquisarSeguroPorId(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                repositorioSeguro.Deletar(repositorioSeguro.PesquisarPorId(id));
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

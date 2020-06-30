using Microsoft.AspNetCore.Mvc;
using System;
using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SeguradosController : Controller
    {
        private readonly IRepositorioSegurado repositorioSegurado;
        public SeguradosController(IRepositorioSegurado repositorioSegurado)
        {
            this.repositorioSegurado = repositorioSegurado;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(repositorioSegurado.PegarTodos());
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
                return Ok(repositorioSegurado.PesquisarPorId(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody]Segurado segurado)
        {
            try
            {
                repositorioSegurado.Adicionar(segurado);
                return Ok(segurado);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Segurado segurado)
        {
            try
            {
                repositorioSegurado.Atualizar(id, segurado);
                return Ok(repositorioSegurado.PesquisarPorId(id));
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
                repositorioSegurado.Deletar(repositorioSegurado.PesquisarPorId(id));
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

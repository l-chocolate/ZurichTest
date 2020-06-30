using Microsoft.AspNetCore.Mvc;
using System;
using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class VeiculosController : Controller
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        public VeiculosController(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(repositorioVeiculo.PegarTodos());
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
                return Ok(repositorioVeiculo.PesquisarPorId(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody]Veiculo veiculo)
        {
            try
            {
                repositorioVeiculo.Adicionar(veiculo);
                return Ok(veiculo);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Veiculo veiculo)
        {
            try
            {
                repositorioVeiculo.Atualizar(id, veiculo);
                return Ok(repositorioVeiculo.PesquisarPorId(id));
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
                repositorioVeiculo.Deletar(repositorioVeiculo.PesquisarPorId(id));
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

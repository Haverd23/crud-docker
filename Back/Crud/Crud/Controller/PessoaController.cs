using Crud.Models;
using Crud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoa;

        public PessoaController(IPessoa pessoa)
        {
            _pessoa = pessoa;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> GetAll()
        {
            var pessoas = _pessoa.GetAll();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetById(int id)
        {
            var pessoa = _pessoa.GetId(id);
            if (pessoa == null)
            {
                return NotFound($"Pessoa com id = {id} não encontrada");
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Pessoa inválida");
            }

            _pessoa.Create(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
        }
        [HttpPut]
        public ActionResult<Pessoa> Atualizar(Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest("Pessoa inválida");
           var atualizado = _pessoa.Update(pessoa);
            if(atualizado is null) return BadRequest("Erro ao criar autor");

            return Ok(atualizado);
        }
        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Deletar(int id)
        {
            if(id < 0)
            {
                return NotFound($"Não foi possível encontrar autor com Id: {id}");

            }
            var pessoa = _pessoa.GetId(id);
            if(pessoa is null) return NotFound($"Não foi possível encontrar autor com Id: {id}");
            var removido = _pessoa.Delete(id);
            if (removido is null) return BadRequest("Erro ao deletar pessoa");
            return Ok(removido);

        }
    }
}



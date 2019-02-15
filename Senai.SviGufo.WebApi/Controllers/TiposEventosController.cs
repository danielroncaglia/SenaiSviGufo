using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain{ Id = 4, Nome = "Design"}
        };

        private ITipoEventoRepository TipoEventoReposity { get; set; }

        public TiposEventosController()
        {
            TipoEventoReposity = new TipoEventoReposity();
        }
        //[HttpGet]
        //public string Get()
        //{
        //    return "Recebi sua requisição";
        //}

        /// <summary>
        /// Retorna uma lista de tipos de eventos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoReposity.Listar();
        }

        /// <summary>
        /// Busca o tipo de evento pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorn um Tipo de evento</returns>
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Id == id);

            //Verifica se foi encontrado na lista o tipo de evento
            if(tipoEvento == null)
            {
                //retorna não encontrado
                return NotFound();
            }

            //retorna ok e o tipo de evento
            return Ok(tipoEvento);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutById (int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }

    internal interface ITipoEventoReposity
    {
    }
}
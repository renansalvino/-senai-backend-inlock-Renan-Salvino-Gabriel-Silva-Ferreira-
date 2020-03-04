using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
        [Produces("application/json")]

       [ Route("api/[controller]")]
      
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }
        /// <summary>
        /// Lista Todos os Jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos com status code 200 - Ok </returns>
        //[Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }


        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        /// 
        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(JogoDomain novoJogo )
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return Ok("Deu bom!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}

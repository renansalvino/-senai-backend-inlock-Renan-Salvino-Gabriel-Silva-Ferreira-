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
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }


    }
}

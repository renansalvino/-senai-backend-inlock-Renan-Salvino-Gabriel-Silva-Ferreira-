using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método Post que tem como feito validar o Usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim ( JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim ( JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Jogos - chave - autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: "Inlock.WebApi",
               audience: "Inlock.WebApi",
               claims: claims,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds
           );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

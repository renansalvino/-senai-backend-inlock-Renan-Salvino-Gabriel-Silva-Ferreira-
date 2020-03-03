using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Listar todos os Estudios
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Buscar um Estudio através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EstudioDomain BuscarPorId(int id);


        /// <summary>
        /// Cadastrar um Estudio
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um estudio 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="EstudioAtualizado"></param>
        void Atualizar(int id, EstudioDomain EstudioAtualizado);

        void Deletar(int id);
    }
}

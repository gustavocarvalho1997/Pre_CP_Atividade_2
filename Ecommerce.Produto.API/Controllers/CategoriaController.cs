using Ecommerce.Produto.Application.Dtos;
using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplicationService _categoriaApplicationService;

        public CategoriaController(ICategoriaApplicationService categoriaApplicationService)
        {
            _categoriaApplicationService = categoriaApplicationService;
        }

        /// <summary>
        /// Metodo para retornar todos os dados de categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<CategoriaEntity>>]
        public IActionResult Get()
        {
            var categorias = _categoriaApplicationService.ObterTodasCategorias();

            if(categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para retornar uma categoria
        /// </summary>
        /// <param name="id"> Codigo identificador da categoria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _categoriaApplicationService.ObterCategoriasPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para salvar os dados da categoria
        /// </summary>
        /// <param name="entity"> Modelo de dados da categoria</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<CategoriaEntity>]
        public IActionResult Post([FromBody] CategoriaDto entity)
        {
            try
            {
                var categorias = _categoriaApplicationService.SalverDadosCategoria(entity);

                if (categorias is not null)
                    return Ok(categorias);

                return BadRequest("Não foi possivel obter os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Metodo para editar os dados da categoria
        /// </summary>
        /// <param name="id"> identificador da categoria</param>
        /// <param name="entity"> Modelo de dados da categoria</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult Put(int id, [FromBody] CategoriaDto entity)
        {
            var categorias = _categoriaApplicationService.EditarDadosCategoria(id, entity);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel alterar os dados");
        }

        /// <summary>
        /// Metodo para deletar uma categoria
        /// </summary>
        /// <param name="id"> Codigo identificador da categoria</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult Deletar(int id)
        {
            var categorias = _categoriaApplicationService.DeletarDadosCategoria(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}

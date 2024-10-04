using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Ecommerce.Produto.Domain.Interfaces.Dtos;

namespace Ecommerce.Produto.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaApplicationService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public CategoriaEntity? DeletarDadosCategoria(int id)
        {
            return _categoriaRepository.DeletarDados(id);
        }

        public CategoriaEntity? EditarDadosCategoria(int id, ICategoriaDto entity)
        {
            return _categoriaRepository.EditarDados(new CategoriaEntity {
                Id = id,
                Nome = entity.Nome,
                Descriao = entity.Descriao,            
            });
        }

        public CategoriaEntity? ObterCategoriasPorId(int id)
        {
            return _categoriaRepository.ObterPorId(id);
        }

        public IEnumerable<CategoriaEntity> ObterTodasCategorias()
        {
            return _categoriaRepository.ObterTodos();
        }

        public CategoriaEntity? SalverDadosCategoria(ICategoriaDto entity)
        {
            entity.Validator();

            return _categoriaRepository.SalverDados(new CategoriaEntity
            {
                Nome = entity.Nome,
                Descriao = entity.Descriao,
            });
        }
    }
}

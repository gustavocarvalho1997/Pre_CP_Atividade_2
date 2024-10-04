using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces.Dtos;

namespace Ecommerce.Produto.Domain.Interfaces
{
    public interface ICategoriaApplicationService
    {
        IEnumerable<CategoriaEntity> ObterTodasCategorias();
        CategoriaEntity? ObterCategoriasPorId(int id);
        CategoriaEntity? SalverDadosCategoria(ICategoriaDto entity);
        CategoriaEntity? EditarDadosCategoria(int id, ICategoriaDto entity);
        CategoriaEntity? DeletarDadosCategoria(int id);
    }
}
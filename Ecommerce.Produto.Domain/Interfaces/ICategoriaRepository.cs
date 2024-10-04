using Ecommerce.Produto.Domain.Entities;

namespace Ecommerce.Produto.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaEntity> ObterTodos();  
        CategoriaEntity? ObterPorId(int id);  
        CategoriaEntity? SalverDados(CategoriaEntity entity);  
        CategoriaEntity? EditarDados(CategoriaEntity entity);  
        CategoriaEntity? DeletarDados(int id);  
    }
}
using Ecommerce.Produto.Data.AppData;
using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;

namespace Ecommerce.Produto.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationContext _context;

        public CategoriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public CategoriaEntity? DeletarDados(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if(categoria is not null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();

                return categoria;
            }

            return null;
        }

        public CategoriaEntity? EditarDados(CategoriaEntity entity)
        {
            var categoria = _context.Categoria.Find(entity.Id);

            if (categoria is not null)
            {

                categoria.Nome = entity.Nome;
                categoria.Descriao = entity.Descriao;

                _context.Categoria.Update(categoria);
                _context.SaveChanges();

                return categoria;
            }

            return null;
        }

        public CategoriaEntity? ObterPorId(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if (categoria is not null)
            {
                return categoria;
            }

            return null;
        }

        public IEnumerable<CategoriaEntity> ObterTodos()
        {
            var categoria = _context.Categoria.ToList();

            return categoria;
        }

        public CategoriaEntity? SalverDados(CategoriaEntity entity)
        {
            _context.Categoria.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}

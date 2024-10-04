using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Ecommerce.Produto.Domain.Interfaces.Dtos;

namespace Ecommerce.Produto.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoApplicationService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoEntity? DeletarDadosProduto(int id)
        {
            return _produtoRepository.DeletarDados(id);
        }

        public ProdutoEntity? EditarDadosProduto(int id, IProdutoDto entity)
        {
            return _produtoRepository.EditarDados(new ProdutoEntity
            {
                Id = id,
                Nome = entity.Nome,
                Descriao = entity.Descriao,
                Quantidade = entity.Quantidade
            });
        }

        public ProdutoEntity? ObterProdutoPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public IEnumerable<ProdutoEntity> ObterTodosProdutos()
        {
            return _produtoRepository.ObterTodos();
        }

        public ProdutoEntity? SalverDadosProduto(IProdutoDto entity)
        {
            entity.Validator();
            return _produtoRepository.SalverDados(new ProdutoEntity
            {
                Nome = entity.Nome,
                Descriao = entity.Descriao,
                Quantidade = entity.Quantidade
            });  
        }
    }
}

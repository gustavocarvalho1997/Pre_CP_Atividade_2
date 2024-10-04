namespace Ecommerce.Produto.Domain.Interfaces.Dtos
{
    public interface IProdutoDto
    {
        string Nome { get; set; }
        string Descriao { get; set; }
        int Quantidade { get; set; }

        void Validator();

    }
}

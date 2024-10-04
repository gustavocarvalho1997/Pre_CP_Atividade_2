namespace Ecommerce.Produto.Domain.Interfaces.Dtos
{
    public interface ICategoriaDto
    {
        string Nome { get; set; }
        string Descriao { get; set; }

        void Validator();
    }
}

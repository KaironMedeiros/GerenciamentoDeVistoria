using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface
{
    public interface ILocatarioRepositorio
    {
        Task<Locatario> BuscarPorFK(int id);
        Task<Imovel> BuscarPorIdImovel(int id);
        Locatario Atualizar(Locatario locatario);
        Locatario Adicionar(Locatario locatario);
        bool IdExiste(int id);
        bool Excluir(Locatario locatario);
    }
}

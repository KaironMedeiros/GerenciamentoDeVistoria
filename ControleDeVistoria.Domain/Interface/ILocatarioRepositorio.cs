using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface
{
    public interface ILocatarioRepositorio
    {
        Locatario BuscarPorFK(int id);
        Imovel BuscarPorIdImovel(int id);
        Locatario Atualizar(Locatario locatario);
        Locatario Adicionar(Locatario locatario);
        bool IdExiste(int id);
        bool Excluir(Locatario locatario);
    }
}

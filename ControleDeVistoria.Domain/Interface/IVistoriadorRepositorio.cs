using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface
{
    public interface IVistoriadorRepositorio
    {
        Task<Vistoriador> BuscarPorId(int id);
        Task<ICollection<Vistoriador>> BuscarTodos();
        Vistoriador Atualizar(Vistoriador vistoriador);
        Vistoriador Adicionar(Vistoriador vistoriador);
        bool IdExiste(int id);
        bool Excluir(Vistoriador vistoriador);
    }
}

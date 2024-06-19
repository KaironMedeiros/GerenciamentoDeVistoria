using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface
{
    public interface IVistoriaRepositorio
    {
        Task<Vistoria> BuscarPorId(int id);
        Task<Vistoria> BuscarPorIdImovel(int id);
        Task<Vistoriador> BuscarPorIdVistoriador(int id);
        Task<ICollection<Vistoria>> BuscarPorUsuario();
        Task<ICollection<Vistoria>> BuscarTodos();
        Task<ICollection<Ambiente>> BuscarAmbientes(int vistoriaId);
        Vistoria Adicionar(Vistoria vistoria);
        Vistoria Atualizar(Vistoria vistoria);
        bool IdExiste(int id);
        bool Excluir(Vistoria vistoria);
    }
}

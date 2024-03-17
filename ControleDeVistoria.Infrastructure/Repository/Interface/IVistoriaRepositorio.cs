using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Infra.IoC.Repository.Interface
{
    public interface IVistoriaRepositorio
    {
        Vistoria BuscarPorId(int id);
        Vistoria BuscarPorIdImovel(int id);
        Vistoriador BuscarPorIdVistoriador(int id);
        ICollection<Vistoria> BuscarPorUsuario();
        ICollection<Vistoria> BuscarTodos();
        ICollection<Ambiente> BuscarAmbientes(int vistoriaId);
        Vistoria Adicionar(Vistoria vistoria);
        Vistoria Atualizar(Vistoria vistoria);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}

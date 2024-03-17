using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Infra.IoC.Repository.Interface
{
    public interface IVistoriadorRepositorio
    {
        Vistoriador BuscarPorId(int id);
        ICollection<Vistoriador> BuscarTodos();
        Vistoriador Atualizar(Vistoriador imovel);
        Vistoriador Adicionar(Vistoriador imovel);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}

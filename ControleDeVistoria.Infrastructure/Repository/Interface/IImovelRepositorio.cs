using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Infra.IoC.Repository.Interface
{
    public interface IImovelRepositorio
    {
        Imovel BuscarPorId(int id);
        ICollection<Imovel> BuscarTodos();
        ICollection<Imovel> BuscarPorUsuario(); 
        Imovel Atualizar(Imovel imovel);
        Imovel Adicionar(Imovel imovel);
        bool IdExiste(int id);
        bool Excluir(int id);
    }
}

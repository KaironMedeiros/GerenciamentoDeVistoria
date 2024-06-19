using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface
{
    public interface IImovelRepositorio
    {
        Task<Imovel> BuscarPorId(int id);
        Task<ICollection<Imovel>> BuscarTodos();
        Task<ICollection<Imovel>> BuscarPorUsuario(); 
        Imovel Atualizar(Imovel imovel);
        Imovel Adicionar(Imovel imovel);
        bool IdExiste(int id);
        bool Excluir(Imovel imovel);
    }
}

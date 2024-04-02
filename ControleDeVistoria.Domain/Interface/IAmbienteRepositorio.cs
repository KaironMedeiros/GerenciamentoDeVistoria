using ControleDeVistoria.Domain.Entities;

namespace ControleDeVistoria.Domain.Interface 
{
    public interface IAmbienteRepositorio
    {
        Ambiente BuscarPorId(int id);
        // ICollection<AmbienteModel> BuscarTodos();
        Ambiente Adicionar(Ambiente ambiente); 
        bool IdExiste(int id);
        bool Excluir(Ambiente ambiente);
    }
}

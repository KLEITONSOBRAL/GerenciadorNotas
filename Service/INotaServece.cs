using GerenciadorNotas.Models;
using GerenciadorNotas.ViewModels;

namespace GerenciadorNotas.Service
{
    public interface INotaServece
    {
        List<Nota> Listar();
        Nota? ObterPorId(int id);
        void Adicionar(NovaNotaViewModel model);
        bool Atualizar(EditarNotasViewModel model);
        void Remover(int id);





    }
}

using GerenciadorNotas.Models;
using GerenciadorNotas.ViewModels;


namespace GerenciadorNotas.Service
{
    public class NotaService : INotaServece
    {
        private readonly List<Nota> _notas = new();



        public List<Nota> Listar()
        {
            return _notas;
        }

        public Nota? ObterPorId(int id)
        {
            return _notas.FirstOrDefault(projeto => projeto.Id == id);
        }



        public void Adicionar(NovaNotaViewModel model)
        {
            var novoNota = new Nota
            {
                Id = GerarNovoId(),
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                DataCriacao = DateTime.Now
            };
            
            _notas.Add(novoNota);
        }

        public bool Atualizar(EditarNotasViewModel model)
        {
            var nota = ObterPorId(model.Id);

            if (nota is null)
                return false;

            nota.Titulo = model.Titulo;
            nota.Conteudo = model.Conteudo;

            return true;
        }

        // NOVO MÉTODO
        public void Remover(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);

            if (nota != null)
            {
                _notas.Remove(nota);
            }
        }
        private int GerarNovoId()
        {
            return _notas.Count == 0 ? 1 : _notas.Max(projeto => projeto.Id) + 1;
        }



    }

}

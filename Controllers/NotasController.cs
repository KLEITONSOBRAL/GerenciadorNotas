using GerenciadorNotas.Models;
using GerenciadorNotas.Service;
using GerenciadorNotas.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorNotas.Controllers
{
    public class NotasController : Controller
    {
        private readonly INotaServece _notaService;

        public NotasController(INotaServece notaService)
        {
            _notaService = notaService;
        }

        public IActionResult Index()
        {
            var notas = _notaService.Listar();
            return View(notas);
        }

        public IActionResult Detalhes(int id)
        {
            var notas = _notaService.ObterPorId(id);

            if (notas is null)
                return NotFound();

            return View(notas);
        }
        //Novo Metodo para fazer do desafio
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var nota = _notaService.ObterPorId(id);

            if (nota is null)
                return NotFound();

            return View(nota);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            var nota = _notaService.ObterPorId(id);

            if (nota is null)
                return NotFound();

            _notaService.Remover(id);

            TempData["Mensagem"] = "Nota excluída com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(NovaNotaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _notaService.Adicionar(model);
            TempData["Mensagem"] = "Nota cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }


        
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var nota = _notaService.ObterPorId(id);

            if (nota is null)
                return NotFound();

            var model = new EditarNotasViewModel
            {
                Id = nota.Id,
                Titulo = nota.Titulo,
                Conteudo = nota.Conteudo,
                DataCriacao = nota.DataCriacao
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EditarNotasViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var atualizado = _notaService.Atualizar(model);

            if (!atualizado)
                return NotFound();

            TempData["Mensagem"] = "Nota atualizada com sucesso!";

            return RedirectToAction(nameof(Index));
        }


    }
}
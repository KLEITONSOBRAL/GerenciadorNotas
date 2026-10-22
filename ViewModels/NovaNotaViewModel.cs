using System.ComponentModel.DataAnnotations;

namespace GerenciadorNotas.ViewModels
{
    public class NovaNotaViewModel
    {
        [Required(ErrorMessage = "Informe o título do projeto.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Informe o conteúdo do projeto.")]
        public string Conteudo { get; set; } = string.Empty;

    }
}

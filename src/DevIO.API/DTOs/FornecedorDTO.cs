using System.ComponentModel.DataAnnotations;

namespace DevIO.API.DTOs
{
    public class FornecedorDTO
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
        public EnderecoDTO? Endereco { get; set; }
        public IEnumerable<ProdutoDTO>? Produtos { get; set; }
    }
}

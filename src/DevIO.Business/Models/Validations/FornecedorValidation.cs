using FluentValidation;
using DocumentValidator;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(11)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(f => CpfValidation.Validate(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");

            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(14)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(f => CnpjValidation.Validate(f.Documento)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
            });
        }

    }
}

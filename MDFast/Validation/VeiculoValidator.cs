using FiscaliZi.MDFast.Model;
using FluentValidation;

namespace FiscaliZi.MDFast.Validation
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(veiculo => veiculo.Placa)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório")
                .Matches(@"^[a-zA-Z]{3}\-\d{4}$").WithMessage("Informe uma placa no formato ABC-1234");
            RuleFor(veiculo => veiculo.Tara)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Valor deve ser maior que 0");
            RuleFor(veiculo => veiculo.CapKG)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Valor deve ser maior que 0")
                .OverridePropertyName("Capacidade");
            RuleFor(veiculo => veiculo.UF)
                .NotNull().WithMessage("Campo obrigatório");

        }
    }
}

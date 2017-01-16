﻿using FluentValidation;
using MDFast.Model;

namespace MDFast.Validation
{
    public class MotoristaValidator : AbstractValidator<Motorista>
    {
        public MotoristaValidator()
        {
            RuleFor(motorista => motorista.Nome)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(motorista => motorista.CPF)
                .NotNull().WithMessage("Campo obrigatório")
                .NotEmpty().WithMessage("Campo obrigatório");

        }
    }
}
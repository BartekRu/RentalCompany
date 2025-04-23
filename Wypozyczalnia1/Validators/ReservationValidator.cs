using FluentValidation;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.StartDate)
                .LessThanOrEqualTo(r => r.EndDate)
                .WithMessage("Data początkowa nie może być większa od daty zakończenia rezerwacji");
        }
    }
}
